using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oven_Trigger : MonoBehaviour
{
    public Player_Input playerInput;
    public Oven oven;

    private void Start()
    {
        playerInput = FindObjectOfType<Player_Input>();
        oven = GetComponentInParent<Oven>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (playerInput.objectValue == 3)
            {
                oven.canOven = true;
                playerInput.canDrop = true;
            }
            else if (oven.objectComplete && !playerInput.holdingObject)
            {
                oven.canOven = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            oven.canOven = false;
            playerInput.canDrop = false;
        }
    }
}
