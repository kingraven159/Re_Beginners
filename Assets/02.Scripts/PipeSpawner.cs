using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;                      //������ ������
    [SerializeField] private float spawnRate = 3.0f;   //������ ���� ������
    [SerializeField] private float heighOffset = 1.5f; //������ ���� ������

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
