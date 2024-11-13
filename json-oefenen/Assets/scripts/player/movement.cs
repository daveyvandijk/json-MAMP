using UnityEngine;
using System.IO;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; 
    private Rigidbody2D rb;
    private Vector2 movement;

    private string jsonBestandPad;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        jsonBestandPad = Path.Combine(Application.persistentDataPath, "playerPosition.json");
        LaadPosition();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal"); 
        movement.y = Input.GetAxisRaw("Vertical");   
    }

    void FixedUpdate()
    {
        OpslaanPosition();
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void OpslaanPosition()
    {
        dingenOpslaan Data = new dingenOpslaan();
        Data.movement = new Vector2Data(rb.position);

        string json = JsonUtility.ToJson(Data);
        File.WriteAllText(jsonBestandPad, json);
    }

    void LaadPosition()
    {
        if (File.Exists(jsonBestandPad))
        {
            string json = File.ReadAllText(jsonBestandPad);
            dingenOpslaan Data = JsonUtility.FromJson<dingenOpslaan>(json);
            Vector2 geladenPositie = Data.movement.ToVector2();
            rb.position = geladenPositie;
            
            Debug.Log("Positie geladen: " + geladenPositie);
        }
        else
        {
            Debug.Log("Geen gegevens gevonden");
        }
    }
}