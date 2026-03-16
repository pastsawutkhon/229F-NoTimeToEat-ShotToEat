using UnityEngine;

public class Tube : MonoBehaviour
{
    public float rotateSpeed = 30f; // degrees per second

    void Update()
    {
        float delta = 0f;

        if (Input.GetKey(KeyCode.DownArrow))
            delta = 1f;
        else if (Input.GetKey(KeyCode.UpArrow))
            delta = -1f;

        if (Mathf.Abs(delta) > 0f)
        {
            transform.Rotate(delta * rotateSpeed * Time.deltaTime, 0f, 0f, Space.Self);

            Vector3 euler = transform.localEulerAngles;
            float x = euler.x;
            if (x > 180f) x -= 360f;
            x = Mathf.Clamp(x, -30f, 30f);
            transform.localEulerAngles = new Vector3(x, euler.y, euler.z);
        }
    }
}
