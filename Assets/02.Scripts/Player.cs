using UnityEngine;

public class Player : MonoBehaviour
{
    // ���� ���� ���� ������Ʈ
    private Rigidbody2D rigid;

    // ������ �� ����
    [SerializeField] private float wingForce = 1.0f;

    // ȸ�� ���� �� �ӵ�
    private float maxTilt = 30f;
    [SerializeField] private float tiltSpeed = 5.0f;

    // �ִϸ��̼� ����
    private Animator anima;
    private static readonly int wingHash = Animator.StringToHash("Wing");

    // UIManager ���� (���� ���� Ȯ�ο�)
    private UIManager uiManager;

    // �߷� ���� ���� �÷���
    private bool gravityEnabled = false;

    // �ʱ� ����
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>(); // Rigidbody2D ������Ʈ ��������
        anima = GetComponent<Animator>();    // Animator ������Ʈ ��������
        uiManager = FindObjectOfType<UIManager>(); // UIManager �ڵ� ����
        rigid.gravityScale = 0f; // ���� ���� ���� �߷� ���α�
    }

    // ���� ����� �� �÷��̾� ���� �ʱ�ȭ
    public void Reset()
    {
        transform.position = new Vector3(-2f, 0f, 0f); // �ʱ� ��ġ�� �̵�
        rigid.velocity = Vector2.zero;                 // �ӵ� �ʱ�ȭ
        rigid.gravityScale = 0f;                       // �߷� ���α�
        transform.rotation = Quaternion.identity;      // ȸ�� �ʱ�ȭ
        anima.SetBool(wingHash, false);                // �ִϸ��̼� �ʱ�ȭ
        gravityEnabled = false;                        // �߷� �÷��� �ʱ�ȭ
        gameObject.SetActive(true);                    // ������Ʈ �ٽ� Ȱ��ȭ
    }

    // �� �����Ӹ��� ȣ��Ǵ� �Լ�
    void Update()
    {
        // ������ ���۵� ��쿡�� ����
        if (uiManager != null && uiManager.gameStarted)
        {
            // �߷��� �� ���� �ѱ�
            if (!gravityEnabled)
            {
                rigid.gravityScale = 3f; // �߷� ����
                gravityEnabled = true;
            }

            Wing();  // ������ ó��
            Tilt();  // ȸ�� ó��
        }
    }

    // �����̽��� �Է� �� ������ ó��
    private void Wing()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            anima.SetBool(wingHash, true); // ������ �ִϸ��̼� ����
            rigid.velocity = Vector2.up * wingForce; // ���� �� ����
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            anima.SetBool(wingHash, false); // ������ �ִϸ��̼� ����
        }
    }

    // �ӵ��� ���� ȸ�� ó��
    private void Tilt()
    {
        float angle = Mathf.Clamp(rigid.velocity.y * 5f, -maxTilt, maxTilt); // �ӵ� ��� ���� ���
        float currentAngle = transform.eulerAngles.z;

        // 360�� ������ -180~180���� ��ȯ
        if (currentAngle > 180f)
        {
            currentAngle -= 360f;
        }

        // �ε巴�� ȸ�� ����
        float smoothAngle = Mathf.Lerp(currentAngle, angle, Time.deltaTime * tiltSpeed);
        transform.rotation = Quaternion.Euler(0, 0, smoothAngle); // ȸ�� ����
    }

    // �÷��̾� ��� ó��
    public void Death()
    {
        gameObject.SetActive(false); // ������Ʈ ��Ȱ��ȭ
        gravityEnabled = false;      // �߷� �÷��� �ʱ�ȭ
    }

    // �������� �浹 �� ���� ���� ó��
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pipe"))
        {
            Death();              // �÷��̾� ���
            uiManager.GameOver(); // UIManager�� ���� ���� �˸�
        }
    }
}

