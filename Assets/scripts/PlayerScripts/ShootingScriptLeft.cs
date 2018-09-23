using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public int maxMana = 40;
    public int maxAmmo = 15;
    public Text ShotText;

    public int currentAmmo;
    public int currentMana;
    public float reloadTime = 1f;
    private bool isReloading = false;

    public Transform firePoint;


    void Start()
    {
        currentAmmo = maxAmmo;
        currentMana = maxMana;
        //WeaponChoiceL = 1;
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

        if (isReloading)
            return;

        if (currentAmmo < 0 || Input.GetKeyDown("r"))
        {
            StartCoroutine(Reload());
            return;
        }

        //UI ammo Counter
        ShotText.text = currentAmmo + "/" + maxAmmo;
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
                    currentAmmo -= 1;
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
            if (isFiringLeft && currentMana > 0)
            {
                shotCounterL -= Time.deltaTime;
                if (shotCounterL <= 0)
                {
                    shotCounterL = shotTimerL;
                    Fireball newFireballSpell = Instantiate(fireballSpell, firePoint.position, firePoint.rotation) as Fireball;
                    newFireballSpell.speed = bulletSpeed;
                    currentMana -= 8;
                }
            }

            else
            {
                shotCounterL = 0;

            }
        }
        if (currentMana <= 0)
        {
            currentMana = 0;
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
    IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        isReloading = false;
    }
}
