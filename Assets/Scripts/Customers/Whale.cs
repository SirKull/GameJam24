using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whale : MonoBehaviour
{
    public Transform whale;
    public Transform startPoint;
    public Transform midPoint;
    public Transform endPoint;

    public bool hasFood;
    public bool canMove;

    public float speed;
    public float startDelay;
    public float spawnInterval;

    // Start is called before the first frame update
    void Start()
    {
        startDelay = 10f;
        whale.position = startPoint.transform.position;
        hasFood = false;
    }

    // Update is called once per frame
    void Update()
    {
        startDelay -= Time.deltaTime;
        if (hasFood)
        {
            whale.transform.position = Vector2.Lerp(transform.position, endPoint.position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, endPoint.position) < 0.1)
            {
                whale.position = startPoint.position;
                hasFood = false;
            }
            canMove = true;
        }
        if (startDelay <= 0)
        {
            PullUp();
            startDelay = spawnInterval;
        }
        if (!hasFood && canMove)
        {
            Debug.Log("MoveWhale");
            if (Vector2.Distance(transform.position, midPoint.position) < 0)
            {
                canMove = false;
            }
            whale.transform.position = Vector2.Lerp(transform.position, midPoint.position, speed * Time.deltaTime);
        }
    }

    void PullUp()
    {
        canMove = true;
        spawnInterval = Random.Range(20f, 25f);

    }
}
