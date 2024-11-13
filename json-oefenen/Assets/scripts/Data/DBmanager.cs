using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DBmanager
{
    public static string username;
    public static int score;
    
    public static bool Loggedin
    {
        get { return !string.IsNullOrEmpty(username); }
    }

    public static void Logout()
    {
        username = null;
    }
}
