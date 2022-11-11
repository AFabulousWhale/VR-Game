using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : MonoBehaviour
{
    public GameObject[] parts;
    public int index = 0;

    public AudioSource eat;

    //if the index is the end of the array (you finished eating) then isFinished will be true
    public bool isFinished => index == parts.Length;
    void Start()
    {
        SetVisuals();
    }

    //for testing without the VR headset - can call the function from the inspector
    [ContextMenu("Consume")]

    public void Consume()
    {
        if(!isFinished)
        {
            index++;
            SetVisuals();
            eat.Play();
        }
    }

    void SetVisuals()
    {
        for (int i = 0; i < parts.Length; i++)
        {
            //set that specific part of the food to active if the index is the same as i (that index in the array)
            parts[i].SetActive(i == index);
        }
    }
}
