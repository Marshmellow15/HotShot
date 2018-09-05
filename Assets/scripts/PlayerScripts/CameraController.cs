using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public Transform player;
    public Vector3 playerOffset;
    public float movementSpeed;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        moveCamera();	
	}

    void moveCamera()
    {
        transform.position = Vector3.Lerp(transform.position, player.position + playerOffset, movementSpeed * Time.deltaTime);
    }



}
