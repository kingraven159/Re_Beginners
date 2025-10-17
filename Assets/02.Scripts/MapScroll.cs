using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class MapScroll : MonoBehaviour
{
    [Header("��ũ�� ����")]
    [SerializeField] private float baseSpeed = 0.2f;   // �⺻ �ӵ�
    [SerializeField] private float scrollSpeed;        // ���� �ӵ�
    [SerializeField] private float speedStep = 0.1f;   // ������
    [SerializeField] private float stepInterval = 5f;  // ���� �ֱ�(��)

    [Header("�� ũ�� (�ȼ� ����)")]
    [SerializeField] private float mapWidth = 1280f;
    [SerializeField] private float mapHeight = 720f;

    private Renderer rend;
    private Vector2 offset;
    private float timer;
    private UIManager uiManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        offset = Vector2.zero;
        scrollSpeed = baseSpeed;

        // UIManager �ڵ� ����
        uiManager = FindObjectOfType<UIManager>();
    }

    void Update()
    {
        // UIManager�� ���ų� ���� ���� ���̸� ���߰� �ʱ�ȭ
        if (uiManager == null || !uiManager.gameStarted)
        {
            scrollSpeed = baseSpeed;
            timer = 0f;
            return;
        }

        // ���� �ð����� �ӵ� ����
        timer += Time.deltaTime;
        if (timer >= stepInterval)
        {
            scrollSpeed += speedStep;
            timer = 0.0f;
        }

        // �� ��ũ��
        offset.x += scrollSpeed * Time.deltaTime;
        rend.material.mainTextureOffset = offset;
    }
}
