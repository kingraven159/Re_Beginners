using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Pipe : MonoBehaviour
{
    public float speed = 5f;           // 파이프 이동 속도
    public int score = 0;              // 스코어카운터

    [SerializeField] private float maxSpeed = 30f;
    [SerializeField] private float addSpeed = 2.5f;
    void Update()
    {
        if (FindObjectOfType<UIManager>().gameStarted)
        {
            //맥스 스피드가 아니면 계속 추가
            if(speed <= maxSpeed)
            {
                StartCoroutine(AddSpeed());
            }

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
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
    private IEnumerator AddSpeed()
    {
        yield return new WaitForSeconds(10f);
        speed += addSpeed;
    }
}
