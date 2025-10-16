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

    private float troughDelay = 2.0f;
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        //ȭ�� ������ �̵��ϸ�
        if (transform.position.x < -10)
        {
            Destroy(gameObject);       //������ ����

        }
    }

}
