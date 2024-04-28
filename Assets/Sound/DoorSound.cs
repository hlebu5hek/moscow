using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSound : MonoBehaviour
{
    public AudioSource Source;
    
    public AudioClip openDoor;
    public AudioClip closeDoor;

    public void OpenDoorSound()
    {
        Source.clip = openDoor;
        Source.Play();
    }
    public void CloseDoorSound()
    {
        Source.clip = closeDoor;
        Source.Play();
    }
}
