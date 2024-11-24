using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class Customer : MonoBehaviour, IDamageable
{
    public AIDestinationSetter destinationSetter;
    public Helper helper;
    public AIPath aiPath;

    public List<GameObject> tables_list = new List<GameObject>();
    public GameObject sharkBody;
    public GameObject sardineBody;
    public GameObject flounderBody;
    public int fishType;

    public Transform seats;
    public Transform tableDestination;
    public Transform exit;
    private bool atTable;
    private bool dead;
    public bool spawnsSet;
    private void Start()
    {
        destinationSetter = GetComponent<AIDestinationSetter>();
        aiPath = GetComponent<AIPath>();
        helper = FindObjectOfType<Helper>();
        seats = GameObject.Find("Seats").transform;
        exit = GameObject.Find("Exit").transform;
        spawnsSet = false;
        SetDestinations(seats, "CustomerLocation", tables_list);
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (dead)
        {
            return;
        }
        else if (!atTable && spawnsSet)
        {
            destinationSetter.target = tableDestination;
            if(aiPath.desiredVelocity.x >= 0.01f)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
            } else if (aiPath.desiredVelocity.x <= -0.1f)
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
            if (aiPath.reachedDestination)
            {
                atTable = true;
            }
        }
    }

    private void Spawn()
    {
        int seatTarget = Random.Range(0, tables_list.Count);
        for (int i = 0; i < seatTarget; i++)
        {
            tableDestination = tables_list[i].transform;
        }
        spawnsSet = true;
    }

    private void SetDestinations(Transform seats, string CustomerLocation, List<GameObject> list)
    {
        foreach(Transform child in seats)
        {
            if(child.gameObject.tag == CustomerLocation)
            {
                list.Add(child.gameObject);
            }
            SetDestinations(child, tag, list);
        }
    }

    public void Damage()
    {
        dead = true;
        helper.enemyDead = true;

        if(fishType == 1)
        {
            GameObject body = Instantiate(sharkBody, transform.position, Quaternion.identity);
        }
        if(fishType == 2)
        {
            GameObject body = Instantiate(sardineBody, transform.position, Quaternion.identity);
        }
        if(fishType == 3)
        {
            GameObject body = Instantiate(flounderBody, transform.position, Quaternion.identity);
        }
        gameObject.SetActive(false);
    }
}
