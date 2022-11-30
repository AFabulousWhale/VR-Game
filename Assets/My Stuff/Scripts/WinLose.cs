using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLose : MonoBehaviour
{
    public Timer timer;

    bool atEnd;

    void Update()
    {
        //if (timer.time <= 0)
        //{
        //    Debug.Log("You lose");
        //    SceneManager.LoadScene("Lose");
        //}
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("You won");
            SceneManager.LoadScene("Win");
        }
    }
}
