using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float moveSpeed;           // 파이프 이동 속도
    public int score = 0;              // 스코어카운터
    private PipeSpeed pipeSpeed;

    void Update()
    {
        if (FindObjectOfType<UIManager>().gameStarted)
        {
            PipeMove();
        }

        //화면 밖으로 이동하면
        if (transform.position.x < -10)
        {
            Destroy(gameObject);       //스스로 삭제
        }
    }
    void PipeMove()
    {
        moveSpeed += pipeSpeed.speed;
        Debug.Log("moveSpeed" + moveSpeed);
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
    }

}
