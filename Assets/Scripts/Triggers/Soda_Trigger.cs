using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soda_Trigger : MonoBehaviour
{
    public Player_Input playerInput;
    public Soda soda;
    private void Start()
    {
        playerInput = FindObjectOfType<Player_Input>();
        soda = GetComponentInParent<Soda>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            soda.canSoda = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            soda.canSoda = false;
        }
    }
}
