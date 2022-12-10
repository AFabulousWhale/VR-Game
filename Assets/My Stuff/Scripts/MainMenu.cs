using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public Fade fade;
    public void Play()
    {
        StartCoroutine(fade.GoToScene("Game"));
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void BackToMenu()
    {
        StartCoroutine(fade.GoToScene("Menu"));
    }
}
