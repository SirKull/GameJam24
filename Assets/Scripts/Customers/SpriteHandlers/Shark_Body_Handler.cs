using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark_Body_Handler : MonoBehaviour
{
    public GameObject sprite1;
    public GameObject sprite2;

    public int bodyVal;
    // Start is called before the first frame update
    void Start()
    {
        sprite1.SetActive(false);
        sprite2.SetActive(false);
        if (bodyVal == 0)
        {
            sprite1.SetActive(true);
        }
        else
        {
            sprite2.SetActive(true);
        }
    }
}
