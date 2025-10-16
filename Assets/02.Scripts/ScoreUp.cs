using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUp : MonoBehaviour
{
    public int score = 0;

    private void OnTriggerEnter2D(Collider2D col)
    {
        score++;
        Debug.Log(score);
    }
}
