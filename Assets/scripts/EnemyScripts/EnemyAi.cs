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
    public GameObject[] waypoints;
    public int EnemyHealth = 25;
    public int currentEnemyHealth;


    public GameObject GetPlayer()
    {
        
        return player;
    }
    private void Awake()
    {
        currentEnemyHealth = EnemyHealth;
    }
    void Start ()
    {
       
        anim = GetComponent<Animator>();	
	}
	
	// Update is called once per frame
	void Update ()
    {
        float distance = float.MaxValue;

        Vector3 dir = player.transform.position - gameObject.transform.position;
        dir.Normalize();

        RaycastHit raycastHit;
        if (Physics.Raycast(gameObject.transform.position, dir, out raycastHit))
        {
            if (raycastHit.collider.CompareTag("Player")) {
                distance = Vector3.Distance(transform.position, raycastHit.point);
            }
        }
        anim.SetFloat("Distance", distance);
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
    public void EnemyTakeDamage(int Damage)
    {
        currentEnemyHealth -= Damage;

        if (currentEnemyHealth <= 0)
        {
            currentEnemyHealth = 0;
            Destroy(gameObject);
        }

    }

}
