using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WhiteboardMarker : MonoBehaviour
{
    public Transform penTip;
    public int penSize;

    Renderer _renderer;
    Color[] colors;

    public float tipHeight;

    RaycastHit touch;

    Whiteboard whiteboard;
    Vector2 touchPos, lastTouchPos;
    bool touchedLastFrame = true;

    Quaternion lastTouchRot;

    bool once = false;

    void Start()
    {
        //this is to get the pen colour (red in this case)
        _renderer = penTip.GetComponent<Renderer>();

        //each time you use the pen you are creating a square of pixels, this is to make sure that the square is all the same colour that was specified above
        colors = Enumerable.Repeat(_renderer.material.color, penSize * penSize).ToArray();
    }

    void Update()
    {
        Draw();
    }

    void Draw()
    {
        Debug.DrawRay(penTip.position, -transform.up, Color.green);
        //testing if you hit something from the pen-tip (in this case it will also be testing to see if this is the whiteboard
        if (Physics.Raycast(penTip.position, -transform.up, out touch, tipHeight))
        {
            if (touch.transform.tag == "Whiteboard")
            {
                if(!once)
                {
                    whiteboard = touch.transform.GetComponent<Whiteboard>();
                    once = true;
                }
                Debug.Log("hitW");
                //grabs the touch position that you touch the pen to the whiteboard
                touchPos = new Vector3(touch.textureCoord.x, touch.textureCoord.y);

                //gets the pixel size of the touch instead of the x/y coords
                var x = (int)(touchPos.x * whiteboard.textureSize.x - penSize / 2);
                var y = (int)(touchPos.y * whiteboard.textureSize.y - penSize / 2);

                //checking if you're still in bounds of the whiteboard - dragging your pen and ending outside
                if(y < 0 || y > whiteboard.textureSize.y || x < 0 || x > whiteboard.textureSize.x)
                {
                    return;
                }

                if(touchedLastFrame)
                {
                    //sets that specific area to the size of the pen by the size of the pen and all of the set colours
                    whiteboard.penTexture.SetPixels(x, y, penSize, penSize, colors);

                    //dragging your pen and interpolates the gap when dragging
                    for (float i = 0.01f; i < 1; i+= 0.001f)
                    {
                        var lerpX = (int)Mathf.Lerp(lastTouchPos.x, x, i);
                        var lerpY = (int)Mathf.Lerp(lastTouchPos.y, y, i);
                        whiteboard.penTexture.SetPixels(lerpX, lerpY, penSize, penSize, colors);
                    }

                    //locks the rotation so the pen doesn't push against the whiteboard
                    transform.rotation = lastTouchRot;
                    whiteboard.penTexture.Apply();
                }

                lastTouchPos = new Vector2(x, y);
                lastTouchRot = transform.rotation;
                touchedLastFrame = true;
                return;
            }
        }
        once = false;
        touchedLastFrame = false;
    }
}
