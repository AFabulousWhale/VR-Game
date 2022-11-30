using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Whiteboard : MonoBehaviour
{
    public Texture2D penTexture;
    public Texture mainTexture;
    public Vector2 textureSize = new Vector2(2048, 2048);
    void Start()
    {
        mainTexture = GetComponent<Renderer>().material.mainTexture;
        //this is to create a new texture for the whiteboard for when you're drawing on it
        penTexture = new Texture2D((int)textureSize.x, (int)textureSize.y);
        mainTexture = penTexture;
    }
}
