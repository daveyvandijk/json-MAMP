using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Vector2Data
{
    public float x;
    public float y;
    
    public Vector2Data(Vector2 vector)
    {
        x = vector.x;
        y = vector.y;
    }
    
    public Vector2 ToVector2()
    {
        return new Vector2(x, y);
    }
}
