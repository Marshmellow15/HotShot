using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {

    public float speed;


	void Start ()
    {
        DestroyObjectDelayed();

    }

   
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
    void DestroyObjectDelayed()
    {

        Destroy(gameObject, 2f);
    }
}
