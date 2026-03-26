using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");

        Vector3 velocity = rb.linearVelocity;

        
        if (Mathf.Abs(moveX) > 0.01f)
        {
            velocity.x = moveX * moveSpeed;
        }

        rb.linearVelocity = velocity;

        
        Vector3 pos = rb.position;
        pos.x = Mathf.Clamp(pos.x, -10f, 10f);
        rb.MovePosition(pos);
    }
}
