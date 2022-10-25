using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPresencePhysics : MonoBehaviour
{

    public Transform target;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //gets the position
        rb.velocity = (target.position - transform.position) / Time.deltaTime;

        //gets the rotation
        rb.rotation = target.rotation;
    }
}
