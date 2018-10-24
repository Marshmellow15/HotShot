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

    public Transform firePointSpells;
    public Transform firePointShotgunL;
    public Transform firePointSmgL;
    public Transform firePointPistolL;

    public GameObject ShotgunL;
    public GameObject PistolL;
    public GameObject SmgL;

    void Start()
    {
        currentAmmo = maxAmmo;
        currentMana = maxMana;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        LoadoutSettings loadoutSettings = LoadoutSettings.instance;
        if (loadoutSettings)
        {
            WeaponChoiceL = loadoutSettings.LeftDownValue + 1;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Keypad1))
                WeaponChoiceL = 1;
            if (Input.GetKeyDown(KeyCode.Keypad2))
                WeaponChoiceL = 2;
            if (Input.GetKeyDown(KeyCode.Keypad3))
                WeaponChoiceL = 3;
            if (Input.GetKeyDown(KeyCode.Keypad7))
                WeaponChoiceL = 7;
            if (Input.GetKeyDown(KeyCode.Keypad8))
                WeaponChoiceL = 8;
        }

        //pistol
        if (WeaponChoiceL == 1)
        {
            PistolL.SetActive(true);
            ShotgunL.SetActive(false);
            SmgL.SetActive(false);
        }
        //shotgun
        else if (WeaponChoiceL == 8)
        {
            ShotgunL.SetActive(true);
            SmgL.SetActive(false);
            PistolL.SetActive(false);
        }
        //smg
        else if (WeaponChoiceL == 7)
        { 
            SmgL.SetActive(true);
            ShotgunL.SetActive(false);
            PistolL.SetActive(false);
        }
        else
        {
            PistolL.SetActive(false);
            ShotgunL.SetActive(false);
            SmgL.SetActive(false);
        }


        if (isReloading)
            return;

        if (currentAmmo < 0 || Input.GetKeyDown("r"))
        {
            StartCoroutine(Reload());
            return;
        }

        //UI ammo Counter
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

    public void Pistol()
    {
        //StandardBullets
        if (WeaponChoiceL == 1)
        {
            maxAmmo = 25;
            if (isFiringLeft)
            {
                shotCounterL -= Time.fixedDeltaTime;
                if (shotCounterL <= 0)
                {
                    shotCounterL = shotTimerL;
                    StandardBullet newBullet = Instantiate(bullet, firePointPistolL.position, firePointPistolL.rotation) as StandardBullet;
                    newBullet.speed = bulletSpeed;
                    currentAmmo -= 1;
                }
            }

            else
            {
                shotCounterL = 0;

            }
        }
    }

    public void Smg()
    {
        //StandardBullets
        if (WeaponChoiceL == 7)
        {
            float spread = 0.2f;
            if (isFiringLeft)
            {
                shotCounterL -= .2f;
                if (shotCounterL <= 0)
                {
                    shotCounterL = shotTimerL;
                    var Pellet = firePointSmgL.rotation;
                    Pellet.x += Random.Range(-spread, spread);
                    Pellet.y += Random.Range(-spread, spread);
                    shotCounterL = shotTimerL;
                    StandardBullet newBullet0 = Instantiate(bullet, firePointSmgL.position, Pellet) as StandardBullet;
                    newBullet0.speed = bulletSpeed;
                    currentAmmo -= 1;
                }
            }

            else
            {
                shotCounterL = 0;

            }
        }
    }

    public void Shotgun()
    {
        float spread = 0.02f;
        int count = 1;
        int i = 0;
        if (WeaponChoiceL == 8)
        {
            if (isFiringLeft)
            {
                shotCounterL -= Time.fixedDeltaTime;
                if (shotCounterL <= 0)
                {
                    var Pellet = firePointShotgunL.rotation;
                    Pellet.x += Random.Range(-spread, spread);
                    Pellet.y += Random.Range(-spread, spread);
                    shotCounterL = shotTimerL;
                    while (i < count)
                    {
                        i++;
                        StandardBullet newBullet0 = Instantiate(bullet, firePointShotgunL.position, Pellet) as StandardBullet;
                        newBullet0.speed = bulletSpeed;
                    }
                    currentAmmo -= 1;
                }
            }

            else
            {
                shotCounterL = 0;

            }
        }
    }

    public void Fireball()
    {
        //FireBall spell
        if (WeaponChoiceL == 2)
        {
            if (isFiringLeft && currentMana > 0)
            {
                shotCounterL -= Time.fixedDeltaTime;
                if (shotCounterL <= 0)
                {
                    shotCounterL = shotTimerL;
                    Fireball newFireballSpell = Instantiate(fireballSpell, firePointSpells.position, firePointSpells.rotation) as Fireball;
                    newFireballSpell.speed = bulletSpeed;

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
    }
    public void Lightning()
    {
        //Lightning spell
        if (WeaponChoiceL == 3)
        {
            if (isFiringLeft)
            {
                shotCounterL -= Time.fixedDeltaTime;
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
