using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate_Trigger : MonoBehaviour
{
    public bool isTriggered;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isTriggered = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isTriggered = false;
        }
    }
}
