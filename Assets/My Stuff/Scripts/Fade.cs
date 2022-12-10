using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
    public bool fadeOnStart;
    public float fadeDuration = 1.5f;
    public Color fadeColor;
    public Renderer rend; //is assigned in the inspector
    // Start is called before the first frame update
    void Start()
    {
        if(fadeOnStart)
        {
            FadeIn();
        }
    }

    public void FadeIn()
    {
        FadeMain(1,0);
    }

    public void FadeOut()
    {
        FadeMain(0, 1);
    }

    public void FadeMain(float alphaIn, float alphaOut)
    {
        StartCoroutine(FadeRoutine(alphaIn, alphaOut));
    }

    public IEnumerator FadeRoutine(float alphaIn, float alphaOut)
    {
        float timer = 0;
        //makes timer go up every second until it reaches the fadeDuration amount
        while(timer <= fadeDuration)
        {
            Color newColor = fadeColor;
            newColor.a = Mathf.Lerp(alphaIn, alphaOut, timer / fadeDuration);
            rend.material.SetColor("_Color", newColor);
            timer += Time.deltaTime;
            yield return null;
        }
        Color newColor2 = fadeColor;
        newColor2.a = Mathf.Lerp(alphaIn, alphaOut, timer / fadeDuration);
        rend.material.SetColor("_Color", newColor2);
    }

    //will be called from the scripts that change scenes
    public IEnumerator GoToScene(string sceneName)
    {
        FadeOut();
        yield return new WaitForSeconds(fadeDuration);
        SceneManager.LoadScene(sceneName);
    }
}
