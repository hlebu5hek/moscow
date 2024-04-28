using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSound : MonoBehaviour
{
    public AudioClip openDoor;
    public AudioClip closeDoor;

    public void OpenDoorSound()
    {
        SoundManager.Instance.PlaySoundFX(openDoor, transform.position);
    }
    public void CloseDoorSound()
    {
        SoundManager.Instance.PlaySoundFX(closeDoor, transform.position);
    }
}
