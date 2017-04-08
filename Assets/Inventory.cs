using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Inventory : MonoBehaviour {
    public GameObject visualKeycardBlue;

    public static Inventory instance;
    public Image lookSlider;
    // Use this for initialization
    void Start()
    {
        instance = this;
    }

    public void PickedKeycardBlue(GameObject picked)
    {
        Destroy(picked);
        visualKeycardBlue.SetActive(true);
    }

}
