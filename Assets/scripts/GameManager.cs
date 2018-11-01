using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public PlayerHealth health;
    public float restartDelay = 3f;

    Animator anim;
    float restartTimer;

    public static int Score;

    Text scoreText;

    void Awake()
    {
        // Set up the reference.
        anim = GetComponent<Animator>();

        scoreText = GetComponent<Text>();

        Score = 0;

        SkillTreeReader.Instance.availablePoints = PlayerPrefs.GetInt("Score", 0);

    }

    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + Score;
         
        // If the player has run out of health...
        if (health.currentHealth <= 0)
        {
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score", 0) + Score);

            // ... tell the animator the game is over.
            anim.SetTrigger("GameOver");

            // .. increment a timer to count up to restarting.
            restartTimer += Time.deltaTime;

            // .. if it reaches the restart delay...
            if (restartTimer >= restartDelay)
            {
                // .. then reload the currently loaded level.

                SceneManager.LoadScene("Menu", LoadSceneMode.Single);
            }
        }
    }
}
