using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

//using the XRInteractable as a parent so some of the functions can be overrriden
public class ClimbInteractable : XRBaseInteractable
{
    //when the player has grabbed this object which will be called from the direct interactor
    [System.Obsolete]
    protected override void OnSelectEntered(XRBaseInteractor interactor)
    {
        base.OnSelectEntered(interactor);
        //this sets the current climbing hand to the controller being used
        climber.currentClimbingHand = interactor.GetComponent<XRController>();
    }

    [System.Obsolete]
    protected override void OnSelectExited(XRBaseInteractor interactor)
    {
        base.OnSelectExited(interactor);
        //once you've exited, if the hand was the current hand then you need to fall
        if (climber.currentClimbingHand && climber.currentClimbingHand.name == interactor.name)
        {
            climber.currentClimbingHand = null;
        }
    }
}
