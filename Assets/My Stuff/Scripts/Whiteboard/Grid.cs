using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using CodeMonkey.Utils;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Reflection;

public class Grid
{
    int width;
    int height;
    int[,] gridArray;
    TextMesh[,] debugTextArray;
    float cellSize;
    Vector3 originPosition;

    public List<Tuple<int, int>> desiredCoords = new List<Tuple<int, int>>();
    public List<Tuple<int, int>> playerCoords = new List<Tuple<int, int>>();

    //using a constructor to declare these variables for the overall grid values
    public Grid(int width, int height, float cellSize, Vector3 originPosition)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPosition = originPosition;

        gridArray = new int[width,height];
        //purley for testing purposes to see if the grid works visually
        debugTextArray = new TextMesh[width, height];

        //setting up visuals for the grid
        //cycles through the first dimension of the array
        for (int z = 0; z < gridArray.GetLength(0); z++)
        {
            //cycles through the second dimension of the array
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                //debugTextArray[z, y] = UtilsClass.CreateWorldText(gridArray[z, y].ToString(), null, GetWorldPosition(z, y) + new Vector3(cellSize, cellSize) * 0.5f, 3, Color.white, TextAnchor.MiddleCenter);
                Debug.DrawLine(GetWorldPosition(z, y), GetWorldPosition(z, y + 1), Color.white, 100f);
                Debug.DrawLine(GetWorldPosition(z, y), GetWorldPosition(z + 1, y), Color.white, 100f);
            }
        }
        Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);
    }

    private Vector3 GetWorldPosition(int z, int y)
    {
        return new Vector3(0.977f, y, z) * cellSize + originPosition;
    }

    //getting the z and y positions on the grid to the specific world location
    private void GetZY(Vector3 worldPosition, out int z, out int y)
    {
        z = Mathf.FloorToInt((worldPosition - originPosition).y / cellSize);
        y = Mathf.FloorToInt((worldPosition - originPosition).z / cellSize);
    }

    public void SetValue(int z, int y, int value)
    {
        //checking that the values entered are within the grid
        if(z>= 0 && y >=0 && z < width && y < height)
        {
            gridArray[z, y] = value;
            playerCoords.Add(new Tuple<int, int>(z, y));
            Debug.Log($"{z} {y}");
            //debugTextArray[z, y].text = value.ToString();
        }
    }

    public void SetValue(Vector3 worldPosition, int value)
    {
        Debug.Log(worldPosition);
        int z, y;
        GetZY(worldPosition, out z, out y);
        SetValue(z, y, value);
    }


    public int GetValue(int z, int y)
    {
        //checking that the values entered are within the grid
        if (z >= 0 && y >= 0 && z < width && y < height)
        {
            return gridArray[z, y];
        }
        else
        {
            return 0;
        }
    }

    public int GetValue(Vector3 worldPosition)
    {
        int z, y;
        GetZY(worldPosition, out z, out y);
        return GetValue(z, y);
    }
}
