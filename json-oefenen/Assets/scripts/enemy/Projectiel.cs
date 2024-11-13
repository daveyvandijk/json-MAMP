using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectiel : MonoBehaviour
{
   public int schade;
   private void OnCollisionEnter2D(Collision2D collision)
   {
      if (collision.gameObject.CompareTag("Vijand"))
      {
         Vijand vijand = collision.gameObject.GetComponent<Vijand>();
         if (vijand != null)
         {
            vijand.NeemSchade(schade);
         }
         
         Destroy(gameObject);
      }
   }

   private void Update()
   {
      Destroy(gameObject, 2f);
   }
}
