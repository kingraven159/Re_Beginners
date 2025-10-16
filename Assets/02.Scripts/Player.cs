using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    //�̵����� ��������
    private Rigidbody2D rigid;
    [SerializeField] private float wingForce = 1.0f;
    private float maxTilt = 30f;    //�ִ� ȸ����
    [SerializeField] private float tiltSpeed = 5.0f; // ȸ�� �ӵ�


    //���ϸ��̼� ��������
    private Animator anima;
    private static readonly int wingHash = Animator.StringToHash("Wing");

    // UIManager ����
    private UIManager uiManager;


    private void Awake()
    {   // �ʱ�ȭ
        rigid = GetComponent<Rigidbody2D>();
        anima = GetComponent<Animator>();
        // UIManager �ڵ� ����
        uiManager = FindObjectOfType<UIManager>();
        // ���� ���� ������ �߷� ���α�
        rigid.gravityScale = 0f;

    }

    void Update()
    {
        // ������ ���۵� ��쿡�� ����
        if (uiManager != null && uiManager.gameStarted)
        {
            // ���� ���� �� �߷� �ѱ� (�� ����)
            if (rigid.gravityScale == 0f)
            {
                rigid.gravityScale = 3f; // ���ϴ� �߷� ������ ����
            }

            Wing();
            Tilt();
        }
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
