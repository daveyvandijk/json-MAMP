using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    void Update()
    {
        Vector3 muisPositie = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 richting = muisPositie - transform.position;
        richting.z = 0;
        float hoek = Mathf.Atan2(richting.y, richting.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, hoek);
    }
}