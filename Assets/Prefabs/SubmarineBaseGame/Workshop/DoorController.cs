using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {
    bool Open = false;
    // Use this for initialization
    public Transform SlidingDoors;
    public void ToggleDoor()
    {
        if (Inventory.instance.visualKeycardBlue.activeInHierarchy)
        {
            Open = !Open;
            SlidingDoors.gameObject.SetActive(!Open);
        }
    }
}
