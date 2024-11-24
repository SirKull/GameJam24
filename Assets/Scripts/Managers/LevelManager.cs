using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class LevelManager : MonoBehaviour
{
    public Customer customer;
    public static LevelManager SharedInstance;
    public List<GameObject> customers;
    public GameObject sharkObject;
    public GameObject sardineObject;
    public GameObject flounderObject;
    public int amountToPool;
    public Transform spawnPosition;

    public float levelTimer;
    public float spawnTimer;
    public float activeCustomers;

    //ingredients
    public int veggies;
    public int chum;
    public int cups;
    public int bread;

    private void Awake()
    {
        SharedInstance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        customers= new List<GameObject>();
        GameObject tmp;
        for(int i = 0; i < amountToPool; i++)
        {
            int fish = Random.Range(0, 3);
            if(fish == 0)
            {
                tmp = Instantiate(sharkObject);
                tmp.SetActive(false);
                customers.Add(tmp);
            }
            if (fish == 1)
            {
                tmp = Instantiate(sardineObject);
                tmp.SetActive(false);
                customers.Add(tmp);
            }
            if (fish >= 2)
            {
                tmp = Instantiate(flounderObject);
                tmp.SetActive(false);
                customers.Add(tmp);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        levelTimer += Time.deltaTime;
        spawnTimer += Time.deltaTime;

        int spawnCooldown = Random.Range(6, 12);

        if(spawnTimer >= spawnCooldown)
        {
            if (activeCustomers < 6)
            {
                GameObject customer = GetPooledObject();
                if (customer != null)
                {
                    customer.transform.position = spawnPosition.transform.position;
                    customer.SetActive(true);
                    activeCustomers++;
                }
                spawnTimer = 0;
            }
        }
    }

    public GameObject GetPooledObject()
    {
        for(int i = 0; i < amountToPool; i++)
        {
            if (!customers[i].activeInHierarchy)
            {
                return customers[i];
            }
        }
        return null;
    } 
}
