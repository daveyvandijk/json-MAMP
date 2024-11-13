using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    public Text playerDisplay;
    public void Update()
    {
        if (DBmanager.Loggedin)
        {
            playerDisplay.text = "player: " + DBmanager.username;
        }
    }
    public void GoToRegister()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToLogin()
    {
        SceneManager.LoadScene(2);
    }
}
