using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drill : MonoBehaviour
{
    public bool drillActivated;
    public bool unScrewing;

    GameObject currentScrew;
    public GameObject vent;
    public int screwsUnscrewed;

    private void Update()
    {
        if(drillActivated)
        {
            this.transform.Rotate(Vector3.right * (600 * Time.deltaTime));
        } 
        if(unScrewing)
        {
            currentScrew.transform.Rotate(Vector3.right * (450 * Time.deltaTime));
            Vector3 newPos = new Vector3(29.7163f, currentScrew.transform.position.y, currentScrew.transform.position.z);
            currentScrew.transform.position = Vector3.MoveTowards(currentScrew.transform.position, newPos, Time.deltaTime);

            if(currentScrew.transform.position == newPos)
            {
                currentScrew.GetComponent<Rigidbody>().isKinematic = false;
                screwsUnscrewed++;
                unScrewing = false;
            }
        }

        if(screwsUnscrewed == 4)
        {
            vent.GetComponent<Rigidbody>().isKinematic = false;
        }
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
            unScrewing = true;
        }
        else
        {
            unScrewing = false;
        }
    }
}
