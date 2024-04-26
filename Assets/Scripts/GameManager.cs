using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public static Action Upd, FxUpd;

    private void Awake()
    {
        gm = this;
    }

    public void Update()
    {
        Upd?.Invoke();
    }

    public void FixedUpdate()
    {
        FxUpd?.Invoke();
    }
}
