using UnityEngine;

public class Player : MonoBehaviour
{
    // 물리 엔진 관련 컴포넌트
    private Rigidbody2D rigid;

    // 날갯짓 힘 조절
    [SerializeField] private float wingForce = 1.0f;

    // 회전 각도 및 속도
    private float maxTilt = 30f;
    [SerializeField] private float tiltSpeed = 5.0f;

    // 애니메이션 관련
    private Animator anima;
    private static readonly int wingHash = Animator.StringToHash("Wing");

    // UIManager 참조 (게임 상태 확인용)
    private UIManager uiManager;

    // 중력 적용 여부 플래그
    private bool gravityEnabled = false;

    // 초기 설정
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>(); // Rigidbody2D 컴포넌트 가져오기
        anima = GetComponent<Animator>();    // Animator 컴포넌트 가져오기
        uiManager = FindObjectOfType<UIManager>(); // UIManager 자동 연결
        rigid.gravityScale = 0f; // 게임 시작 전엔 중력 꺼두기
    }

    // 게임 재시작 시 플레이어 상태 초기화
    public void Reset()
    {
        transform.position = new Vector3(-2f, 0f, 0f); // 초기 위치로 이동
        rigid.velocity = Vector2.zero;                 // 속도 초기화
        rigid.gravityScale = 0f;                       // 중력 꺼두기
        transform.rotation = Quaternion.identity;      // 회전 초기화
        anima.SetBool(wingHash, false);                // 애니메이션 초기화
        gravityEnabled = false;                        // 중력 플래그 초기화
        gameObject.SetActive(true);                    // 오브젝트 다시 활성화
    }

    // 매 프레임마다 호출되는 함수
    void Update()
    {
        // 게임이 시작된 경우에만 동작
        if (uiManager != null && uiManager.gameStarted)
        {
            // 중력은 한 번만 켜기
            if (!gravityEnabled)
            {
                rigid.gravityScale = 3f; // 중력 적용
                gravityEnabled = true;
            }

            Wing();  // 날갯짓 처리
            Tilt();  // 회전 처리
        }
    }

    // 스페이스바 입력 시 날갯짓 처리
    private void Wing()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            anima.SetBool(wingHash, true); // 날갯짓 애니메이션 시작
            rigid.velocity = Vector2.up * wingForce; // 위로 힘 적용
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            anima.SetBool(wingHash, false); // 날갯짓 애니메이션 종료
        }
    }

    // 속도에 따라 회전 처리
    private void Tilt()
    {
        float angle = Mathf.Clamp(rigid.velocity.y * 5f, -maxTilt, maxTilt); // 속도 기반 각도 계산
        float currentAngle = transform.eulerAngles.z;

        // 360도 기준을 -180~180도로 변환
        if (currentAngle > 180f)
        {
            currentAngle -= 360f;
        }

        // 부드럽게 회전 보간
        float smoothAngle = Mathf.Lerp(currentAngle, angle, Time.deltaTime * tiltSpeed);
        transform.rotation = Quaternion.Euler(0, 0, smoothAngle); // 회전 적용
    }

    // 플레이어 사망 처리
    public void Death()
    {
        gameObject.SetActive(false); // 오브젝트 비활성화
        gravityEnabled = false;      // 중력 플래그 초기화
    }

    // 파이프와 충돌 시 게임 오버 처리
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pipe"))
        {
            Death();              // 플레이어 사망
            uiManager.GameOver(); // UIManager에 게임 오버 알림
        }
    }
}

