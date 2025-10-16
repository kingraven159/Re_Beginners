using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    //이동관련 전역변수
    private Rigidbody2D rigid;
    [SerializeField] private float wingForce = 1.0f;
    private float maxTilt = 30f;    //최대 회전각
    [SerializeField] private float tiltSpeed = 5.0f; // 회전 속도


    //에니메이션 전역변수
    private Animator anima;
    private static readonly int wingHash = Animator.StringToHash("Wing");

    // UIManager 참조
    private UIManager uiManager;


    private void Awake()
    {   // 초기화
        rigid = GetComponent<Rigidbody2D>();
        anima = GetComponent<Animator>();
        // UIManager 자동 연결
        uiManager = FindObjectOfType<UIManager>();
        // 게임 시작 전에는 중력 꺼두기
        rigid.gravityScale = 0f;

    }

    void Update()
    {
        // 게임이 시작된 경우에만 동작
        if (uiManager != null && uiManager.gameStarted)
        {
            // 게임 시작 시 중력 켜기 (한 번만)
            if (rigid.gravityScale == 0f)
            {
                rigid.gravityScale = 3f; // 원하는 중력 값으로 설정
            }

            Wing();
            Tilt();
        }
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
        gameObject.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pipe"))
        {
            Death();
            uiManager.GameOver();
        }
    }
}
