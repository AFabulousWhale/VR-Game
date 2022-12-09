using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireCutterUse : MonoBehaviour
{
    public bool activated;
    public GameObject blackoutPP;
    bool correctWireCut = false;

    public GameObject ball;
    public GameObject spawnEffect;
    public GameObject ballSpawner;

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
        if (activated && !correctWireCut)
        {
            if (other.tag == "RedWire")
            { //spawns a ball when you cut the red wire and makes it so the other wires can't be cut
                other.GetComponent<Rigidbody>().isKinematic = false;
                GameObject newBall = Instantiate(ball, this.transform.position, Quaternion.identity);
                Rigidbody rb = newBall.GetComponent<Rigidbody>();
                rb.AddForce(transform.forward * 500);
                GameObject newEffect = Instantiate(spawnEffect, newBall.transform.position, Quaternion.identity);
                ballSpawner.SetActive(true);
                correctWireCut = true;
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
