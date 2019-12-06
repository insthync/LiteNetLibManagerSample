using LiteNetLibManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiteNetLibDemoChildrenBehaviour : LiteNetLibBehaviour
{
    public Image changingColorImage;
    public SyncFieldColor color;
    void Update()
    {
        changingColorImage.color = color.Value;
    }

    public void SetColor(string color)
    {
        if (color == "r")
            this.color.Value = Color.red;
        if (color == "g")
            this.color.Value = Color.green;
        if (color == "b")
            this.color.Value = Color.blue;
    }
}
