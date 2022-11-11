using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCode : MonoBehaviour
{
    public bool maskOn;
    public bool batteryIn;

    public GameObject spotLight;
    public GameObject green;
    public GameObject message;

    //these two are being called by unity events on the socket components that they are supposed to lock in to
    public void BatteryInPlace(bool battery)
    {
        batteryIn = battery;
    }
    public void WearingMask(bool mask)
    {
        maskOn = mask;
    }

    void Update()
    {
        ShowGreen();
        ShowLight();
        ShowMessage();
    }

    void ShowGreen()
    {
        green.SetActive(maskOn);
    }

    void ShowLight()
    {
        spotLight.SetActive(batteryIn);
    }

    void ShowMessage()
    {
        if (batteryIn && maskOn)
        {
            message.SetActive(true);
        }
        else
        {
            message.SetActive(false);
        }
    }
}
