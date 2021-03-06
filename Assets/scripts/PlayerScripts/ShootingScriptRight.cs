﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootingScriptRight : MonoBehaviour {


    //skills
    //1 = smg
    //2 = shotgun
    //3 = fireball
    //4 = lightning


    public bool isFiringRight;

    public StandardBullet bullet;
    public StandardBullet smgBullet;
    public StandardBullet pellet;
    public Fireball fireballSpell;
    public GameObject lightSpell;
    public int WeaponChoiceR;
    public float bulletSpeed;

    public int maxMana = 100;
    private int maxAmmo = 15;

    public int currentAmmo;
    public float currentMana;
    public float reloadTime = 1f;
    private bool isReloading = false;

    public GameObject ShotCounterRight;
    public Text ShotText;
    public float shotTimerR;
    private float shotCounterR;
    public Slider ManaCounterRight;
    public GameObject ManaRight;

    public Transform firePointSpells;
    public Transform firePointShotgunR;
    public Transform firePointSmgR;
    public Transform firePointPistolR;

    public GameObject ShotgunR;
    public GameObject PistolR;
    public GameObject SmgR;

    public float ki = 20f;

    void Start ()
    {
        currentAmmo = maxAmmo;
        currentMana = maxMana;

    }

     void OnEnable()
    {
        isReloading = false;
    }

    // Update is called once per frame
    void FixedUpdate () {
        LoadoutSettings loadoutSettings = LoadoutSettings.instance;
        if (loadoutSettings)
        {
            WeaponChoiceR = loadoutSettings.RightDownValue + 4;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Keypad4))
                WeaponChoiceR = 4;
            if (Input.GetKeyDown(KeyCode.Keypad5))
                WeaponChoiceR = 5;
            if (Input.GetKeyDown(KeyCode.Keypad6))
                WeaponChoiceR = 6;
            if (Input.GetKeyDown(KeyCode.Keypad7))
                WeaponChoiceR = 7;
            if (Input.GetKeyDown(KeyCode.Keypad8))
                WeaponChoiceR = 8;
        }


        //pistol
        if (WeaponChoiceR == 4)
        {
            maxAmmo = 8;
            PistolR.SetActive(true);
            ShotgunR.SetActive(false);
            SmgR.SetActive(false);
            ShotCounterRight.SetActive(true);
            ManaRight.SetActive(false);
        }
        //shotgun
        else if (WeaponChoiceR == 8)
        {
            maxAmmo = 3;
            PistolR.SetActive(false);
            ShotgunR.SetActive(true);
            SmgR.SetActive(false);
            ShotCounterRight.SetActive(true);
            ManaRight.SetActive(false);
        }
        //smg
        else if (WeaponChoiceR == 7)
        {
            maxAmmo = 15;
            PistolR.SetActive(false);
            ShotgunR.SetActive(false);
            SmgR.SetActive(true);
            ShotCounterRight.SetActive(true);
            ManaRight.SetActive(false);
        }
        else
        {
            ShotCounterRight.SetActive(false); 
            PistolR.SetActive(false);
            ShotgunR.SetActive(false);
            SmgR.SetActive(false);
            ManaRight.SetActive(true);
        }


        if (isReloading)
            return;

            if (currentAmmo < 0 || Input.GetKeyDown("r"))
            {
                StartCoroutine(Reload());
                return;
            }
        ManaSystem();
        //UI ammo Counter
        ManaCounterRight.value = currentMana;
        ShotText.text = currentAmmo + "/" + maxAmmo;
        Pistol();
        Lightning();
        Fireball();
        Shotgun();
        Smg();

    }
    IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        isReloading = false;
    }
    public void ManaSystem()
    {

        if (currentMana <= 0)
        {
            currentMana = 0;
        }
        else if (currentMana >= maxMana)
        {
            currentMana = maxMana;
        }
        if (currentMana < maxMana)
        {
            currentMana += ki * Time.fixedDeltaTime;
        }

    }

    public void Pistol()
    {
       
        //StandardBullets
        if (WeaponChoiceR == 4)
        {
           
            if (isFiringRight)
            {
                shotCounterR -= Time.fixedDeltaTime;
                if (shotCounterR <= 0)
                {
                    shotCounterR = shotTimerR;
                    StandardBullet newBullet = Instantiate(bullet, firePointPistolR.position, firePointPistolR.rotation) as StandardBullet;
                    newBullet.speed = bulletSpeed;
                    currentAmmo -= 1;
                }

            }

            else
            {
                shotCounterR = 0;

            }
        }
    }
    public void Shotgun()
    {

        float spread = 0.02f;
        int count = 4;
        int i = 0;
        if (WeaponChoiceR == 8)
        {
            if (isFiringRight)
            {
                shotCounterR -= Time.fixedDeltaTime;
                if (shotCounterR <= 0)
                {

                    shotCounterR = shotTimerR;
                    while (i < count)
                    {
                        var Pellet = firePointShotgunR.rotation;
                        Pellet.x += Random.Range(-spread, spread);
                        Pellet.y += Random.Range(-spread, spread);
                        StandardBullet newBullet0 = Instantiate(pellet, firePointShotgunR.position, Pellet) as StandardBullet;
                        newBullet0.speed = bulletSpeed;
                        i++;
                    }
                    currentAmmo -= 1;
                }
            }

            else
            {
                shotCounterR = 0;

            }
        }


    }
    public void Smg()
    {

            if (WeaponChoiceR == 7)
            {
                float spread = .2f;
                if (isFiringRight)
                {
                    shotCounterR -= .2f;
                    if (shotCounterR <= 0)
                    {
                        if (shotCounterR <= 0)
                        {
                            var Pellet = firePointSmgR.rotation;
                            Pellet.x += Random.Range(-spread, spread);
                            Pellet.y += Random.Range(-spread, spread);
                            shotCounterR = shotTimerR;
                            StandardBullet newBullet = Instantiate(smgBullet, firePointSmgR.position, Pellet) as StandardBullet;
                            newBullet.speed = bulletSpeed;
                            currentAmmo -= 1;
                        }

                    }

                    else
                    {
                        shotCounterR = 0;

                    }
                }
            
            }
    }

    public void Fireball()
    {

        {
            int ManaCost = 8;
            //FireBall spell
            if (WeaponChoiceR == 5)
            {
                if (isFiringRight && currentMana > 0)
                {
                    shotCounterR -= Time.fixedDeltaTime;
                    if (currentMana > ManaCost)
                    {
                        shotCounterR = shotTimerR;
                        Fireball newFireballSpell = Instantiate(fireballSpell, firePointSpells.position, firePointSpells.rotation) as Fireball;
                        newFireballSpell.speed = bulletSpeed;
                        currentMana -= ManaCost;
                    }
                }
                else
                {
                    shotCounterR = 0;

                }

            }
        }
    }
        public void Lightning()
        {

            {
                int ManaCost = 2;
                //Lightning spell
                if (WeaponChoiceR == 6)
                {
                    if (isFiringRight && currentMana > ManaCost)
                    {
                        shotCounterR -= Time.fixedDeltaTime;
                        lightSpell.SetActive(true);
                        currentMana -= ManaCost;
                    }

                    else
                    {
                        lightSpell.SetActive(false);
                    }

                }
            }
        }
    }



