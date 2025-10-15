using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float speed = 2f;           // 파이프 이동 속도
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        //화면 밖으로 이동하면
        if (transform.position.x < -10)
        {
            Destroy(gameObject);       //스스로 삭제
        }
    }
}
