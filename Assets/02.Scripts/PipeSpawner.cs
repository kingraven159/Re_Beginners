using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;                      // 파이프 프리팹
    [SerializeField] private float spawnRate = 3.0f;   // 파이프 생성 딜레이
    [SerializeField] private float heighOffset = 1.5f; // 파이프 높이 프리셋

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

    // 재시작 시 타이머 초기화
    public void ResetSpawner()
    {
        timer = 0f;
    }
}

