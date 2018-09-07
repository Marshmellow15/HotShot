using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour {


    Animator anim;
    public GameObject player;
    public float fireRate;
    public float bulletSpeed;
    public StandardBullet bullet;
    public GameObject Firepoint;



    public GameObject GetPlayer()
    {
        return player;
    }

	void Start ()
    {
        anim = GetComponent<Animator>();	
	}
	
	// Update is called once per frame
	void Update ()
    {
        anim.SetFloat("Distance", Vector3.Distance(transform.position, player.transform.position));
	}

    void Fire()
    {
        StandardBullet newBullet = Instantiate(bullet, Firepoint.transform.position, Firepoint.transform.rotation) as StandardBullet;
        newBullet.speed = bulletSpeed;
    }

    public  void StartFiring()
    {
        InvokeRepeating("Fire", 0.3f, 0.3f);
    }

    public void StopFiring()
    {
        CancelInvoke("Fire");
    }


}
