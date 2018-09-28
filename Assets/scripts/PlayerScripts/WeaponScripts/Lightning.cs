using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour {

    public ParticleSystem LightningSystem;

    List<ParticleCollisionEvent> collsionEvent;

	public void Start ()
    {
        collsionEvent = new List<ParticleCollisionEvent>();
    }

    void Update()
    {
        ParticleSystem.MainModule psMain = LightningSystem.main;
        
    }

    private void OnParticleCollision(GameObject other)
    {
        ParticlePhysicsExtensions.GetCollisionEvents(LightningSystem, other, collsionEvent);
        Debug.Log("Hit enemy");
        for (int i =0; i < collsionEvent.Count; i++)
        {
            Debug.Log("Hit enemy");
        }
    }
}
