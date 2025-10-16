using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine;


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

    // 플레이어 객체 (필요 시 연결)
    public Player player;

    // 게임 시작 여부 (다른 스크립트에서도 접근 가능하도록 public)
    [HideInInspector] public bool gameStarted = false;

    // 경과 시간 저장 변수
    float timePassed = 0f;

    // 게임 시작 시 초기 설정
    void Start()
    {
        // 게임 오버 화면 숨기기
        gameOverPanel.SetActive(false);

        // 시작 버튼 보이기
        startButton.SetActive(true);
    }

    // 매 프레임마다 호출되는 업데이트 함수
    void Update()
    {
        // R 키를 누르면 게임 재시작
        if (Input.GetKeyDown(KeyCode.R))
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

        // 시작 버튼 숨기기
        startButton.SetActive(false);

        // 게임 오버 화면 숨기기
        gameOverPanel.SetActive(false);

        // 시간 초기화
        timePassed = 0f;

        // 게임 시작 상태로 변경
        gameStarted = true;

        // 점수 텍스트 초기화
        scoreText.text = "Score : 0";
    }

    // 게임 오버 시 호출되는 함수
    public void GameOver()
    {
        // 게임 상태 종료
        gameStarted = false;

        // 게임 오버 화면 보이기
        gameOverPanel.SetActive(true);

        // 최종 점수 표시
        finalScoreText.text = "Time: " + scoreText.text;
    }

    // 게임 재시작 함수 (현재 씬 다시 로드)
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
