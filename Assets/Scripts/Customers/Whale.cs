using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whale : MonoBehaviour, IDamageable
{
    public LevelManager levelManager;

    public Transform whale;
    public Transform startPoint;
    public Transform midPoint;
    public Transform endPoint;

    public bool hasFood;
    public bool canMove;
    public bool isMid;
    public bool pullUp;

    public float speed;
    public float startDelay;
    public float whaleTimer;
    public float spawnInterval;
    public float score = 40f;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        startDelay = 10f;
        whaleTimer = 0f;
        whale.position = startPoint.transform.position;
        hasFood = false;
        isMid = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(startDelay >= 0)
        {
            startDelay -= Time.deltaTime;
        }
        if (whaleTimer >= 0)
        {
            whaleTimer -= Time.deltaTime;
        }

        if (startDelay <= 0 && whaleTimer <= 0)
        {
            if (!pullUp)
            {
                PullUp();
            }
        }

        if (!hasFood && !isMid && canMove)
        {
            Debug.Log("MoveWhale");
            if (Vector2.Distance(transform.position, midPoint.position) < 0.1)
            {
                canMove = false;
                isMid = true;
            }
            whale.transform.position = Vector2.Lerp(transform.position, midPoint.position, speed * Time.deltaTime);
        }
        if (hasFood && isMid)
        {
            whale.transform.position = Vector2.Lerp(transform.position, endPoint.position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, endPoint.position) < 0.1)
            {
                whale.position = startPoint.position;
                isMid = false;
                hasFood = false;
                pullUp = false;
                whaleTimer = spawnInterval;

            }
        }

    }

    void PullUp()
    {
        pullUp = true;
        canMove = true;
        spawnInterval = Random.Range(20f, 25f);

    }
    public void Damage()
    {
        hasFood = true;
        levelManager.score += score;
    }
}
