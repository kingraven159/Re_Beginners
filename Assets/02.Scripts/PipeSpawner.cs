using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;                      //������ ������
    [SerializeField] private float spawnRate = 3.0f;   //������ ���� ������
    [SerializeField] private float heighOffset = 1.5f; //������ ���� ������

    private float timer = 0f;

    public bool isTrough = false;

    void Start()
    {
        SpawnPipe();
    }
    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            SpawnPipe();
            timer = 0f;
        }
    }

    void SpawnPipe()
    {
        float pipePosY = Random.Range(-heighOffset, heighOffset);
        Vector2 spawnPosiotn = new Vector2(transform.position.x, pipePosY);
        Instantiate(pipePrefab, spawnPosiotn, Quaternion.identity);
    }

    private void OnTriggerSelect2D(Collision col)
    {
        Debug.DrawRay(transform.position, transform.forward * 1f, Color.red);

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 1f))
        {
            Debug.Log(hit.collider.gameObject.name);
        }
    }
}
