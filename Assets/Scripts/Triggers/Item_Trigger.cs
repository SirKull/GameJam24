using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Trigger : Item
{
    public Player_Input playerInput;
    public bool isTriggered;
    private void OnEnable()
    {
        Player_Input.OnInteract += ItemInteract;
    }
    private void Start()
    {
        isTriggered = false;
        playerInput = FindObjectOfType<Player_Input>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (playerInput.holdingObject)
        {
            return;
        }
        else
        {
            if (other.CompareTag("Player"))
            {
                isTriggered = true;
                playerInput.canPickup = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isTriggered = false;
            playerInput.canPickup = false;
        }
    }

    private void ItemInteract()
    {
        if (playerInput.canPickup && isTriggered)
        {
            playerInput.CurrentItem(itemValue);
            playerInput.holdingObject = true;
        }
        else
        {
            return;
        }
    }
}
