using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float moveSpeed;           // ������ �̵� �ӵ�
    public int score = 0;              // ���ھ�ī����
    [SerializeField] private PipeSpeed pipeSpeed;
    private UIManager uiManager;

    private void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();
        pipeSpeed = FindObjectOfType<PipeSpeed>();
    }
    void Update()
    {
        if (uiManager != null && uiManager.gameStarted)
        {
            PipeMove();
        }

        //ȭ�� ������ �̵��ϸ�
        if (transform.position.x < -10)
        {
            Destroy(gameObject);       //������ ����
        }
    }
    void PipeMove()
    {
        float speed = pipeSpeed.speed;
        moveSpeed = speed;
        Debug.Log("moveSpeed" + moveSpeed);
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

}
