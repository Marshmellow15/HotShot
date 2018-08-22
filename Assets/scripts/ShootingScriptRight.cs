using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScriptRight : MonoBehaviour {

    public bool isFiringRight;

    public StandardBullet bullet;
    public float bulletSpeed;

    public float shotTimerR;
    private float shotCounterR;

    public Transform firePoint;


	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(isFiringRight)
        {
            shotCounterR -= Time.deltaTime;
            if(shotCounterR <= 0)
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
}
