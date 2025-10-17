using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpeed : MonoBehaviour
{

    public float speed { get; set; } = 3f;

    private bool isAddSpeed = false;

    [SerializeField] private float maxSpeed = 30f;
    [SerializeField] private float addSpeed = 2.5f;

    public UIManager uiManager;

    private void Awake()
    {
        if (uiManager == null)
            uiManager = FindObjectOfType<UIManager>();
    }

    
    void Update()
    {
        if (uiManager != null && uiManager.gameStarted)
        {
            //맥스 스피드가 아니면 계속 추가
            if (speed <= maxSpeed && !isAddSpeed)
            {
                StartCoroutine(AddSpeed());
               
            }
        }
    }

    private IEnumerator AddSpeed()
    {
        isAddSpeed = true;
        Debug.Log("호출됨");
        yield return new WaitForSeconds(1f);
        speed = Mathf.Min(speed + addSpeed, maxSpeed);
        isAddSpeed = false;
    }
}
