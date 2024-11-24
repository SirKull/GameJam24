using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soda_Projectile : MonoBehaviour
{
    public float travelTime;
    public Rigidbody2D rb;

    private void Start()
    {
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
        if (other.gameObject.CompareTag("Flounder"))
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
