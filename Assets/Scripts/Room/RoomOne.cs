using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomOne : MonoBehaviour
{
    [SerializeField] private GameObject props, walls, floor;
    [SerializeField] private List<Door> doors;
    [SerializeField] private bool start;
    
    public Action OnEnter, OnExit;

    protected virtual void Awake()
    {
        props = transform.Find("Props").gameObject;
        floor = transform.Find("Floor").gameObject;
        walls = transform.Find("Walls").gameObject;

        if (start)
        {
            Enter();
            foreach (var d in doors)
            {
                d.Rooms += 1;
                if (!d.gameObject.activeInHierarchy)
                {
                    d.gameObject.SetActive(true);
                }
            }
        }
        else Exit();
    }
    private void OnTriggerEnter(Collider other)
    {
        Enter();
    }
    
    private void OnTriggerExit(Collider other)
    {
        Exit();
    }

    protected virtual void Enter()
    {
        foreach (var d in doors)
        {
            d.Rooms += 1;
            if (!d.gameObject.activeInHierarchy)
            {
                d.gameObject.SetActive(true);
            }
        }
        props.SetActive(true);
        walls.SetActive(true); //TODO: remove later
        OnEnter?.Invoke();
    }

    protected virtual void Exit()
    {
        foreach (var d in doors)
        {
            d.Rooms -= 1;
            d.CheckRoomExit();
        }
        props.SetActive(false);
        walls.SetActive(false); //TODO: remove later
        OnExit?.Invoke();
    }
}
