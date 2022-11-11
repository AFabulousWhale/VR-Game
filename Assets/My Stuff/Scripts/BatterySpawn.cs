using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatterySpawn : MonoBehaviour
{
    public GameObject electricity;
    public GameObject battery;

    public Consumable consumable;

    bool isSpawned = false;

    void Update()
    {
        if(consumable.isFinished && !isSpawned)
        {
            StartCoroutine(SpawnBattery());
        }
    }

    IEnumerator SpawnBattery()
    {
        isSpawned = true;
        GameObject newItem = Instantiate(electricity, this.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2.5f);
        Destroy(newItem);
        newItem = Instantiate(battery, this.transform.position, Quaternion.identity);
        Rigidbody rb = newItem.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 5);
    }
}
