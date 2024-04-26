using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
     [SerializeField] protected RoomOne room;
     
     public Action OnMouseEnter, OnMouseExit, OnPlayerEnter, OnPlayerExit, OnInteractMouse, OnInteractE;

     protected virtual void Awake()
     {
          
     }

     private void OnTriggerEnter(Collider other)
     {
          OnPlayerEnter?.Invoke();
          PlayerInteracter.PI.SetInteractableObject(this, false);
     }

     private void OnTriggerExit(Collider other)
     {
          OnPlayerExit?.Invoke();
          PlayerInteracter.PI.ResetInteractableObject(this);
     }
}
