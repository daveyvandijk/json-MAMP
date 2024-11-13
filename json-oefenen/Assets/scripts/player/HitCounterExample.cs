using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HitCounterExample : MonoBehaviour
{
    [SerializeField] private int hit;
    // Start is called before the first frame update
    void Start()
    {
        hit = 0;
    }
    
    private void OnMouseDown()
    {
        hit++;
    }
}
