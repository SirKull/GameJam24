using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oven : MonoBehaviour
{
    public Player_Input playerInput;

    //checks
    public bool hasObject;
    private bool cooking;
    public bool objectComplete;
    public bool canOven;

    //operation
    public float cookingTimer;
    public float cookTime;
    public int cookedMeat = 4;
    private void OnEnable()
    {
        Player_Input.OnInteract += MachineInteract;
    }
    // Start is called before the first frame update
    private void Start()
    {
        hasObject = false;
        canOven = false;
        objectComplete = false;
        playerInput = FindObjectOfType<Player_Input>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasObject && cookingTimer <= cookTime)
        {
            cookingTimer += Time.deltaTime;
            cooking = true;
        }
        else if (cookingTimer >= cookTime)
        {
            cooking = false;
            objectComplete = true;
        }
    }

    private void MachineInteract()
    {
        if (canOven)
        {
            if (playerInput.objectValue == 3)
            {
                hasObject = true;
                playerInput.holdingObject = false;
                playerInput.CurrentItem(0);
            }
            if (objectComplete)
            {
                hasObject = false;
                playerInput.canPickup = false;
                playerInput.holdingObject = true;
                playerInput.CurrentItem(cookedMeat);
                cookingTimer = 0f;
                objectComplete = false;
            }
        }
    }
}
