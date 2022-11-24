using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Reflection;

public class Test : MonoBehaviour
{
    Grid grid;


    // Start is called before the first frame update
    void Start()
    {
        grid = new Grid(20, 20, 2f, new Vector3(20, 0));


        grid.desiredCoords.Add(new Tuple<int, int>(11, 0));
        grid.desiredCoords.Add(new Tuple<int, int>(6, 1));
        grid.desiredCoords.Add(new Tuple<int, int>(14, 1));
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            grid.SetValue(UtilsClass.GetMouseWorldPosition(), 1);
        }

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log(grid.GetValue(UtilsClass.GetMouseWorldPosition()));
        }

        if (checkCoords())
        {
            Debug.Log("YES");
        } else
        {
        }

        //0,11 1,14 1,6 4,2 4,9 4,16
    }

    /// <summary>
    /// Iterate through the desired list of coordinates and check if they're in the player's list of coordinates
    /// </summary>
    /// <returns>true if the player's coordinates contain all of the desired coordinates</returns>
    private bool checkCoords()
    {
        return grid.desiredCoords.Intersect(grid.playerCoords).Count() == grid.desiredCoords.Count();
    }
}
