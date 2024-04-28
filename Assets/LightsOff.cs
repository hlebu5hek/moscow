using System;
using System.Collections;
using System.Collections.Generic;
using MiniGames.Scripts;
using UnityEngine;

public class LightsOff : MonoBehaviour
{
    [SerializeField] private List<GameObject> dir;
    [SerializeField] private GameObject torch;
    [SerializeField] private BaseMinigame game;

    private void Start()
    {
        game.OnEnd += LightOff;
    }

    public void LightOff()
    {
        foreach (var d in dir)
        {
            d.SetActive(false);
        }
        torch.SetActive(true);
    }
    
    public void LightOn()
    {
        foreach (var d in dir)
        {
            try
            {
                d.SetActive(true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        torch.SetActive(false);
    }
}
