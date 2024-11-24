using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salad_Trigger : MonoBehaviour
{
    public GameObject saladTrigger;
    public Wep_Salad saladWeapon;

    private void Start()
    {
        saladWeapon = FindAnyObjectByType<Wep_Salad>();
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Flounder"))
        {
            Debug.Log("Customer Hit");
            IDamageable damageable = other.transform.GetComponent<IDamageable>();
            damageable?.Damage();
            saladWeapon.StopShoot();
            saladTrigger.SetActive(false);
        }
    }
}
