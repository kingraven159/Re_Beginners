
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // 현재 점수를 표시할 텍스트
    public TextMeshProUGUI scoreText;

    // 게임 오버 시 최종 점수를 표시할 텍스트
    public TextMeshProUGUI finalScoreText;

    // 게임 시작 버튼
    public GameObject startButton;

    // 게임 오버 화면 패널
    public GameObject gameOverPanel;

    // 플레이어 객체
    public Player player;

    // 게임 시작 여부
    [HideInInspector] public bool gameStarted = false;

    // 경과 시간 저장 변수
    float timePassed = 0f;

    // 게임 시작 시 초기 설정
    void Start()
    {
        gameOverPanel.SetActive(false); // 게임 오버 UI 숨기기
        startButton.SetActive(true);    // 시작 버튼 보이기
    }

    // 매 프레임마다 호출되는 업데이트 함수
    void Update()
    {
        // R 키를 누르면 게임 재시작
        if (Input.GetKeyDown(KeyCode.R) && !gameStarted)
        {
            RestartGame();
        }

        // 게임이 시작된 경우 시간 증가 및 점수 표시
        if (gameStarted)
        {
            timePassed += Time.deltaTime;
            int seconds = Mathf.FloorToInt(timePassed);
            scoreText.text = "Score : " + seconds.ToString();
        }
    }

    // 시작 버튼 클릭 시 호출되는 함수
    public void StartGame()
    {
        Debug.Log("StartGame() 호출됨");

        startButton.SetActive(false);     // 시작 버튼 숨기기
        gameOverPanel.SetActive(false);   // 게임 오버 UI 숨기기
        timePassed = 0f;                  // 시간 초기화
        gameStarted = true;               // 게임 시작 상태로 변경
        scoreText.text = "Score : 0";     // 점수 텍스트 초기화
    }

    // 게임 오버 시 호출되는 함수
    public void GameOver()
    {
        gameStarted = false;              // 게임 상태 종료
        gameOverPanel.SetActive(true);    // 게임 오버 UI 보이기
        finalScoreText.text = "Time: " + scoreText.text; // 최종 점수 표시
    }

    // R 키로 게임 재시작
    public void RestartGame()
    {
        // 게임 오버 UI 숨기기
        gameOverPanel.SetActive(false);
        startButton.SetActive(false);

        // 기존 파이프 제거
        foreach (GameObject pipe in GameObject.FindGameObjectsWithTag("Pipe"))
        {
            Destroy(pipe);
        }

        // 파이프 스포너 타이머 초기화
        PipeSpawner spawner = FindObjectOfType<PipeSpawner>();
        if (spawner != null)
        {
            spawner.ResetSpawner();
        }

        // 플레이어 초기화
        if (player != null)
        {
            player.Reset();
        }

        // 게임 상태 초기화 및 시작
        StartGame();
        Debug.Log("게임이 R 키로 재시작되었습니다.");
    }

}
