using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Windmill : MonoBehaviour
{
    public bool hit;

    // Update is called once per frame
    void Update()
    {
        if(hit)
        {
            SpinWindmill();
        }
    }

    void SpinWindmill()
    {
        this.transform.Rotate(Vector3.forward * (350 * Time.deltaTime));
    }
}
