using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;       // 현재 시간(초)을 표시할 텍스트
    public TextMeshProUGUI finalScoreText;  // 게임 오버 시 최종 시간 표시
    public GameObject startButton;          // 시작 버튼
    public GameObject gameOverPanel;        // 게임 오버 화면

    float timePassed = 0f;                  // 경과 시간 저장
    bool gameStarted = false;               // 게임 실행 여부

    void Start()
    {
        gameOverPanel.SetActive(false);     // 게임 오버 화면 숨기기
        startButton.SetActive(true);        // 시작 버튼 보이기
        scoreText.text = "Score : 0";       // 초기 시간 표시
    }

    void Update()
    {
        // R 키로 게임 재시작
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }

        // 게임이 시작되면 시간 증가
        if (gameStarted)
        {
            timePassed += Time.deltaTime;
            int seconds = Mathf.FloorToInt(timePassed); // 초 단위로 변환
            scoreText.text = "Score : " + seconds.ToString(); // 텍스트에 표시
        }
    }

    public void StartGame()
    {
        startButton.SetActive(false);       // 시작 버튼 숨기기
        gameOverPanel.SetActive(false);     // 게임 오버 화면 숨기기
        timePassed = 0f;                    // 시간 초기화
        gameStarted = true;                 // 게임 시작
        scoreText.text = "Score : 0";       // 초기 텍스트
    }

    public void GameOver()
    {
        gameStarted = false;                // 시간 멈춤
        gameOverPanel.SetActive(true);      // 게임 오버 화면 보이기
        finalScoreText.text = "Time: " + scoreText.text; // 최종 시간 표시
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // 씬 다시 로드
    }
}
