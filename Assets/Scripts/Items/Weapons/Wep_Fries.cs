using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wep_Fries : Player_Weapon
{
    public Player_Input playerInput;

    public Transform firePoint;
    public GameObject projectile;

    //shooting stats
    public float timeSinceLastShot;
    public int pellets;
    Vector2 range = new Vector2(-1, 1);
    private float addedOffset;
    public float fryForce;

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
            for (int i = 0; i < pellets; i++)
            {
                Debug.Log("fire");
                float bulletSpread = Random.Range(range.x, range.y);
                firePoint.transform.eulerAngles = new Vector3(  firePoint.transform.eulerAngles.x,
                                                                firePoint.transform.eulerAngles.y + bulletSpread,
                                                                firePoint.transform.eulerAngles.z);

                GameObject fries = Instantiate(projectile, firePoint.position, firePoint.rotation);

                Rigidbody2D rb = fries.GetComponent<Rigidbody2D>();
                rb.AddForce(firePoint.up * fryForce, ForceMode2D.Impulse);
            }
        }
    }
    private Quaternion GetDirection()
    {
        Quaternion newRot = firePoint.rotation;

        newRot = Quaternion.Euler(firePoint.transform.localEulerAngles.x, firePoint.transform.localEulerAngles.y, firePoint.transform.localEulerAngles.z + addedOffset);

        return newRot;
    }
}
