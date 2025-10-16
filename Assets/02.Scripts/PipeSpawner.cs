using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;                      //파이프 프리팹
    [SerializeField] private float spawnRate = 3.0f;   //파이프 생성 딜레이
    [SerializeField] private float heighOffset = 1.5f; //파이프 높이 프리셋

    private float spawnTimer = 0f;
    void Start()
    {
        SpawnPipe();
    }
    private void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnRate)
        {
            SpawnPipe();
            spawnTimer = 0f;
        }
    }

    void SpawnPipe()
    {
        float pipePosY = Random.Range(-heighOffset, heighOffset);
        Vector2 spawnPosiotn = new Vector2(transform.position.x, pipePosY);
        Instantiate(pipePrefab, spawnPosiotn, Quaternion.identity);
    }
}
