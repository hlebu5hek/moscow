using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovementCtrl : MovementCtrl
{
    [SerializeField] private LayerMask _raycast, _interact;

    public static PlayerMovementCtrl PMC;
    public bool freezed;
    
    protected override void Awake()
    {
        base.Awake();

        PMC = this;
        GameManager.Upd += CheckInput;
    }

    private void CheckInput()
    {
        if (freezed) return;

        if (Input.GetKey(GameManager.gm.input["forward"])) AddVector(new(1, 1));
        else AddVector(new(-1, -1));
        if (Input.GetKey(GameManager.gm.input["backward"])) AddVector(new(-1, -1));
        else AddVector(new(1, 1));
        if (Input.GetKey(GameManager.gm.input["left"])) AddVector(new(-1, 1));
        else AddVector(new(1, -1));
        if (Input.GetKey(GameManager.gm.input["right"])) AddVector(new(1, -1));
        else AddVector(new(-1, 1));
        CheckWrongInput();

        Move();
    }

    private void CheckWrongInput()
    {
        Vector2 check = Vector2.zero;
        if (Input.GetKey(GameManager.gm.input["forward"])) check += new Vector2(1, 1);
        else check += (new Vector2(-1, -1));
        if (Input.GetKey(GameManager.gm.input["backward"])) check += (new Vector2(-1, -1));
        else check += (new Vector2(1, 1));
        if (Input.GetKey(GameManager.gm.input["left"])) check += (new Vector2(-1, 1));
        else check += (new Vector2(1, -1));
        if (Input.GetKey(GameManager.gm.input["right"])) check += (new Vector2(1, -1));
        else check += (new Vector2(-1, 1));

        if (check != _vector) SetVector(check);
    }
}