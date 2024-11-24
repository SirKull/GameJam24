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
    public Vector3 endPoint;
    public Vector3 dir;

    public LayerMask trigger;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        friesWeapon = FindObjectOfType<Wep_Fries>();
        rb = GetComponent<Rigidbody2D>();
        this.GetComponent<Rigidbody2D>().gravityScale = 0f;
    }
    private void OnEnable()
    {
        firePoint = GameObject.FindGameObjectWithTag("FirePoint").transform;
        dir = firePoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
/*        Vector3 target = new Vector3(dir.x, 0, 0);
        rb.MovePosition(transform.position += target * Time.deltaTime * speed);*/

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
