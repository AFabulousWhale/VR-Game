using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireCutterUse : MonoBehaviour
{
    public bool activated;
    public GameObject blackoutPP;

    //these are triggered by the activation on the wire cutter in the XR Grabable component script using unity events
    public void ActivateTrigger()
    {
        StartCoroutine(Activate());
    }
    public void DeactivateTrigger()
    {
        StartCoroutine(Deactivate());
    }
    public IEnumerator Activate()
    {
        activated = true;
        //cycling through all the children
        //repeats 10 times
        for (int i = 0; i < 10; i++)
        {
            foreach (Transform child in this.transform)
            {
                //rotation
                if (child.name == "Left_Back" || child.name == "Right_Front")
                {
                    Vector3 rotationToAdd = new Vector3(0, -1, 0);
                    child.transform.Rotate(rotationToAdd);
                    //rotate -10
                }
                if (child.name == "Right_Back" || child.name == "Left_Front")
                {
                    Vector3 rotationToAdd = new Vector3(0, 1, 0);
                    child.transform.Rotate(rotationToAdd);
                    //rotate 10
                }
            }
            yield return new WaitForSeconds(0.01f);
        }
    }

    public IEnumerator Deactivate()
    {
        activated = false;
        //cycling through all the children
        //repeats 10 times
        for (int i = 0; i < 10; i++)
        {
            foreach (Transform child in this.transform)
            {
                if (child.name == "Left_Back" || child.name == "Right_Front")
                {
                    Vector3 rotationToAdd = new Vector3(0, 1, 0);
                    child.transform.Rotate(rotationToAdd);
                }
                if (child.name == "Right_Back" || child.name == "Left_Front")
                {
                    Vector3 rotationToAdd = new Vector3(0, -1, 0);
                    child.transform.Rotate(rotationToAdd);
                }
            }

            yield return new WaitForSeconds(0.01f);
        }
    }


    bool blackout = false;
    void OnTriggerEnter(Collider other)
    {
        if (activated)
        {
            if (other.tag == "RedWire")
            {
                other.GetComponent<Rigidbody>().isKinematic = false;
            }
            if (other.tag == "BlueWire" && !blackout)
            {
                StartCoroutine(Blackout());
                other.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }

    IEnumerator Blackout()
    {
        blackout = true;
        blackoutPP.gameObject.SetActive(true);
        yield return new WaitForSeconds(5);
        blackout = false;
        blackoutPP.gameObject.SetActive(false);
    }
}
