using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Registration : MonoBehaviour
{
    public InputField nameField;
    public InputField passwordField;

    public Button submitButton;

    public void CallRegister()
    {
        StartCoroutine(Register());
    }
    
    IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", nameField.text);
        form.AddField("password", passwordField.text);

        // Verzend het formulier via UnityWebRequest
        UnityWebRequest www = UnityWebRequest.Post("http://localhost/sqlconnect/register.php", form);

        // Verstuur de request en wacht op een reactie
        yield return www.SendWebRequest();

        // Controleer op fouten
        if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log("User creation. error #" + www.error);
        }
        else
        {
            Debug.Log("Server response: " + www.downloadHandler.text);
            if (www.downloadHandler.text == "0")
            {
                Debug.Log("User created successfully");
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            }
            else
            {
                Debug.Log("User creation failed. error #" + www.downloadHandler.text);
            }
        }
    }

    public void VerifyInput()
    {
        submitButton.interactable = (nameField.text.Length >= 8 && passwordField.text.Length >= 8);
    }
}