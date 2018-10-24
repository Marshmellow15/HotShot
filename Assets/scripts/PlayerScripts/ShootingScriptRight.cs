using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootingScriptRight : MonoBehaviour {

    public bool isFiringRight;

    public StandardBullet bullet;
    public Fireball fireballSpell;
    public Lightning lightningSpell;
    public GameObject lightSpell;
    public int WeaponChoiceR;
    public float bulletSpeed;

    public int maxMana = 40;
    public int maxAmmo = 15;

    public int currentAmmo;
    public int currentMana;
    public float reloadTime = 1f;
    private bool isReloading = false;

    public Text ShotText;
    public float shotTimerR;
    private float shotCounterR;

    public Transform firePointSpells;
    public Transform firePointShotgunR;
    public Transform firePointSmgR;
    public Transform firePointPistolR;

    public GameObject ShotgunR;
    public GameObject PistolR;
    public GameObject SmgR;
    

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
            PistolR.SetActive(true);
            ShotgunR.SetActive(false);
            SmgR.SetActive(false);
        }
        //shotgun
        else if (WeaponChoiceR == 8)
        {
            PistolR.SetActive(false);
            ShotgunR.SetActive(true);
            SmgR.SetActive(false);
        }
        //smg
        else if (WeaponChoiceR == 7)
        {
            PistolR.SetActive(false);
            ShotgunR.SetActive(false);
            SmgR.SetActive(true);
        }
        else
        {
            PistolR.SetActive(false);
            ShotgunR.SetActive(false);
            SmgR.SetActive(false);
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
        float spread = .2f;
        int count = 1;
        int i = 0;
        if (WeaponChoiceR == 8)
        {
            if (isFiringRight)
            {
                if (shotCounterR <= 0)
                {
                    var Pellet = firePointShotgunR.rotation;
                    Pellet.x += Random.Range(-spread, spread);
                    Pellet.y += Random.Range(-spread, spread);
                    shotCounterR = shotTimerR;
                    while(i < count)
                    {
                        i++;
                        StandardBullet newBullet1 = Instantiate(bullet, firePointShotgunR.position, Pellet) as StandardBullet;
                        StandardBullet newBullet2 = Instantiate(bullet, firePointShotgunR.position, Pellet) as StandardBullet;
                        StandardBullet newBullet3 = Instantiate(bullet, firePointShotgunR.position, Pellet) as StandardBullet;
                        newBullet1.speed = bulletSpeed;
                        newBullet2.speed = bulletSpeed;
                        newBullet2.speed = bulletSpeed;
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
                        StandardBullet newBullet = Instantiate(bullet, firePointSmgR.position, Pellet) as StandardBullet;
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
        //FireBall spell
        if (WeaponChoiceR == 5)
        {
            if (isFiringRight && currentMana > 0)
            {
                shotCounterR -= Time.fixedDeltaTime;
                if (shotCounterR <= 0)
                {
                    shotCounterR = shotTimerR;
                    Fireball newFireballSpell = Instantiate(fireballSpell, firePointSpells.position, firePointSpells.rotation) as Fireball;
                    newFireballSpell.speed = bulletSpeed;
                }
            }
            else
            {
                shotCounterR = 0;

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
        if (WeaponChoiceR == 6)
        {
            if (isFiringRight)
            {
                shotCounterR -= Time.fixedDeltaTime;
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