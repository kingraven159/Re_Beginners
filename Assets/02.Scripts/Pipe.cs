using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Pipe : MonoBehaviour
{
    public float speed = 2f;           // ������ �̵� �ӵ�
    public int score = 0;              // ���ھ�ī����


    private float troughDelay = 2.0f;
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        StartCoroutine(CharacterCheck());

        //ȭ�� ������ �̵��ϸ�
        if (transform.position.x < -10)
        {
            Destroy(gameObject);       //������ ����
            StopCoroutine(CharacterCheck()); // �ڷ�ƾ ����
        }
    }
    private IEnumerator CharacterCheck()
    {
        Debug.DrawRay(transform.position, transform.up * 10f, Color.red);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.up, 1);

        if (hit.collider.CompareTag("Player"))
        {
            Debug.Log(hit.collider.gameObject.name);
            score++;
            Debug.Log(score);
            yield return new WaitForSeconds(troughDelay);
        }
    }
}
