using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementCtrl : MovementCtrl
{
    [SerializeField] private float start_speed;

    public void SetSpeed()
    {
        SetSpeed(start_speed);
    }

    public float GetSpeed()
    {
        return start_speed;
    }
}
