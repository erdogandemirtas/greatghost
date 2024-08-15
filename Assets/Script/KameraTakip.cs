using UnityEngine;

public class KameraTakip : MonoBehaviour
{
    public Transform ghost;
    public float ydegeri;
    public float lerpSpeed = 5f;  // Kameranın hareket hızını belirler

    void Start()
    {
        // Başlangıçta herhangi bir işlem gerekmiyor
    }

    void Update()
    {
        // Kameranın hedef pozisyonunu belirle
        Vector3 targetPosition = new Vector3(0, ghost.position.y + ydegeri, transform.position.z);

        // Kamerayı yumuşak bir şekilde hedef pozisyona hareket ettir
        transform.position = Vector3.Lerp(transform.position, targetPosition, lerpSpeed * Time.deltaTime);
    }
}
