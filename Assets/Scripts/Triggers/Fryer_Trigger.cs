using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fryer_Trigger : MonoBehaviour
{
    public Player_Input playerInput;
    public Fryer fryer;
    private void Start()
    {
        playerInput = FindObjectOfType<Player_Input>();
        fryer = GetComponentInParent<Fryer>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (playerInput.objectValue == 2)
            {
                fryer.canFryer = true;
                playerInput.canDrop = true;
            }
            else if (fryer.objectComplete && !playerInput.holdingObject)
            {
                fryer.canFryer = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            fryer.canFryer = false;
            playerInput.canDrop = false;
        }
    }
}
