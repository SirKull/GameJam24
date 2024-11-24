using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wep_Burger : Player_Weapon
{
    public Player_Input playerInput;

    public Transform firePoint;
    public Burger_Projectile projectile;
    public bool isActive;

    public float timeSinceLastShot;
    public float burgerForce = 10f;

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
    private void OnEnable()
    {
        isActive = true;
    }
    private void OnDisable()
    {
        isActive = false;
    }

    private void Shoot()
    {
        if (playerInput.holdingWeapon && isActive)
        {
            Debug.Log("fire");
            Burger_Projectile burger = Instantiate(projectile, firePoint.position, Quaternion.identity);
            Rigidbody2D rb = burger.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.right * burgerForce, ForceMode2D.Impulse);
            DisableWep();
        }
    }
    private void DisableWep()
    {
        playerInput.holdingWeapon = false;
        playerInput.hasBurger = false;
        playerInput.CurrentWeapon(0);
    }
}
