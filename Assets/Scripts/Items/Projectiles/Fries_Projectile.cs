using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fries_Projectile : MonoBehaviour
{
    public Wep_Fries friesWeapon;
    public Transform firePoint;

    public float travelTime;
    public float speed;

    public GameObject player;
    public Rigidbody2D rb;

    public float distance;

    public LayerMask trigger;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        friesWeapon = FindObjectOfType<Wep_Fries>();
        rb = GetComponent<Rigidbody2D>();
        this.GetComponent<Rigidbody2D>().gravityScale = 0f;
    }
    // Update is called once per frame
    void Update()
    {
        travelTime -= Time.deltaTime;
        if (travelTime <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Sardine"))
        {
            Debug.Log("Customer Hit");
            IDamageable damageable = other.transform.GetComponent<IDamageable>();
            damageable?.Damage();
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Geometry"))
        {
            Destroy(gameObject);
        }
    }
}
