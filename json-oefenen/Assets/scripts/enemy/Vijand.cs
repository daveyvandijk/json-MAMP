using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vijand : MonoBehaviour
{
    public int levens = 100;

   
    public void NeemSchade(int schade)
    {
        levens -= schade;
        Debug.Log($"Vijand neemt {schade} schade. Overgebleven levens: {levens}");

        if (levens <= 0)
        {
            Sterf();
        }
    }

   
    void Sterf()
    {
        Debug.Log("Vijand is verslagen!");
        Destroy(gameObject);
    }
}
