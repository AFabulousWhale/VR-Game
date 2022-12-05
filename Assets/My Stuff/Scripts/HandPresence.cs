using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{
    public InputDeviceCharacteristics controllerCharacteristics;    
    private InputDevice targetDevice;
    public Animator animator;

    public GameObject thisHand;
    bool grabbedObject;

    //these are the same values that are used within the animator for the hand model
    public float indexValue;
    public float thumbValue;
    public float threeFingersValue;

    public float thumbMoveSpeed = 0.1f;

    void Start()
    {
        TryInitialize();
    }

    void TryInitialize()
    {
        List<InputDevice> devices = new List<InputDevice>();

        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);
        if (devices.Count > 0)
        {
            targetDevice = devices[0];
        }
    }

    void UpdateHandAnimation()
    {
        //this will set the indexValue to how much you are pressing the trigger button so it knows how much to animate the hand
        targetDevice.TryGetFeatureValue(CommonUsages.trigger, out indexValue);
        targetDevice.TryGetFeatureValue(CommonUsages.grip, out threeFingersValue);

        targetDevice.TryGetFeatureValue(CommonUsages.primaryTouch, out bool primaryTouched);
        targetDevice.TryGetFeatureValue(CommonUsages.secondaryTouch, out bool secondaryTouched);

        //if you're touching the buttons on the controller it'll detect thumb input
        if (primaryTouched || secondaryTouched)
        {
            thumbValue += thumbMoveSpeed;
        }
        else
        {
            thumbValue -= thumbMoveSpeed;
        }

        thumbValue = Mathf.Clamp(thumbValue, 0, 1);

        //setting the index float on the animator to the value of how much you have pressed it
        animator.SetFloat("Index", indexValue);
        animator.SetFloat("ThreeFingers", threeFingersValue);
        animator.SetFloat("Thumb", thumbValue);
    }

    // Update is called once per frame
    void Update()
    {
        if(!targetDevice.isValid)
        {
            TryInitialize();
        }
        else
        {
            UpdateHandAnimation();
        }
        if(!thisHand.activeSelf)
        {
            grabbedObject = true;
        }
        if(grabbedObject && thisHand.activeSelf)
        {
            grabbedObject = false;
            //resets all the values when the hand is back after grabbing an object
            animator.SetFloat("Index", 0);
            animator.SetFloat("ThreeFingers", 0);
            animator.SetFloat("Thumb", 0);
        }
    }
}
