using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wep_Soda : Player_Weapon
{
    // Start is called before the first frame update
    void Start()
    {
        Player_Input.OnShoot += Shoot;
    }

    private void Shoot()
    {

    }
}
