using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soda : MonoBehaviour
{
    public Player_Input playerInput;
    public Soda_Trigger sodaTrigger;

    //checks
    public bool canSoda;

    //operation
    public int soda = 7;

    private void OnEnable()
    {
        Player_Input.OnInteract += MachineInteract;
    }
    // Start is called before the first frame update
    private void Start()
    {
        canSoda = false;
        playerInput = FindObjectOfType<Player_Input>();
        sodaTrigger = GetComponentInChildren<Soda_Trigger>();
    }
    private void Update()
    {

    }

    private void MachineInteract()
    {
        if (canSoda && playerInput.objectValue == 4)
        {
            playerInput.holdingObject = true;
            playerInput.CurrentItem(soda);
        }
    }
}
