using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScriptLeft : MonoBehaviour {
    public bool isFiringLeft;

    public StandardBullet bullet;
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
}
