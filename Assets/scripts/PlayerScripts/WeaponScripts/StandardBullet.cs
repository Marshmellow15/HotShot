using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardBullet : MonoBehaviour {
    
    public float speed;
   
	void Start ()
    {
        DestroyObjectDelayed();

    }

	void Update () {
        transform.Translate(Vector3.forward * speed* Time.deltaTime);
	}

     void OnCollisionEnter(Collision collision)
    {
        var hit = collision.gameObject;
        PlayerHealth health = hit.GetComponent<PlayerHealth>();
        EnemyAi enemyHealth = hit.GetComponent<EnemyAi>();
        if (health != null)
        {
            health.TakeDamage(10);
        }
        if(enemyHealth != null)
        {
            enemyHealth.EnemyTakeDamage(15);
        }
        if (!hit.CompareTag("bullet"))
        {
            Destroy(gameObject);
        }
    }
    void DestroyObjectDelayed()
    {

        Destroy(gameObject, 2f);
    }
   
    }
