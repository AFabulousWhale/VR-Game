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
        debugTextArray = new TextMesh[width, height];

        //setting up visuals for the grid
        //cycles through the first dimension of the array
        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            //cycles through the second dimension of the array
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                debugTextArray[x,y] = UtilsClass.CreateWorldText(gridArray[x,y].ToString(), null, GetWorldPosition(x,y) + new Vector3(cellSize, cellSize) * 0.5f, 30, Color.white, TextAnchor.MiddleCenter);
                Debug.DrawLine(GetWorldPosition(x,y), GetWorldPosition(x,y+1), Color.white, 100f);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x +1, y), Color.white, 100f);
            }
        }
        Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);
    }

    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * cellSize + originPosition;
    }

    //getting the x and y positions on the grid to the specific world location
    private void GetXY(Vector3 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt((worldPosition - originPosition).x / cellSize);
        y = Mathf.FloorToInt((worldPosition - originPosition).y / cellSize);
    }

    public void SetValue(int x, int y, int value)
    {
        //checking that the values entered are within the grid
        if(x>= 0 && y >=0 && x < width && y < height)
        {
            gridArray[x, y] = value;
            playerCoords.Add(new Tuple<int, int>(x, y));
            Debug.Log($"{x} {y}");
            debugTextArray[x, y].text = value.ToString();
        }
    }

    public void SetValue(Vector3 worldPosition, int value)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        SetValue(x, y, value);
    }


    public int GetValue(int x, int y)
    {
        //checking that the values entered are within the grid
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            return gridArray[x, y];
        }
        else
        {
            return 0;
        }
    }

    public int GetValue(Vector3 worldPosition)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        return GetValue(x, y);
    }
}
