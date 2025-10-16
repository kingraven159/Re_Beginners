using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;                      // ������ ������
    [SerializeField] private float spawnRate = 3.0f;   // ������ ���� ������
    [SerializeField] private float heighOffset = 1.5f; // ������ ���� ������

    private float timer = 0f;
    public UIManager uiManager;

    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
    }

    void Update()
    {
        if (uiManager != null && uiManager.gameStarted)
        {
            timer += Time.deltaTime;

            if (timer >= spawnRate)
            {
                SpawnPipe();
                timer = 0f;
            }
        }
    }

    void SpawnPipe()
    {
        float pipePosY = Random.Range(-heighOffset, heighOffset);
        Vector2 spawnPosition = new Vector2(transform.position.x, pipePosY);
        Instantiate(pipePrefab, spawnPosition, Quaternion.identity);
    }

    // ����� �� Ÿ�̸� �ʱ�ȭ
    public void ResetSpawner()
    {
        timer = 0f;
    }
}

