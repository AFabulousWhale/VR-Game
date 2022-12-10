using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Whiteboard : MonoBehaviour
{
    public Texture2D penTexture;
    public Texture mainTexture;
    public Vector2 textureSize = new Vector2(3293, 2048);
    void Start()
    {
        //this is done to referesh the drawings at the start
        var relativePath1 = "Assets/My Stuff/Images/Whiteboard.png";
        AssetDatabase.ImportAsset(relativePath1);
    }
}
