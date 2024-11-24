using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wep_Fries : Player_Weapon
{
    public Player_Input playerInput;

    public Transform firePoint;
    public Fries_Projectile projectile;

    //shooting stats
    public float timeSinceLastShot;
    public int pellets;

    // Start is called before the first frame update
    void Start()
    {
        Player_Input.OnShoot += Shoot;
    }
    private void Update()
    {
        timeSinceLastShot += Time.deltaTime;
    }

    private bool CanShoot() => timeSinceLastShot > 1f / (fireRate / 60f);

    private void Shoot()
    {
        if (CanShoot())
        {
            for (int i = 0; i < pellets; i++)
            {
                Vector2 direction = GetDirection();
                Fries_Projectile fries = Instantiate(projectile, firePoint.position, Quaternion.identity);
                fries.endPoint = playerInput.mousePos;
            }
        }
    }
    private Vector3 GetDirection()
    {
        Vector3 direction = firePoint.transform.forward;
        Vector3 spread = Vector3.zero;
        spread += firePoint.transform.right * Random.Range(-0.5f, 0.5f);

        direction += spread.normalized * Random.Range(0f, 0.2f);

        return direction;
    }
}
