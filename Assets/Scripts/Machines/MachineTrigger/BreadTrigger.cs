using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadTrigger : MonoBehaviour
{
    public Animator animator;
    private void OnTriggerEnter2D(Collider2D other)
    {
        animator.SetBool("isTriggered", true);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        animator.SetBool("isTriggered", false);
    }
}
