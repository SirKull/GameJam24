using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fries_Projectile : MonoBehaviour
{
    public float travelTime;
    public float speed;

    public GameObject player;
    public Rigidbody2D rb;

    public float distance;
    public Vector3 endPoint;

    public LayerMask trigger;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        this.GetComponent<Rigidbody2D>().gravityScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, endPoint, speed * Time.deltaTime);

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
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Geometry"))
        {
            Destroy(gameObject);
        }
    }
}
