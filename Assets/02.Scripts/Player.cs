using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    //이동관련 전역변수
    private Rigidbody2D rigid;
    [SerializeField] private float wingForce = 1.0f;
    private float maxTilt = 30f;    //최대 회전각
    private float tiltSpeed = 5.0f; // 회전 속도

    public bool isDeath = false;
    //에니메이션 전역변수
    private Animator anima;
    private static readonly int wingHash = Animator.StringToHash("Wing");

    private void Awake()
    {   // 초기화
        rigid = GetComponent<Rigidbody2D>();
        anima = GetComponent<Animator>();
    }

    void Update()
    {
        Wing();
        Tilt();
    }


    private void Wing()
    {   //Space를 누르면 날아 오르도록 애니메이션적용
        if (Input.GetKey(KeyCode.Space))
        {

            anima.SetBool(wingHash, true);
            rigid.velocity = Vector2.up * wingForce;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            anima.SetBool(wingHash, false);
        }
    }
    private void Tilt()
    {  // 오르면 위로, 내려가면 아래를 보도록하고 보간으로 움직임 부드럽게.

        // 각도
        float angle = Mathf.Clamp(rigid.velocity.y * 5f, -maxTilt, maxTilt);
        //현재 각도 불러오기
        float currentAngle = transform.eulerAngles.z;
        if (currentAngle > 180f)
        {
            currentAngle -= 360f;
        }
        //보간
        float smoothAngle = Mathf.Lerp(currentAngle, angle, Time.deltaTime * tiltSpeed);
        //회전 적용
        transform.rotation = Quaternion.Euler(0, 0, smoothAngle);
    }

    public void Death()
    {
        isDeath = true;
        gameObject.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Pipe"))
        {
            Death();
        }       
    }
}
