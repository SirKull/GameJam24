using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sardine_Sprite_Handler : MonoBehaviour
{
    public GameObject sprite1;
    public GameObject sprite2;
    public GameObject sprite3;

    public int bodyVal;
    // Start is called before the first frame update
    void Start()
    {
        if (bodyVal == 0)
        {
            sprite1.SetActive(true);
        }
        if(bodyVal == 1)
        {
            sprite2.SetActive(true);
        }
        else
        {
            sprite3.SetActive(true);
        }
    }

}