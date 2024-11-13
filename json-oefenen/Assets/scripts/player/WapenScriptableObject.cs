using UnityEngine;

[CreateAssetMenu(fileName = "NieuwWapen", menuName = "Wapen/Create New Wapen")]
public class WapenScriptableObject : ScriptableObject
{ 
    public string wapenNaam;
    public int schade;
    public float vuurSnelheid;
    public GameObject bulletPrefab;
    public float bulletspeed;
    public Sprite WapenSprite;
    

    public void ToonWapenInfo()
    {
        Debug.Log($"Wapen: {wapenNaam}, vuur Snelheid: {vuurSnelheid}");
    }
}
