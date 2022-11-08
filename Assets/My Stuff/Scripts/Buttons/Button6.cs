using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button6 : ButtonChecker
{
    bool deadTimeActive = false;
    float deadTime = 0.4f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Button" && !deadTimeActive)
        {
            Debug.Log($"{this.gameObject} has been pressed");
            base.AddNumber(6);
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
}
