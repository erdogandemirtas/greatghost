using UnityEngine;

public class Move : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D bileşeni eksik! Lütfen bu bileşeni ekleyin.");
        }
    }

    void Update()
    {
        if (rb != null)
        {
            // Eski Input sistemi ile eğim sensörü verilerini al
            Vector3 acceleration = Input.acceleration;

            float dirX = acceleration.x * moveSpeed;
            rb.linearVelocity = new Vector2(dirX, rb.linearVelocity.y);
        }
    }
}
