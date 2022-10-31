using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public enum HandType
{
    Left,
    Right
}
public class HandManager : MonoBehaviour
{
    public HandType handType;
    public float thumbMoveSpeed = 0.1f;

    private Animator animator;
    private InputDevice inputDevice;

    //these are the same values that are used within the animator for the hand model
    private float indexValue;
    private float thumbValue;
    private float threeFingersValue;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //keep trying to update the list until it contains something
        if (inputDevice != null)
        {
            inputDevice = GetInputDevice();
        }
        AnimateHand();
    }

    InputDevice GetInputDevice()
    {
        //the device that the player is using will be a Quest 2 controller (held in hand)
        InputDeviceCharacteristics controllerCharacteristic = InputDeviceCharacteristics.HeldInHand;

        //setting the characteristc of the controller to left or right depending on what hand it is
        if (handType == HandType.Left)
        {
            controllerCharacteristic = controllerCharacteristic | InputDeviceCharacteristics.Left;
        }
        else
        {
            controllerCharacteristic = controllerCharacteristic | InputDeviceCharacteristics.Right;
        }

        List<InputDevice> inputDevices = new List<InputDevice>();
        //the controller is equal to the device with the set characteristics above
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristic, inputDevices);

        return inputDevices[0];
    }

    void AnimateHand()
    {
        //this will set the indexValue to how much you are pressing the trigger button so it knows how much to animate the hand
        inputDevice.TryGetFeatureValue(CommonUsages.trigger, out indexValue);
        inputDevice.TryGetFeatureValue(CommonUsages.grip, out threeFingersValue);

        inputDevice.TryGetFeatureValue(CommonUsages.primaryTouch, out bool primaryTouched);
        inputDevice.TryGetFeatureValue(CommonUsages.secondaryTouch, out bool secondaryTouched);

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
}
