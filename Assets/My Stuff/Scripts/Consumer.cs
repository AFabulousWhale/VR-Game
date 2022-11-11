using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //if you collide with something that has the consumable script then it won't be null
        Consumable consumable = other.GetComponent<Consumable>();
        if(consumable != null && !consumable.isFinished)
        {
            consumable.Consume();
        }
    }
}
