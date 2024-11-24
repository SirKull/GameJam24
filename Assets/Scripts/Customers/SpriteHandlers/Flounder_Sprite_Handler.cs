using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flounder_Sprite_Handler : MonoBehaviour
{
    public Customer customer;
    public GameObject sprite1;
    public GameObject sprite2;

    public int bodyVal;
    // Start is called before the first frame update
    void Start()
    {
        if(bodyVal == 0)
        {
            sprite1.SetActive(true);
        }
        else
        {
            sprite2.SetActive(true);
        }
    }

}
