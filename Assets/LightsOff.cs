using System;
using System.Collections;
using System.Collections.Generic;
using MiniGames.Scripts;
using UnityEngine;

public class LightsOff : MonoBehaviour
{
    [SerializeField] private Light dir;
    [SerializeField] private BaseMinigame game;

    private void Start()
    {
        game.OnEnd += LightOff;
    }

    public void LightOff()
    {
        dir.enabled = false;
    }
    
    public void LightOn()
    {
        dir.enabled = true;
    }
}
