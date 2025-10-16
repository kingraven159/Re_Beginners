using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;       // ���� �ð�(��)�� ǥ���� �ؽ�Ʈ
    public TextMeshProUGUI finalScoreText;  // ���� ���� �� ���� �ð� ǥ��
    public GameObject startButton;          // ���� ��ư
    public GameObject gameOverPanel;        // ���� ���� ȭ��
    public Player player;
    public Pipe pipe;

    float timePassed = 0f;                  // ��� �ð� ����
    bool gameStarted = false;               // ���� ���� ����

    void Start()
    {
        gameOverPanel.SetActive(false);     // ���� ���� ȭ�� �����
        startButton.SetActive(true);        // ���� ��ư ���̱�
        scoreText.text = "Score : "+ pipe.score;       // �ʱ� �ð� ǥ��
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
            scoreText.text = "Score : " + seconds.ToString(); // �ؽ�Ʈ�� ǥ��
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
