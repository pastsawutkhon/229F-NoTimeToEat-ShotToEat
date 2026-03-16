using UnityEngine;

public class Base : MonoBehaviour
{
    public float rotateSpeed = 90f; // degrees per second

    // Update is called once per frame
    void Update()
    {
        float turn = 0f;

        if (Input.GetKey(KeyCode.RightArrow))
            turn = 1f;
        else if (Input.GetKey(KeyCode.LeftArrow))
            turn = -1f;

        if (Mathf.Abs(turn) > 0f)
        {
            transform.Rotate(0f, turn * rotateSpeed * Time.deltaTime, 0f, Space.Self);

            Vector3 euler = transform.localEulerAngles;
            // Convert 0-360 to -180..180 range for clamping
            float y = euler.y;
            if (y > 180f) y -= 360f;
            y = Mathf.Clamp(y, -90f, 90f);
            transform.localEulerAngles = new Vector3(euler.x, y, euler.z);
        }
    }
}
