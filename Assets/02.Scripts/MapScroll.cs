using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class MapScroll : MonoBehaviour
{
    [Header("스크롤 설정")]
    [SerializeField] private float scrollSpeed = 0.2f;
    [SerializeField] private float speedStep = 0.1f;
    [SerializeField] private float stepInterval = 5f;

    [Header("맵 크기 (픽셀 단위)")]
    [SerializeField] private float mapWidth = 1280f;
    [SerializeField] private float mapHeight = 720f;

    private Renderer rend;
    private Vector2 offset;
    private float timer;

    void Start()
    {
        rend = GetComponent<Renderer>();
        offset = Vector2.zero;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= stepInterval)
        {
            scrollSpeed += speedStep;
            timer = 0.0f;
        }

        offset.x += scrollSpeed * Time.deltaTime;
        rend.material.mainTextureOffset = offset;
    }
}

