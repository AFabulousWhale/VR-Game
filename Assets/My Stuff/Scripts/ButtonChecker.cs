using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class ButtonChecker : MonoBehaviour
{
    public UnityEvent Correct, Wrong;
    private string sequence;
    public TextMeshProUGUI text;

    //these functions will get called by the unity events on the button themselves.
    public void AddNumber (int bNumber)
    {
        sequence += bNumber.ToString();
        text.text = sequence;
    }

    public void Checker()
    {
        if(sequence == "69928")
        {
            text.text = "CORRECT";
            Correct.Invoke();
        }
        else
        {
            text.text = "WRONG";
            Wrong.Invoke();
        }
        sequence = "";
    }
}
