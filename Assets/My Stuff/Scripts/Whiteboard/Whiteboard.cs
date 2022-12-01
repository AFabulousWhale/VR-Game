using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Whiteboard : MonoBehaviour
{
    public Texture2D penTexture;
    public Texture mainTexture;
    public Vector2 textureSize = new Vector2(4096, 4096);
    void Start()
    {
        //this is done to referesh the drawings at the start
        var relativePath1 = "Assets/My Stuff/Images/Drawing-Pixels.png";
        AssetDatabase.ImportAsset(relativePath1);

        var relativePath2 = "Assets/My Stuff/Images/WhiteBoard-Pixels.png";
        AssetDatabase.ImportAsset(relativePath2);
    }
}
