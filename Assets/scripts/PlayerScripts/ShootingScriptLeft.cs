using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootingScriptLeft : MonoBehaviour {

    public bool isFiringLeft;

    public StandardBullet bullet;
    public StandardBullet SmgBullet;
    public StandardBullet pellet;

    public Fireball fireballSpell;
    public GameObject lightSpell;

    public int WeaponChoiceL;
    public float bulletSpeed;

    public float shotTimerL;
    private float shotCounterL;

    public int maxMana = 100;
    public int maxAmmo = 15;
    public Text ShotText;
    public GameObject ManaLeft;

    public GameObject ShotCounterLeft;
    public  Slider ManaCounterLeft;
    public int currentAmmo;
    public float currentMana;
    public float reloadTime = 1f;
    private bool isReloading = false;

    public Transform firePointSpells;
    public Transform firePointShotgunL;
    public Transform firePointSmgL;
    public Transform firePointPistolL;

    public GameObject ShotgunL;
    public GameObject PistolL;
    public GameObject SmgL;

    public float ki = 20f;

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
            maxAmmo = 8;
            PistolL.SetActive(true);
            ShotgunL.SetActive(false);
            SmgL.SetActive(false);
            ShotCounterLeft.SetActive(true);
            ManaLeft.SetActive(false);
        }
        //shotgun
        else if (WeaponChoiceL == 8)
        {
            maxAmmo = 3;
            ShotgunL.SetActive(true);
            SmgL.SetActive(false);
            PistolL.SetActive(false);
            ShotCounterLeft.SetActive(true);
            ManaLeft.SetActive(false);
        }
        //smg
        else if (WeaponChoiceL == 7)
        {
            maxAmmo = 15;
            SmgL.SetActive(true);
            ShotgunL.SetActive(false);
            PistolL.SetActive(false);
            ShotCounterLeft.SetActive(true);
            ManaLeft.SetActive(false);
        }
        else
        {
            ShotCounterLeft.SetActive(false);
            PistolL.SetActive(false);
            ShotgunL.SetActive(false);
            SmgL.SetActive(false);
            ManaLeft.SetActive(true);
        }
        if (isReloading)
            return;

        if (currentAmmo < 0 || Input.GetKeyDown("r"))
        {
            StartCoroutine(Reload());
            return;
        }
        ManaSystem();
        //UI ammo Counter.
        ManaCounterLeft.value = currentMana;
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
        else if(currentMana >= maxMana)
        {
            currentMana = maxMana;
        }
        if(currentMana < maxMana)
        {
            currentMana += ki * Time.fixedDeltaTime;
        }

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
                    StandardBullet newBullet0 = Instantiate(SmgBullet, firePointSmgL.position, Pellet) as StandardBullet;
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
        int count = 4;
        int i = 0;
        if (WeaponChoiceL == 8)
        {
            if (isFiringLeft)
            {
                shotCounterL -= Time.fixedDeltaTime;
                if (shotCounterL <= 0)
                {
                  
                    shotCounterL = shotTimerL;
                    while (i < count)
                    {
                        var Pellet = firePointShotgunL.rotation;
                        Pellet.x += Random.Range(-spread, spread);
                        Pellet.y += Random.Range(-spread, spread);
                        StandardBullet newBullet0 = Instantiate(pellet, firePointShotgunL.position, Pellet) as StandardBullet;
                        newBullet0.speed = bulletSpeed;
                        i++;
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
        int ManaCost = 8;
        //FireBall spell
        if (WeaponChoiceL == 2)
        {
            if (isFiringLeft && currentMana > ManaCost )
            {
                
                if (shotCounterL <= 0)
                {
                    shotCounterL = shotTimerL;
                    Fireball newFireballSpell = Instantiate(fireballSpell, firePointSpells.position, firePointSpells.rotation) as Fireball;
                    newFireballSpell.speed = bulletSpeed;
                    currentMana -= ManaCost;
                }
            }

            else
            {
                shotCounterL = 0;

            }
        }

    }
    public void Lightning()
    {
        int ManaCost = 2;
        //Lightning spell
        if (WeaponChoiceL == 3)
        {
            if (isFiringLeft && currentMana > ManaCost)
            {
                shotCounterL -= Time.fixedDeltaTime;
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
