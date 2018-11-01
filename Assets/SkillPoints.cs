using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillPoints : MonoBehaviour {

    public Text skillText;

    void Awake()
    {
        skillText = GetComponent<Text>();
    }

    void Update()
    {
        
        skillText.text = PlayerPrefs.GetInt("Score", 0).ToString();
        
    }
}