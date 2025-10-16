
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

    // �÷��̾� ��ü
    public Player player;

    // ���� ���� ����
    [HideInInspector] public bool gameStarted = false;

    // ��� �ð� ���� ����
    float timePassed = 0f;

    // ���� ���� �� �ʱ� ����
    void Start()
    {
        gameOverPanel.SetActive(false); // ���� ���� UI �����
        startButton.SetActive(true);    // ���� ��ư ���̱�
    }

    // �� �����Ӹ��� ȣ��Ǵ� ������Ʈ �Լ�
    void Update()
    {
        // R Ű�� ������ ���� �����
        if (Input.GetKeyDown(KeyCode.R) && !gameStarted)
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

        startButton.SetActive(false);     // ���� ��ư �����
        gameOverPanel.SetActive(false);   // ���� ���� UI �����
        timePassed = 0f;                  // �ð� �ʱ�ȭ
        gameStarted = true;               // ���� ���� ���·� ����
        scoreText.text = "Score : 0";     // ���� �ؽ�Ʈ �ʱ�ȭ
    }

    // ���� ���� �� ȣ��Ǵ� �Լ�
    public void GameOver()
    {
        gameStarted = false;              // ���� ���� ����
        gameOverPanel.SetActive(true);    // ���� ���� UI ���̱�
        finalScoreText.text = "Time: " + scoreText.text; // ���� ���� ǥ��
    }

    // R Ű�� ���� �����
    public void RestartGame()
    {
        // ���� ���� UI �����
        gameOverPanel.SetActive(false);
        startButton.SetActive(false);

        // ���� ������ ����
        foreach (GameObject pipe in GameObject.FindGameObjectsWithTag("Pipe"))
        {
            Destroy(pipe);
        }

        // ������ ������ Ÿ�̸� �ʱ�ȭ
        PipeSpawner spawner = FindObjectOfType<PipeSpawner>();
        if (spawner != null)
        {
            spawner.ResetSpawner();
        }

        // �÷��̾� �ʱ�ȭ
        if (player != null)
        {
            player.Reset();
        }

        // ���� ���� �ʱ�ȭ �� ����
        StartGame();
        Debug.Log("������ R Ű�� ����۵Ǿ����ϴ�.");
    }

}
