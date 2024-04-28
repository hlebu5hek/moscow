using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPLayerPos : MonoBehaviour
{
    public void Set()
    {
        PlayerMovementCtrl.PMC.gameObject.transform.position = transform.position;
    }
}
