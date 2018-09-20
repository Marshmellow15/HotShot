using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {
    public float speed;

    void Start()
    {
        DestroyObjectDelayed();

    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        var hit = collision.gameObject;
        var health = hit.GetComponent<PlayerHealth>();
        var enemyHealth = hit.GetComponent<EnemyAi>();
        if (health != null)
        {
            health.TakeDamage(10);
        }
        if (enemyHealth != null)
        {
            enemyHealth.EnemyTakeDamage(15);
        }
        Destroy(gameObject);
    }
    void DestroyObjectDelayed()
    {

        Destroy(gameObject, 2f);
    }

}