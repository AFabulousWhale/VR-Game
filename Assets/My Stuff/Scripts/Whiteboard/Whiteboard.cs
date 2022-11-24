using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whiteboard : MonoBehaviour
{
    public Texture2D penTexture;
    public Vector2 textureSize = new Vector2(2048, 2048);
    void Start()
    {
        //this is to create a new texture for the whiteboard for when you're drawing on it
        penTexture = new Texture2D((int)textureSize.x, (int)textureSize.y);
        GetComponent<Renderer>().material.mainTexture = penTexture;
    }
}
