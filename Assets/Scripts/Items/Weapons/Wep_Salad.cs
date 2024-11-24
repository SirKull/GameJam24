using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wep_Salad : Player_Weapon
{
    public ParticleSystem saladParticles;
    public GameObject damageTrigger;
    public GameObject particleObject;
    public float particleTimer;
    public float shootTime;
    public bool isShoot;
    private void Awake()
    {
        particleTimer = 0f;
        Player_Input.OnShoot += Shoot;
        particleObject = GameObject.FindWithTag("ParticleSystem");
        saladParticles.Stop();
        damageTrigger.SetActive(false);
    }
    private void Update()
    {
        if(isShoot == true)
        {
            saladParticles.Play();
            damageTrigger.SetActive(true);
            particleTimer += Time.deltaTime;
            if(particleTimer >= shootTime)
            {
                StopShoot();
            }
        }
    }
    private void Shoot()
    {
        isShoot = true;
    }
    public void StopShoot()
    {
        isShoot = false;
        saladParticles.Stop();
        damageTrigger.SetActive(false);
    }
}
