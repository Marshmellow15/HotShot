﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {


    private Lightning lightning;
    public float moveSpeed;
    private Rigidbody PlayerRigidbody;
    public ShootingScriptRight rightHand;
    public ShootingScriptLeft leftHand;

     void Awake()
    {
        lightning = GetComponent<Lightning>();
    }
    void Start ()
    {
        PlayerRigidbody = GetComponent<Rigidbody>();
  
	}


    void Update()
    {
        Movement();
        Rotation();

        //Right Hand shooting
        if (Input.GetMouseButtonDown(1))
        {
            rightHand.isFiringRight = true;

        }
 
        if (Input.GetMouseButtonUp(1))
        {
            rightHand.isFiringRight = false;
        }
        

        //Left Hand Shooting
        if (Input.GetMouseButtonDown(0))
        {
            leftHand.isFiringLeft = true;

        }
        if (Input.GetMouseButtonUp(0))
        {
            leftHand.isFiringLeft = false;
        }

    }



    void Movement ()
    {
        float horiz= Input.GetAxis("Horizontal");
        float verti   = Input.GetAxis("Vertical");

        Vector3 _movement = new Vector3(horiz, 0, verti);
        if(_movement.magnitude > 1 )
        {
            _movement.Normalize();
        }
        transform.Translate(_movement * moveSpeed * Time.deltaTime, Space.World);

    }
    void Rotation()
    {
        RaycastHit _hit;
        Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_ray, out _hit))
        {
            transform.LookAt(new Vector3(_hit.point.x, transform.position.y, _hit.point.z));
        }

    }


}
