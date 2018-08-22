using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {



    public float moveSpeed;
    private Rigidbody PlayerRigidbody;

    private Vector3 moveInput;
    private Vector3 moveVelocity;
    public ShootingScriptRight rightHand;
    public ShootingScriptLeft leftHand;
    private Camera mainCamera;

	void Start ()
    {
        PlayerRigidbody = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
	}


    void Update()
    {
        //Movement
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * moveSpeed;
        //Looking 
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);

        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;
        //point character to camera
        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);


            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }
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

    void FixedUpdate()
    {
        PlayerRigidbody.velocity = moveVelocity;
    }


}
