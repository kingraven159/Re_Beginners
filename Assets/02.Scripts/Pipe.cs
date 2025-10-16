using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Pipe : MonoBehaviour
{
    public float speed = 2f;           // 파이프 이동 속도
    [SerializeField] private float addSpeed = 0.5f;
    [SerializeField] private float MaxSpeed = 10.0f;

    private float addSpeedTimer = 30f; //스피드 업 딜레이

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
        // 스피드가 맥스가 보다 작거나 같으면
        if(speed <= MaxSpeed)
        {
            Invoke("AddSpeed()", addSpeedTimer); //딜레이 후 스피드를 추가

        }
    }

    private void PipeMove()
    {
            transform.position += Vector3.left * speed * Time.deltaTime;
    }
    void AddSpeed()
    {
        speed += addSpeed;
    }
}
