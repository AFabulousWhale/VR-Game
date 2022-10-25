using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAnim : MonoBehaviour
{
    Animator anim;

    int paramLength;

    int randomWaitTime;
    int randomAnim;
    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        paramLength = anim.parameters.Length;
        ReRandomise();
    }

    void ReRandomise()
    {
       //picks a random time between 10 and 20 seconds
       randomWaitTime = Random.Range(10, 21);
       //picks a random anim parameter between index 0 and the length of parameters
       randomAnim = Random.Range(0, paramLength);
       StartCoroutine(WaitTime());
    }

    IEnumerator WaitTime()
    {
        anim.SetBool(anim.parameters[randomAnim].name, true);
        yield return new WaitForSeconds(randomWaitTime);
        anim.SetBool(anim.parameters[randomAnim].name, false);
        ReRandomise();
    }

    //get the number of booleans in anim

    //random number for wait time
    //random number of length of bools
    //wait that time before changing animation
    //repeat
}
