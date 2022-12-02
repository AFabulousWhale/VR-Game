using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class climber : MonoBehaviour
{
    CharacterController cController;
    public static XRController currentClimbingHand;

    public Vector3 velocity;

    void Start()
    {
        cController = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        //if you have a hand on the step - you are climbing
        if(currentClimbingHand)
        {
            Climb();
        }
    }

    void Climb()
    {
        //listens for an input from the current hand being used to climb controller
        InputDevices.GetDeviceAtXRNode(currentClimbingHand.controllerNode).TryGetFeatureValue(CommonUsages.deviceVelocity, out velocity);

        //applies the opposite velocity to the player of the hand
        cController.Move(transform.rotation * -velocity * Time.fixedDeltaTime);
    }
}
