using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fryer : MonoBehaviour
{
    public Player_Input playerInput;
    public Animator animator;

    //checks
    public bool hasObject;
    private bool cooking;
    public bool objectComplete;
    public bool canFryer;

    //operation
    public float cookingTimer;
    public float cookTime;
    public int fries = 6;

    private void OnEnable()
    {
        Player_Input.OnInteract += MachineInteract;
        animator = GetComponentInChildren<Animator>();
    }
    // Start is called before the first frame update
    private void Start()
    {
        hasObject = false;
        canFryer = false;
        objectComplete = false;
        playerInput = FindObjectOfType<Player_Input>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (hasObject && cookingTimer <= cookTime)
        {
            animator.SetBool("isCooking", true);
            cookingTimer += Time.deltaTime;
            cooking = true;
        }
        else if (cookingTimer >= cookTime)
        {
            cooking = false;
            objectComplete = true;
            animator.SetBool("isCooking", false);
            animator.SetBool("isDone", true);
        }
    }

    private void MachineInteract()
    {
        if (canFryer)
        {
            if (playerInput.objectValue == 2)
            {
                animator.SetBool("isDone", false);
                hasObject = true;
                playerInput.holdingObject = false;
                playerInput.CurrentItem(0);
            }
            if (objectComplete)
            {
                animator.SetBool("isDone", false);
                hasObject = false;
                playerInput.canPickup = true;
                playerInput.holdingObject = true;
                playerInput.CurrentItem(fries);
                cookingTimer = 0f;
                objectComplete = false;
            }
        }
    }
}
