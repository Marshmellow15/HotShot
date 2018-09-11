using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScriptLeft : MonoBehaviour {
    public bool isFiringLeft;

    public StandardBullet bullet;
    public Fireball fireballSpell;
    public Lightning lightningSpell;
    public GameObject lightSpell;
    public int WeaponChoiceL;
    public float bulletSpeed;

    public float shotTimerL;
    private float shotCounterL;

    public Transform firePoint;


    void Start()
    {
        WeaponChoiceL = 1;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Keypad1))
            WeaponChoiceL = 1;
        if (Input.GetKeyDown(KeyCode.Keypad2))
            WeaponChoiceL = 2;
        if (Input.GetKeyDown(KeyCode.Keypad3))
            WeaponChoiceL = 3;


        //StandardBullets
        if (WeaponChoiceL == 1)
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
        if (WeaponChoiceL == 2)
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
        if (WeaponChoiceL == 3)
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
