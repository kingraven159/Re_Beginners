using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;       // ���� �ð�(��)�� ǥ���� �ؽ�Ʈ
    public TextMeshProUGUI finalScoreText;  // ���� ���� �� ���� �ð� ǥ��
    public GameObject startButton;          // ���� ��ư
    public GameObject gameOverPanel;        // ���� ���� ȭ��

    private Player player;
    private ScoreUp scoreUp;

    float timePassed = 0f;                  // ��� �ð� ����
    bool gameStarted = false;               // ���� ���� ����

    void Start()
    {
        gameOverPanel.SetActive(false);     // ���� ���� ȭ�� �����
        startButton.SetActive(true);        // ���� ��ư ���̱�
        scoreText.text = "Score : 0";       // �ʱ� �ð� ǥ��
    }

    void Update()
    {
        // R Ű�� ���� �����
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }

        // ������ ���۵Ǹ� �ð� ����
        if (gameStarted)
        {
            timePassed += Time.deltaTime;
            int seconds = Mathf.FloorToInt(timePassed); // �� ������ ��ȯ
            scoreText.text = "Score : " + scoreUp.score; // �ؽ�Ʈ�� ǥ��
        }
        if(player.isDeath)
        {
            GameOver();
        }
    }

    public void StartGame()
    {
        startButton.SetActive(false);       // ���� ��ư �����
        gameOverPanel.SetActive(false);     // ���� ���� ȭ�� �����
        timePassed = 0f;                    // �ð� �ʱ�ȭ
        gameStarted = true;                 // ���� ����
        scoreText.text = "Score : 0";       // �ʱ� �ؽ�Ʈ
    }

    public void GameOver()
    {
        gameStarted = false;                // �ð� ����
        gameOverPanel.SetActive(true);      // ���� ���� ȭ�� ���̱�
        finalScoreText.text = "Time: " + scoreText.text; // ���� �ð� ǥ��
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // �� �ٽ� �ε�
    }
}
