using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTrigger : MonoBehaviour
{
    public int hitWindmills;

    private void Update()
    {
        if(hitWindmills == 4)
        {
            Debug.Log("YAY");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Windmill")
        {
            if(!other.GetComponent<Windmill>().hit)
            {
                other.GetComponent<Windmill>().hit = true;
                hitWindmills++;
            }
        }
    }

}
