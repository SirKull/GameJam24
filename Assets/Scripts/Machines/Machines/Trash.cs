using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    public Player_Input playerInput;
    public bool isTriggered;
    // Start is called before the first frame update
    private void Start()
    {
        playerInput = FindObjectOfType<Player_Input>();
        Player_Input.OnInteract += ThrowAway;
    }

    private void ThrowAway()
    {
        if (playerInput.holdingObject && isTriggered)
        {
            playerInput.CurrentItem(0);
            playerInput.holdingObject = false;
        }
        else
        {
            return;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        isTriggered = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        isTriggered = false;
    }
}
