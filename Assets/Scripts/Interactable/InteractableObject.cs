using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
     [SerializeField] protected RoomOne room;
     [SerializeField] private Outline _outline;
     
     public Action OnMouseEnter, OnMouseExit, OnPlayerEnter, OnPlayerExit, OnInteractMouse, OnInteractE;

     protected virtual void Awake()
     {
          OnPlayerEnter += ShowOutline;
          OnPlayerExit += HideOutline;
          
          HideOutline();
     }
     
     protected void ShowOutline()
     {
          if(_outline)
               _outline.enabled = true;
     }
    
     protected void HideOutline()
     {
          if(_outline)
               _outline.enabled = false;
     }

     protected virtual void OnTriggerEnter(Collider other)
     {
          OnPlayerEnter?.Invoke();
          PlayerInteracter.PI.SetInteractableObject(this, false);
     }

     protected virtual void OnTriggerExit(Collider other)
     {
          OnPlayerExit?.Invoke();
          PlayerInteracter.PI.ResetInteractableObject(this);
     }
}
