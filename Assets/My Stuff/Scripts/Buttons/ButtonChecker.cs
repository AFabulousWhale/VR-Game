using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonChecker : MonoBehaviour
{
    public TextMeshProUGUI text;
    public TextMeshProUGUI codeText;
    public string code;

    private void Awake()
    {
        int codeLength = Random.Range(4, 8); //makes the code a random length between 4 and 7 numbers
        for (int i = 0; i < codeLength; i++)
        {
            int numberToAdd = Random.Range(0, 10); //chooses a random number between 0 and 10
            code += numberToAdd.ToString();
        }
        codeText.text = code;
    }


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
