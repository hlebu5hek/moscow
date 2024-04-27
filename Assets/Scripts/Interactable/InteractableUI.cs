using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableUI : MonoBehaviour
{
    [SerializeField] private IO_UIOpener parent;
    
    //Voids
    public void SetParentUIOpener(IO_UIOpener par)
    {
        parent = par;
    }
}
