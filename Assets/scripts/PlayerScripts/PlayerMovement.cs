using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {


   
    public float moveSpeed;
    private Rigidbody PlayerRigidbody;
    public ShootingScriptRight rightHand;
    public ShootingScriptLeft leftHand;
    public float evadeTime;
    public float evadeTimer;
    public float evadeDist;
    public float cooldownTimer = 0;
    private bool evading;
    public Vector3 movement;

     void Awake()
    {
       
    }
    void Start ()
    {
        PlayerRigidbody = GetComponent<Rigidbody>();
  
	}


    void FixedUpdate()
    {
        // Store the input axes.
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Movement(h,v);
        Rotation();
        Evasion();
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



    void Movement (float h, float v)
    {
       
        movement.Set(h, 0f, v);

        movement = movement.normalized * moveSpeed * Time.deltaTime;

        PlayerRigidbody.MovePosition(transform.position + movement);
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
    void Evasion()
    {
        cooldownTimer = Mathf.Max(0f, cooldownTimer - Time.deltaTime);

        if (!evading && cooldownTimer == 0 && Input.GetKeyDown(KeyCode.Space))
        {
            evading = true;
            evadeTimer = evadeTime;
           
        }

        if(evading)
        {
            evadeTimer = Mathf.Max(0f, evadeTimer - Time.deltaTime);
            transform.Translate(movement * evadeDist , Space.World);
        }
        
        if(evadeTimer == 0)
        {
            evading = false;
        }
      
    }


}
