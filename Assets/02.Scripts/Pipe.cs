using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Pipe : MonoBehaviour
{
    public float speed = 5f;           // ������ �̵� �ӵ�
    public int score = 0;              // ���ھ�ī����

    [SerializeField] private float maxSpeed = 30f;
    [SerializeField] private float addSpeed = 2.5f;
    void Update()
    {
        if (FindObjectOfType<UIManager>().gameStarted)
        {
            //�ƽ� ���ǵ尡 �ƴϸ� ��� �߰�
            if(speed <= maxSpeed)
            {
                StartCoroutine(AddSpeed());
            }

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
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
    private IEnumerator AddSpeed()
    {
        yield return new WaitForSeconds(10f);
        speed += addSpeed;
    }
}
