using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScriptRight : MonoBehaviour {

    public bool isFiringRight;

    public StandardBullet bullet;
    public Fireball fireballSpell;
    public Lightning lightningSpell;
    public GameObject lightSpell;
    public int WeaponChoiceR;
    public float bulletSpeed;


    public float shotTimerR;
    private float shotCounterR;

    public Transform firePoint;


	void Start ()
    {
        WeaponChoiceR = 4;	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Keypad4))
            WeaponChoiceR = 4;
        if (Input.GetKeyDown(KeyCode.Keypad5))
            WeaponChoiceR = 5;
        if (Input.GetKeyDown(KeyCode.Keypad6))
            WeaponChoiceR = 6;


        

        //StandardBullets
        if (WeaponChoiceR == 4)
    {
        if (isFiringRight)
        {
            shotCounterR -= Time.deltaTime;
            if (shotCounterR <= 0)
            {
                shotCounterR = shotTimerR;
                StandardBullet newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as StandardBullet;
                newBullet.speed = bulletSpeed;
            }
        }

        else
        {
            shotCounterR = 0;

        }
    }
    //FireBall spell
    if (WeaponChoiceR == 5)
    {
        if (isFiringRight)
        {
            shotCounterR -= Time.deltaTime;
            if (shotCounterR <= 0)
            {
                shotCounterR = shotTimerR;
                Fireball newFireballSpell = Instantiate(fireballSpell, firePoint.position, firePoint.rotation) as Fireball;
                newFireballSpell.speed = bulletSpeed;

            }
        }

        else
        {
            shotCounterR = 0;

        }
    }
    //Lightning spell
    if (WeaponChoiceR == 6)
    {
        if (isFiringRight)
        {
            shotCounterR -= Time.deltaTime;
                if (shotCounterR <= 0)
                {
                    shotCounterR = shotTimerR;
                    lightSpell.SetActive(true);

                }
        }

        else
        {
            shotCounterR = 0;
            lightSpell.SetActive(false);
        }
    }

  }
}