using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderSummon : MonoBehaviour
{
    public GameObject vent;
    public GameObject ladder;
    public static bool ventActivate;
    bool ladderActivate;

    private void Update()
    {
        //will be true until the vent is open enough for the ladder to fall
        if(ventActivate)
        {
            //repeat until the vent is open at a 90 degree angle
            for (int i = 0; i < 1350; i++)
            {
                vent.transform.Rotate(Vector3.right * (-10 * Time.deltaTime));
            }
            ventActivate = false;
            ladderActivate = true;
        }

        if(ladderActivate)
        {
            Vector3 newLadderPos = new Vector3(ladder.transform.position.x, 0.4588785f, ladder.transform.position.z);
            ladder.transform.position = Vector3.MoveTowards(ladder.transform.position, newLadderPos, 0.5f);
        }
    }
}
