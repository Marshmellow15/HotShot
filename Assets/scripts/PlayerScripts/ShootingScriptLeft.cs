using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScriptLeft : MonoBehaviour {
    public bool isFiringLeft;

    public StandardBullet bullet;
    public Fireball fireballSpell;
    public Lightning lightningSpell;
    public GameObject lightSpell;
    public int WeaponChoice;
    public float bulletSpeed;

    public float shotTimerL;
    private float shotCounterL;

    public Transform firePoint;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //StandardBullets
        if (WeaponChoice == 1)
        {
            if (isFiringLeft)
            {
                shotCounterL -= Time.deltaTime;
                if (shotCounterL <= 0)
                {
                    shotCounterL = shotTimerL;
                    StandardBullet newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as StandardBullet;
                    newBullet.speed = bulletSpeed;
                }
            }

            else
            {
                shotCounterL = 0;

            }
        }
        //FireBall spell
        if (WeaponChoice == 2)
        {
            if (isFiringLeft)
            {
                shotCounterL -= Time.deltaTime;
                if (shotCounterL <= 0)
                {
                    shotCounterL = shotTimerL;
                    Fireball newFireballSpell = Instantiate(fireballSpell, firePoint.position, firePoint.rotation) as Fireball;
                    newFireballSpell.speed = bulletSpeed;
                       
                }
            }

            else
            {
                shotCounterL = 0;

            }
        }
        //Lightning spell
        if (WeaponChoice == 3)
        {
            if (isFiringLeft)
            {
                shotCounterL -= Time.deltaTime;
                if (shotCounterL <= 0)
                {
                    shotCounterL = shotTimerL;
                    lightSpell.SetActive(true);

                }
              
                
            }

            else
            {
                shotCounterL = 0;
                lightSpell.SetActive(false);
            }
        }




    }
}
