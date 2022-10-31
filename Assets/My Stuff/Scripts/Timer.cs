using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public int time = 300;
    public TextMeshProUGUI text;

    private void Start()
    {
        StartCoroutine(TimeChange());
    }

    IEnumerator TimeChange()
    {
        time -= 1;
        int minutes = Mathf.FloorToInt(time / 60F);
        int seconds = Mathf.FloorToInt(time - minutes * 60);
        text.text = string.Format("{0:0}:{1:00}", minutes, seconds);
        yield return new WaitForSeconds(1);
        if (time > 0)
        {
            StartCoroutine(TimeChange());
        }
    }
}
