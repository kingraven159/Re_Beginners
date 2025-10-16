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

    private float addSpeedTimer = 30f;

    void Update()
    {
<<<<<<< HEAD
        PipeMove();
      
=======
        if (FindObjectOfType<UIManager>().gameStarted)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            StartCoroutine(CharacterCheck());
        }


>>>>>>> UI2
        //화면 밖으로 이동하면
        if (transform.position.x < -10)
        {
            Destroy(gameObject);       //스스로 삭제
<<<<<<< HEAD

        }
        if(speed <=MaxSpeed)
        {
            Invoke("AddSpeed()", addSpeedTimer);
=======
            StopCoroutine(CharacterCheck()); // 코루틴 정지
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

            yield return new WaitForSeconds(troughDelay);
>>>>>>> UI2
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
