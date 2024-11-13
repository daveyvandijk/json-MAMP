using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class followcurser : MonoBehaviour
{
    public WapenScriptableObject huidigWapen;
    private float laatsteSchotTijd = 0f;

    void Update()
    {
        if (huidigWapen is null)
        {
           // Debug.Log("Geen wapen toegewezen");
        }
        Vector3 muisPositie = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 richting = muisPositie - transform.position;
        richting.z = 0;
        float hoek = Mathf.Atan2(richting.y, richting.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, hoek);
        
        if (Input.GetMouseButton(0) && Time.time >= laatsteSchotTijd + 1f / huidigWapen.vuurSnelheid)
        {
            Schiet();
            laatsteSchotTijd = Time.time;
        }
    }

    void Schiet()
    {
        // Maak een projectiel aan
        GameObject projectiel = Instantiate(huidigWapen.bulletPrefab, transform.position, transform.rotation);

        // Beweeg het projectiel in de richting van de muis
        Rigidbody2D rb = projectiel.GetComponent<Rigidbody2D>();
        Vector2 schietRichting = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
        rb.velocity = schietRichting * huidigWapen.bulletspeed;

        // Voeg schade toe aan het projectiel indien nodig
        Projectiel projectielScript = projectiel.GetComponent<Projectiel>();
        if (projectielScript != null)
        {
            projectielScript.schade = huidigWapen.schade;
        }
    }
}

