using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUp : MonoBehaviour
{
    public int score = 0;

    private void OnTriggerEnter2D(Collision col)
    {
        score++;
    }
}
