using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burger_Projectile : MonoBehaviour
{
    public float travelTime;
    public float speed;

    public GameObject player;
    public Rigidbody2D rb;

    public float distance;
    public Vector3 endPoint;

    public LayerMask trigger;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        this.GetComponent<Rigidbody2D>().gravityScale = 0f;
    }

    private void Update()
    {
        /*Vector3 targetPosition = new Vector3(transform.position.x, transform.position.y, 0);*/
        transform.position = Vector2.MoveTowards(transform.position, endPoint, speed * Time.deltaTime);

        travelTime -= Time.deltaTime;
        if(travelTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Shark"))
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
