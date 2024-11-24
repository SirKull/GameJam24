using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wep_Salad : Player_Weapon
{
    public Player_Input playerInput;
    public ParticleSystem saladParticles;
    public GameObject damageTrigger;
    public GameObject particleObject;
    public float particleTimer;
    public float shootTime;
    public bool isShoot;
    public bool isActive;
    private void Start()
    {
        isShoot = false;
        particleTimer = 0f;
        Player_Input.OnShoot += Shoot;
        playerInput = GetComponentInParent<Player_Input>();
        particleObject = GameObject.FindWithTag("ParticleSystem");
        saladParticles.Stop();
        damageTrigger.SetActive(false);
    }
    private void Update()
    {
        if(isShoot == true && isActive)
        {
            saladParticles.Play();
            damageTrigger.SetActive(true);
            particleTimer += Time.deltaTime;
            if(particleTimer >= shootTime)
            {
                StopShoot();
                DisableWep();
            }
        }
    }
    private void OnEnable()
    {
        isActive = true;
    }
    private void OnDisable()
    {
        isActive = false;
    }
    private void Shoot()
    {
        isShoot = true;
    }
    public void StopShoot()
    {
        isShoot = false;
        particleTimer = 0;
        saladParticles.Stop();
        damageTrigger.SetActive(false);
    }
    private void DisableWep()
    {
        playerInput.holdingWeapon = false;
        playerInput.hasSalad = false;
        playerInput.CurrentWeapon(0);
    }
}
