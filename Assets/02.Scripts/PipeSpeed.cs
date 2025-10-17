using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpeed : MonoBehaviour
{

    public float speed {get; set;}

    private bool isAddSpeed = false;

    [SerializeField] private float maxSpeed = 30f;
    [SerializeField] private float addSpeed = 2.5f;

    public UIManager uiManager;

    private void Awake()
    {
        uiManager = GetComponent<UIManager>();
    }
    void Update()
    {
        if (uiManager != null && uiManager.gameStarted)
        {
            //�ƽ� ���ǵ尡 �ƴϸ� ��� �߰�
            if (speed <= maxSpeed && !isAddSpeed)
            {
                StartCoroutine(AddSpeed());
                Debug.Log(speed);
            }
        }
    }

    private IEnumerator AddSpeed()
    {
        isAddSpeed = true;
        Debug.Log("ȣ���");
        yield return new WaitForSeconds(1f);
        speed += addSpeed;
        isAddSpeed = false;
    }
}
