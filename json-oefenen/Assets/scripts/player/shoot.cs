using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public WapenScriptableObject huidigWapen;
    private float laatsteSchotTijd = 0f; 

    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= laatsteSchotTijd + 1f / huidigWapen.vuurSnelheid)
        {
            Schiet();
            laatsteSchotTijd = Time.time;
        }
    }

    void Schiet()
    {
        GameObject projectiel = Instantiate(huidigWapen.bulletPrefab, transform.position, transform.rotation);
        Rigidbody2D rb = projectiel.GetComponent<Rigidbody2D>();
        Vector2 schietRichting = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
        rb.velocity = schietRichting * huidigWapen.bulletspeed;
        Projectiel projectielScript = projectiel.GetComponent<Projectiel>();
        if (projectielScript != null)
        {
            projectielScript.schade = huidigWapen.schade;
        }
    }
}