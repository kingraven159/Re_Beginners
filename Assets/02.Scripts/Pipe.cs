using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float moveSpeed;           // ������ �̵� �ӵ�
    public int score = 0;              // ���ھ�ī����
    private PipeSpeed pipeSpeed;

    void Update()
    {
        if (FindObjectOfType<UIManager>().gameStarted)
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
        moveSpeed += pipeSpeed.speed;
        Debug.Log("moveSpeed" + moveSpeed);
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
    }

}
