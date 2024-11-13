using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Webtest : MonoBehaviour
{
    private IEnumerator Start()
    {
        // Maak een nieuwe UnityWebRequest aan voor een GET-verzoek
        UnityWebRequest request = UnityWebRequest.Get("http://localhost/sqlconnect/webtest.php");

        // Verstuur de request en wacht op een reactie
        yield return request.SendWebRequest();

        // Controleer op fouten
        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log("Error: " + request.error);
        }
        else
        {
            // Log de tekst van de serverrespons naar de console
            Debug.Log("Server response: " + request.downloadHandler.text);
        }
    }
}
