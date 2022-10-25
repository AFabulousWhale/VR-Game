using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMovement : MonoBehaviour
{
    public Animator anim;
    int walktoPos = 2;

    public GameObject pos1;
    public GameObject pos2;

    public float rotateDir;

    public AudioSource footStep;
    void Update()
    {
        //when the turning animation is finished
        if (!anim.GetBool("turning"))
        {
            //walk to one position
            if (walktoPos == 1)
            {
                this.transform.LookAt(pos1.transform.position);
                this.transform.position = Vector3.MoveTowards(this.transform.position, pos1.transform.position, Time.deltaTime * 1f);
            }
            //walk to the other position
            else if (walktoPos == 2)
            {
                this.transform.LookAt(pos2.transform.position);
                this.transform.position = Vector3.MoveTowards(this.transform.position, pos2.transform.position, Time.deltaTime * 1f);
            }

            //if you have reached the position change to the other one
            if (this.transform.position == pos1.transform.position)
            {
                walktoPos = 2;
                anim.SetBool("turning", true);
            }
            else if (this.transform.position == pos2.transform.position)
            {
                walktoPos = 1;
                anim.SetBool("turning", true);
            }
        }
        else
        {
            //stop moving if turning around
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Turn") &&
anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
            {
                anim.SetBool("turning", false);
            }
        }
    }

    public void FootSteps()
    {
        footStep.Play();
    }
}
