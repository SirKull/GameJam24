using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wep_Burger : Player_Weapon
{
    public Player_Input playerInput;

    public Transform firePoint;
    public Burger_Projectile projectile;

    public float timeSinceLastShot;

    // Start is called before the first frame update
    void Start()
    {
        Player_Input.OnShoot += Shoot;
        playerInput = GetComponentInParent<Player_Input>();
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
            Debug.Log("fire");
            Burger_Projectile burger = Instantiate(projectile, firePoint.position, Quaternion.identity);
            burger.endPoint = playerInput.mousePos;
        }
    }
}
