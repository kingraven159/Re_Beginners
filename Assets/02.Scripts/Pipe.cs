using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float moveSpeed;           // 파이프 이동 속도
    public int score = 0;              // 스코어카운터
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

        //화면 밖으로 이동하면
        if (transform.position.x < -10)
        {
            Destroy(gameObject);       //스스로 삭제
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
