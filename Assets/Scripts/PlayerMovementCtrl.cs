using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovementCtrl : MovementCtrl
{
    [SerializeField] private Transform _target;
    [SerializeField] private LayerMask _raycast, _interact;
    private Camera cam;

    public KeyCode Forward = KeyCode.W,
        Backward = KeyCode.S,
        Left = KeyCode.A,
        Right = KeyCode.D;

    public static PlayerMovementCtrl PMC;
    public bool freezed;
    
    protected void Awake()
    {
        PMC = this;
        
        cam = Camera.main;
        _target.SetParent(null);
        GameManager.Upd += CheckInput;
        GameManager.FxUpd += GetMousePosition;
    }

    private void CheckInput()
    {
        if (freezed) return;
        
        if (Input.GetKeyDown(Forward)) AddVector(new(1, 1));
        if (Input.GetKeyUp(Forward)) AddVector(new(-1, -1));
        if (Input.GetKeyDown(Backward)) AddVector(new(-1, -1));
        if (Input.GetKeyUp(Backward)) AddVector(new(1, 1));
        if (Input.GetKeyDown(Left)) AddVector(new(-1, 1));
        if (Input.GetKeyUp(Left)) AddVector(new(1, -1));
        if (Input.GetKeyDown(Right)) AddVector(new(1, -1));
        if (Input.GetKeyUp(Right)) AddVector(new(-1, 1));
        if(Input.GetKeyDown(KeyCode.Escape)) SetVector(Vector2.zero);

        LookForward();
        // Rotate(_target, true);

        Move();
    }


    private void GetMousePosition()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, 100, _interact))
        {
            _target.position = hit.collider.gameObject.transform.position;
            InteractableObject io = hit.collider.gameObject.GetComponent<InteractableObject>();
            io.OnMouseEnter?.Invoke();
            PlayerInteracter.PI.SetInteractableObject(io, true);
        }
        else
        {
            PlayerInteracter.PI.ResetInteractableObject(null);
        }
    }
}