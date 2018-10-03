using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {

    public PlayerHealth health;
    public float restartDelay = 3f;

    Animator anim;
    float restartTimer;


    void Awake()
    {
        // Set up the reference.
        anim = GetComponent<Animator>();
    }

    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        // If the player has run out of health...
        if (health.currentHealth <= 0)
        {
            // ... tell the animator the game is over.
            anim.SetTrigger("GameOver");

            // .. increment a timer to count up to restarting.
            restartTimer += Time.deltaTime;

            // .. if it reaches the restart delay...
            if (restartTimer >= restartDelay)
            {
                // .. then reload the currently loaded level.

                SceneManager.LoadScene("LoadOut", LoadSceneMode.Single);
            }
        }
    }
}
