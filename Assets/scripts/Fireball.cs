using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {

    public float speed;


	void Start ()
    {
		
	}

   
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
