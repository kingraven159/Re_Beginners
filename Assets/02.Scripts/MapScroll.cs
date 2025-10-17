using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class MapScroll : MonoBehaviour
{
    [Header("스크롤 설정")]
    [SerializeField] private float baseSpeed = 0.2f;   // 기본 속도
    [SerializeField] private float scrollSpeed;        // 현재 속도
    [SerializeField] private float speedStep = 0.1f;   // 증가량
    [SerializeField] private float stepInterval = 5f;  // 증가 주기(초)

    [Header("맵 크기 (픽셀 단위)")]
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

        // UIManager 자동 참조
        uiManager = FindObjectOfType<UIManager>();
    }

    void Update()
    {
        // UIManager가 없거나 게임 시작 전이면 멈추고 초기화
        if (uiManager == null || !uiManager.gameStarted)
        {
            scrollSpeed = baseSpeed;
            timer = 0f;
            return;
        }

        // 일정 시간마다 속도 증가
        timer += Time.deltaTime;
        if (timer >= stepInterval)
        {
            scrollSpeed += speedStep;
            timer = 0.0f;
        }

        // 맵 스크롤
        offset.x += scrollSpeed * Time.deltaTime;
        rend.material.mainTextureOffset = offset;
    }
}
