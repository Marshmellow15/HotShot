using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour {


	public void Start ()
    {
  
     
    }

    void Update()
    {

        
    }

    private void OnParticleCollision(GameObject other)
    {
        //ParticlePhysicsExtensions.GetCollisionEvents(LightningSystem, other, collsionEvent);
        Debug.Log("Hit enemy");
       EnemyAi enemyHealth = other.GetComponent<EnemyAi>();

        if (enemyHealth != null)
        {
            enemyHealth.EnemyTakeDamage(15);
        }
    }
}
