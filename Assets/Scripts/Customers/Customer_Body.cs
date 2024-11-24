using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer_Body : MonoBehaviour
{
    public Helper helper;
    public int bodyValue;
    // Start is called before the first frame update
    void Start()
    {
        helper = FindObjectOfType<Helper>();
        helper.bodyPosition = this.transform;
        helper.destinationSetter.target = this.transform;
    }
}
