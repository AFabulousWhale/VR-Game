using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonChecker : MonoBehaviour
{
    public TextMeshProUGUI text;

    //these functions will get called by the unity events on the button themselves.
    public void AddNumber (int buttonNumber)
    {
        //resetting the text after pressing the enter button
        if(this.text.text == "CORRECT" || this.text.text == "WRONG")
        {
            this.text.text = "";
        }
        this.text.text += buttonNumber.ToString();
    }
}
