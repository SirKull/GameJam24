using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burger_Projectile : MonoBehaviour
{
    public float travelTime;

    public GameObject player;
    public Rigidbody2D rb;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        this.GetComponent<Rigidbody2D>().gravityScale = 0f;
    }

    private void Update()
    {
        travelTime -= Time.deltaTime;
        if(travelTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Whale"))
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
