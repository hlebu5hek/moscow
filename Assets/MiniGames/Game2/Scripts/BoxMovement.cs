using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMovement : MonoBehaviour
{
    public float speedMovement = 3;
    public RectTransform borders;
    private RectTransform selfRect;

    private void Awake()
    {
        selfRect = GetComponent<RectTransform>();
    }

    private void Update()
    {
        Move(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
    }

    private void Move(Vector2 delta)
    {
        
        transform.Translate(delta * Time.deltaTime * speedMovement);
        if (selfRect.anchoredPosition.x < -borders.sizeDelta.x / 2 + selfRect.sizeDelta.x / 2)
        {
            selfRect.anchoredPosition = new Vector2(-borders.sizeDelta.x / 2 + selfRect.sizeDelta.x / 2 + 1, selfRect.anchoredPosition.y);
        }
        if (selfRect.anchoredPosition.x > borders.sizeDelta.x / 2 - selfRect.sizeDelta.x / 2)
        {
            selfRect.anchoredPosition = new Vector2(borders.sizeDelta.x / 2 - selfRect.sizeDelta.x / 2 - 1, selfRect.anchoredPosition.y);
        }
        
        if (selfRect.anchoredPosition.y < -borders.sizeDelta.y / 2 + selfRect.sizeDelta.y / 2)
        {
            selfRect.anchoredPosition = new Vector2(selfRect.anchoredPosition.x, -borders.sizeDelta.y / 2 + selfRect.sizeDelta.y / 2 + 1);
        }
        if (selfRect.anchoredPosition.y > borders.sizeDelta.y / 2 - selfRect.sizeDelta.y / 2)
        {
            selfRect.anchoredPosition = new Vector2(selfRect.anchoredPosition.x, borders.sizeDelta.y / 2 - selfRect.sizeDelta.y / 2 - 1);
        }
    }
}
