using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Test : MonoBehaviour
{
    Grid grid;
    // Start is called before the first frame update
    void Start()
    {
        grid = new Grid(20, 20, 2f, new Vector3(20, 0));
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            grid.SetValue(UtilsClass.GetMouseWorldPosition(), 1);
            Debug.Log(UtilsClass.GetMouseWorldPosition());
        }

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log(grid.GetValue(UtilsClass.GetMouseWorldPosition()));
        }
    }

}
