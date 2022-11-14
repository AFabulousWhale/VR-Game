using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireCutterUse : MonoBehaviour
{
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

                //moving so the parts are connected more
                if (child.name == "Right_Back" || child.name == "Left_Back")
                {
                    Vector3 toMove = new Vector3(child.transform.position.x, child.transform.position.y, child.transform.position.z + 0.00573216f);
                    child.transform.position = toMove;
                }
                if (child.name == "Right_Front" || child.name == "Left_Front")
                {
                    Vector3 toMove = new Vector3(child.transform.position.x, child.transform.position.y, child.transform.position.z - 0.00576782f);
                    child.transform.position = toMove;
                }
            }
            yield return new WaitForSeconds(0.01f);
        }
    }

    public IEnumerator Deactivate()
    {
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

                if (child.name == "Right_Back" || child.name == "Left_Back")
                {
                    Vector3 toMove = new Vector3(child.transform.position.x, child.transform.position.y, child.transform.position.z - 0.00573216f);
                    child.transform.position = toMove;
                }
                if (child.name == "Right_Front" || child.name == "Left_Front")
                {
                    Vector3 toMove = new Vector3(child.transform.position.x, child.transform.position.y, child.transform.position.z + 0.00576782f);
                    child.transform.position = toMove;
                }
            }

            yield return new WaitForSeconds(0.01f);
        }
    }
}
