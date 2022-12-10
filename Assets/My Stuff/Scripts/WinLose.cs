using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class WinLose : MonoBehaviour
{
    public Timer timer;

    public Fade fade;

    bool atEnd;

    void Update()
    {
        if (timer.time <= 0)
        {
            Debug.Log("You lose");
            StartCoroutine(fade.GoToScene("Lose"));
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("You won");
            StartCoroutine(fade.GoToScene("Win"));
        }
    }
}
