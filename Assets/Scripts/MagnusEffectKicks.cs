using UnityEngine;

public class MagnusEffectKicks : MonoBehaviour
{
    public float kickForce;
    public float spinAmount;
    public float magnusStrength = 0.5f;

    Rigidbody rb;
    bool isShot = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Launch(float force, float spin)
    {
        kickForce = force;
        spinAmount = spin;

        rb.AddForce(transform.forward * kickForce, ForceMode.Impulse);
        
        rb.AddTorque(Vector3.up * spinAmount);

        isShot = true;
    }

    void FixedUpdate()
    {
        if (!isShot) return;

        Vector3 velocity = rb.linearVelocity;
        Vector3 spin = rb.angularVelocity;

        Vector3 magnusForce = magnusStrength * Vector3.Cross(spin, velocity);

        rb.AddForce(magnusForce);
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject, 0.2f);
    }

    
}