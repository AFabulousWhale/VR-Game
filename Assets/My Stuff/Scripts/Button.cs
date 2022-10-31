using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    public UnityEvent onPress;
    public UnityEvent onRelease;
    bool isPressed = false;
    GameObject presser;

    private void OnTriggerEnter(Collider other)
    {
        if (!isPressed)
        {
            presser = other.gameObject;
            this.transform.localPosition = new Vector3(0.01312256f, 0, 0);
            isPressed = true;
            onPress.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == presser && isPressed)
        {
            this.transform.localPosition = new Vector3(0, 0, 0);
            isPressed = false;
            onRelease.Invoke();
        }
    }

    public void Test()
    {
        Debug.Log($"pressed {this.gameObject}");
    }
}
