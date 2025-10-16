using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    //�̵����� ��������
    private Rigidbody2D rigid;
    [SerializeField] private float wingForce = 1.0f;
    private float maxTilt = 30f;    //�ִ� ȸ����
    private float tiltSpeed = 5.0f; // ȸ�� �ӵ�

    public bool isDeath = false;
    //���ϸ��̼� ��������
    private Animator anima;
    private static readonly int wingHash = Animator.StringToHash("Wing");

    private void Awake()
    {   // �ʱ�ȭ
        rigid = GetComponent<Rigidbody2D>();
        anima = GetComponent<Animator>();
    }

    void Update()
    {
        Wing();
        Tilt();
    }


    private void Wing()
    {   //Space�� ������ ���� �������� �ִϸ��̼�����
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
    {  // ������ ����, �������� �Ʒ��� �������ϰ� �������� ������ �ε巴��.

        // ����
        float angle = Mathf.Clamp(rigid.velocity.y * 5f, -maxTilt, maxTilt);
        //���� ���� �ҷ�����
        float currentAngle = transform.eulerAngles.z;
        if (currentAngle > 180f)
        {
            currentAngle -= 360f;
        }
        //����
        float smoothAngle = Mathf.Lerp(currentAngle, angle, Time.deltaTime * tiltSpeed);
        //ȸ�� ����
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
