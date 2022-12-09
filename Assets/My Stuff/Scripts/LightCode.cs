using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LightCode : MonoBehaviour
{
    public bool maskOn;
    public bool batteryIn;

    public GameObject spotLight;
    public GameObject green;
    public TextMeshProUGUI message;

    TextMeshProUGUI messageComponent;

    private void Start()
    {
        messageComponent = message.GetComponent<TextMeshProUGUI>();
    }

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
            messageComponent.enabled = true;
        }
        else
        {
            messageComponent.enabled = false;
        }
    }
}
