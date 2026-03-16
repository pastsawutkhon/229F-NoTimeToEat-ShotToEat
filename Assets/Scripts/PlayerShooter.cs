using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooter : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;

    public float shootForce = 10f;
    public float spin = 0f;
    float addSpin = 0.1f;
    float addForce = 5f;


    void Update()
    {
        // W/S hold to increase/decrease force over time
        if (Keyboard.current.wKey.isPressed)
            shootForce += addForce * Time.deltaTime;

        if (Keyboard.current.sKey.isPressed)
            shootForce = Mathf.Max(0, shootForce - addForce * Time.deltaTime);

        // E/Q hold to adjust spin over time
        if (Keyboard.current.eKey.isPressed)
            spin += addSpin * Time.deltaTime;

        if (Keyboard.current.qKey.isPressed)
            spin -= addSpin * Time.deltaTime;

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
            Shoot();
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        MagnusEffectKicks ball = bullet.GetComponent<MagnusEffectKicks>();

        ball.Launch(shootForce, spin);
    }
}