using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterButton : ButtonChecker
{
    bool deadTimeActive = false;
    float deadTime = 0.4f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Button" && !deadTimeActive)
        {
            Debug.Log($"{this.gameObject} has been pressed");
            Checker();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Button" && !deadTimeActive)
        {
            Debug.Log($"{this.gameObject} has been released");
            StartCoroutine(WaitForDeadTime());
        }
    }

    //locks button activity for X seconds so it cannot be pressed constantly
    IEnumerator WaitForDeadTime()
    {
        deadTimeActive = true;
        yield return new WaitForSeconds(deadTime);
        deadTimeActive = false;
    }

    public void Checker()
    {
        //checks if the sequence submitted once pressed the enter button is the correct code specified below
        if (base.text.text == "69928")
        {
            base.text.text = "CORRECT";
        }
        else
        {
            base.text.text = "WRONG";
        }
    }
}
