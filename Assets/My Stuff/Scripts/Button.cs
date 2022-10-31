using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    //using unity event systems so it can call other functions when pressed/released
    public UnityEvent onPress, onRelease;
    bool deadTimeActive = false;
    float deadTime = 0.4f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Button" && !deadTimeActive)
        {
            Debug.Log($"{this.gameObject} has been pressed");
            onPress.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Button" && !deadTimeActive)
        {
            Debug.Log($"{this.gameObject} has been released");
            onRelease.Invoke();
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
