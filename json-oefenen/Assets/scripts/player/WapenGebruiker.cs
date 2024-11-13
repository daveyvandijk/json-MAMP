using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using System.IO;
public class WapenGebruiker : MonoBehaviour
{
    public WapenScriptableObject[] wapens;
    public PlayerShoot playerShootScript;
    public DisplaySprite DisplaySpriteScript;
    
    private int huidigWapenIndex = 0;
    private string jsonBestandPad;
    void Start()
    {
        jsonBestandPad = Path.Combine(Application.persistentDataPath, "wapenGegevens.json");
        WapenLaden();
        if (wapens.Length > 0)
        {
            ToonHuidigWapen();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            volgendeWapen();
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            VorigWapen();
        }
    }

    void volgendeWapen()
    {
        huidigWapenIndex++;
        if (huidigWapenIndex >= wapens.Length)
        {
            huidigWapenIndex = 0;
        }
        ToonHuidigWapen();
        WapenOpslaan();
    }

    void VorigWapen()
    {
        huidigWapenIndex--;
        if (huidigWapenIndex < 0)
        {
            huidigWapenIndex = wapens.Length - 1;
        }
        ToonHuidigWapen();
        WapenOpslaan();
    }

    void ToonHuidigWapen()
    {
        if (wapens[huidigWapenIndex] != null)
        {
            Debug.Log($"Je hebt nu het wapen: {wapens[huidigWapenIndex].wapenNaam}");
            
            if (playerShootScript != null)
            {
                playerShootScript.huidigWapen = wapens[huidigWapenIndex];
            }

            if (DisplaySpriteScript != null)
            {
                DisplaySpriteScript.huidigWapenData = wapens[huidigWapenIndex];
                DisplaySpriteScript.UpdateSprite();
            }
        }
    }

    void WapenOpslaan()
    {
        dingenOpslaan gegevens = new dingenOpslaan();
        gegevens.huidigWapenIndex = huidigWapenIndex;

        string json = JsonUtility.ToJson(gegevens);
        File.WriteAllText(jsonBestandPad,json);
        Debug.Log("De gegevens van de wapens zijn opgeslagen");
    }

    void WapenLaden()
    {
        if (File.Exists(jsonBestandPad))
        {
            string json = File.ReadAllText(jsonBestandPad);
            dingenOpslaan gegevens = JsonUtility.FromJson<dingenOpslaan>(json);

            huidigWapenIndex = gegevens.huidigWapenIndex;
            Debug.Log("Wapen gegevens zijn geladen");
        }
        else
        {
            Debug.Log("Geen gegevens gevonden");
        }
    }
}
