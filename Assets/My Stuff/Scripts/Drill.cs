using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Drill : MonoBehaviour
{
    public bool drillActivated;

    GameObject currentScrew;
    public GameObject vent;
    public int screwsUnscrewed;

    private void Update()
    {
        if(drillActivated)
        {
            this.transform.Rotate(Vector3.right * (600 * Time.deltaTime));
        } 

        if(screwsUnscrewed == 4)
        {
            vent.GetComponent<Rigidbody>().isKinematic = false;
            vent.GetComponent<XRGrabInteractable>().enabled = true;
        }
    }

    IEnumerator UnScrew()
    {
        yield return new WaitForSeconds(1.5f);
        Rigidbody rb = currentScrew.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.AddForce(transform.forward * 500);
        screwsUnscrewed++;
    }

    //this is called when the drill is activated by the player's use
    public void Activated()
    {
        drillActivated = true;
    }

    public void DeActivated()
    {
        drillActivated = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Screw" && drillActivated)
        {
            currentScrew = other.gameObject;
            StartCoroutine(UnScrew());
        }
    }
}
