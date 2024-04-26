using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomFightOne : RoomOne
{
    [SerializeField] private List<IO_Door> doors;
    [SerializeField] private int enemyCount; 
    
    protected override void Awake()
    {
        base.Awake();
        foreach (var d in doors)
        {
            OnEnter += d.Close;
        }
    }

    public void CheckEnemyCount()
    {
        enemyCount -= 1;

        if (enemyCount == 0) EndFight();
    }

    protected void EndFight()
    {
        foreach (var d in doors)
        {
            OnEnter -= d.Close;
            d.Open();
        }
    }
}
