using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LookClick : MonoBehaviour
{
    public UnityEvent OnLookClick;
    bool isLooking = false;
    public float lookSpeed = 10;
    public void StartedLooking()
    {
        isLooking = true;
    }
    public void StoppedLooking()
    {
        isLooking = false;
        Inventory.instance.lookSlider.fillAmount = 0;
    }
    private void Update()
    {
        if (isLooking)
        {
            Inventory.instance.lookSlider.fillAmount = Mathf.Lerp(Inventory.instance.lookSlider.fillAmount, 1, Time.deltaTime * lookSpeed);
            if (Inventory.instance.lookSlider.fillAmount > 0.99f)
            {
                OnLookClick.Invoke();
                Inventory.instance.lookSlider.fillAmount = 0;
            }
        }
    }
}