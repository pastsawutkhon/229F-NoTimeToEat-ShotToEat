using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject replacePrefab; // น่องไก่
    public float bounceForce = 5f;

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

            // เด้งขึ้น
            rb.isKinematic = false;
            rb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);

            // Spawn น่องไก่
            Instantiate(replacePrefab, transform.position, Quaternion.identity);

            // ลบไก่
            Destroy(gameObject, 0.3f);
        }
    }
}