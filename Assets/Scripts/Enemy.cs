using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject replacePrefab;   // น่องไก่
    public GameObject smokeEffect;     // ควัน
    public float destroyDelay = 0.5f;

    Rigidbody rb;
    bool isHit = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (isHit) return;

        if (collision.gameObject.CompareTag("Bullet"))
        {
            isHit = true;

            // เปิดฟิสิกส์
            rb.isKinematic = false;
            rb.useGravity = true;

            // รับแรงจากกระสุน
            Rigidbody bulletRb = collision.gameObject.GetComponent<Rigidbody>();
            if (bulletRb != null)
            {
                rb.AddForce(bulletRb.linearVelocity * 0.5f, ForceMode.Impulse);
            }

            // เอฟเฟคควัน
            Instantiate(smokeEffect, transform.position, Quaternion.identity);

            // แปลงร่างหลังจากกระเด็น
            Invoke("TransformToMeat", destroyDelay);
        }
    }

    void TransformToMeat()
    {
        Instantiate(replacePrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}