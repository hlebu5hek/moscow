using System;
using System.Collections;
using System.Collections.Generic;
using MiniGames.Scripts;
using UnityEngine;

public class GameBoxController : MonoBehaviour
{
    private BaseMinigame _baseMinigame;

    public RectTransform box;
    public RectTransform[] zones;
    public int currentIndexZone;
    public float inZone = 0;
    public float requestZone = 3;

    public ProgressBar _progressBar;
    public RectTransform CurrentZone => zones[currentIndexZone];

    private void Awake()
    {
        _baseMinigame = GetComponentInParent<BaseMinigame>();
    }

    private void Update()
    {
        if (rectOverlaps(CurrentZone, box))
        {
            if (inZone < requestZone)
            {
                inZone += Time.deltaTime;
                _progressBar.SetProgress((currentIndexZone + inZone / requestZone) / zones.Length);
            }
            else
            {
                NextZone();
            }
        }
    }

    private void NextZone()
    {
        if (currentIndexZone + 1 < zones.Length)
        {
            CurrentZone.gameObject.SetActive(false);
            currentIndexZone++;
            CurrentZone.gameObject.SetActive(true);
            inZone = 0;
        }
        else
        {
            _baseMinigame.FinishGame();
        }
    }
    
    bool rectOverlaps(RectTransform rectTrans1, RectTransform rectTrans2)
    {
        Rect rect1 = new Rect(rectTrans1.localPosition.x, rectTrans1.localPosition.y, rectTrans1.rect.width, rectTrans1.rect.height);
        Rect rect2 = new Rect(rectTrans2.localPosition.x, rectTrans2.localPosition.y, rectTrans2.rect.width, rectTrans2.rect.height);

        return rect1.Overlaps(rect2);
    }
}