using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine;


public class UIManager : MonoBehaviour
{
    // ���� ������ ǥ���� �ؽ�Ʈ
    public TextMeshProUGUI scoreText;

    // ���� ���� �� ���� ������ ǥ���� �ؽ�Ʈ
    public TextMeshProUGUI finalScoreText;

    // ���� ���� ��ư
    public GameObject startButton;

    // ���� ���� ȭ�� �г�
    public GameObject gameOverPanel;

    // �÷��̾� ��ü (�ʿ� �� ����)
    public Player player;

    // ���� ���� ���� (�ٸ� ��ũ��Ʈ������ ���� �����ϵ��� public)
    [HideInInspector] public bool gameStarted = false;

    // ��� �ð� ���� ����
    float timePassed = 0f;

    // ���� ���� �� �ʱ� ����
    void Start()
    {
        // ���� ���� ȭ�� �����
        gameOverPanel.SetActive(false);

        // ���� ��ư ���̱�
        startButton.SetActive(true);
    }

    // �� �����Ӹ��� ȣ��Ǵ� ������Ʈ �Լ�
    void Update()
    {
        // R Ű�� ������ ���� �����
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }

        // ������ ���۵� ��� �ð� ���� �� ���� ǥ��
        if (gameStarted)
        {
            timePassed += Time.deltaTime;
            int seconds = Mathf.FloorToInt(timePassed);
            scoreText.text = "Score : " + seconds.ToString();
        }
    }

    // ���� ��ư Ŭ�� �� ȣ��Ǵ� �Լ�
    public void StartGame()
    {
        Debug.Log("StartGame() ȣ���");

        // ���� ��ư �����
        startButton.SetActive(false);

        // ���� ���� ȭ�� �����
        gameOverPanel.SetActive(false);

        // �ð� �ʱ�ȭ
        timePassed = 0f;

        // ���� ���� ���·� ����
        gameStarted = true;

        // ���� �ؽ�Ʈ �ʱ�ȭ
        scoreText.text = "Score : 0";
    }

    // ���� ���� �� ȣ��Ǵ� �Լ�
    public void GameOver()
    {
        // ���� ���� ����
        gameStarted = false;

        // ���� ���� ȭ�� ���̱�
        gameOverPanel.SetActive(true);

        // ���� ���� ǥ��
        finalScoreText.text = "Time: " + scoreText.text;
    }

    // ���� ����� �Լ� (���� �� �ٽ� �ε�)
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
