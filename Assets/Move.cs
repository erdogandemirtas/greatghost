using UnityEngine;

public class Move : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed = 10f; // moveSpeed'i public yaparak Unity Editörü üzerinden ayarlayabilirsiniz

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
            // Mobil cihazın eğim sensörlerini kullanarak yatay hareketi al
            float dirX = Input.acceleration.x * moveSpeed;
            rb.linearVelocity = new Vector2(dirX, rb.linearVelocity.y); // rb.velocity.y'yi koruyarak sadece x ekseninde hareketi değiştirme
        }
    }
}
