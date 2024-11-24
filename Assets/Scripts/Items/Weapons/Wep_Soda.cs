using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wep_Soda : Player_Weapon
{
    public Player_Input playerInput;

    public Transform firePoint;
    public GameObject projectile;
    public bool isActive;

    //shooting stats
    public float timeSinceLastShot;
    public float sodaForce;

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
            GameObject soda = Instantiate(projectile, firePoint.position, firePoint.rotation);

            Rigidbody2D rb = soda.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.right * sodaForce, ForceMode2D.Impulse);
            DisableWep();
        }
    }
    private void DisableWep()
    {
        playerInput.holdingWeapon = false;
        playerInput.hasSoda = false;
        playerInput.CurrentWeapon(0);
    }
}
