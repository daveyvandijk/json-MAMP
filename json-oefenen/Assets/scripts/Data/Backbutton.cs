using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Backbutton : MonoBehaviour
{
    public void GoToMain()
    {
        SceneManager.LoadScene(0);
    }
}
