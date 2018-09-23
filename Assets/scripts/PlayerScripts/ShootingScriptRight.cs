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

    public Transform firePoint;


	void Start ()
    {
        currentAmmo = maxAmmo;
        currentMana = maxMana;
        WeaponChoiceR = 4;	
	}

     void OnEnable()
    {
        isReloading = false;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Keypad4))
            WeaponChoiceR = 4;
        if (Input.GetKeyDown(KeyCode.Keypad5))
            WeaponChoiceR = 5;
        if (Input.GetKeyDown(KeyCode.Keypad6))
            WeaponChoiceR = 6;

        if (isReloading)
            return;

            if (currentAmmo <= 0 || Input.GetKeyDown("r"))
            {
                StartCoroutine(Reload());
                return;
            }
        //UI ammo Counter
        ShotText.text = currentAmmo + "/" + maxAmmo;


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
                currentAmmo -= 1;
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
        if (isFiringRight && currentMana > 0)
        {
            shotCounterR -= Time.deltaTime;
            if (shotCounterR <= 0)
            {
                shotCounterR = shotTimerR;
                Fireball newFireballSpell = Instantiate(fireballSpell, firePoint.position, firePoint.rotation) as Fireball;
                newFireballSpell.speed = bulletSpeed;
                currentMana -= 8;
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
    IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        isReloading = false;
    }
}