using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lookat : MonoBehaviour
{
    public Transform target; // De referentie naar het object dat we willen aankijken

    void Update()
    {
        // Roep de LookAt2D-methode aan om het object naar het doel te laten kijken
        w.LookAt2D(transform, target);
        
    }
}
