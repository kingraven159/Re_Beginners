using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Pipe : MonoBehaviour
{
    public float speed = 2f;           // ������ �̵� �ӵ�
    [SerializeField] private float addSpeed = 0.5f;
    [SerializeField] private float MaxSpeed = 10.0f;

    private float addSpeedTimer = 30f;

    void Update()
    {
        PipeMove();
      
        //ȭ�� ������ �̵��ϸ�
        if (transform.position.x < -10)
        {
            Destroy(gameObject);       //������ ����

        }
        if(speed <=MaxSpeed)
        {
            Invoke("AddSpeed()", addSpeedTimer);
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
