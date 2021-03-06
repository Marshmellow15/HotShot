﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SkillButton : MonoBehaviour {

    public int skillId;
    public Color unlockedColor;
    public SkillHub skillhub;

    private Image _image;
    private Button _button;


	void Start ()
    {
        _image = GetComponent<Image>();
        _button = GetComponent<Button>();

        RefreshState();
    }


    public void RefreshState()
    {
        if (SkillTreeReader.Instance.IsSkillUnlocked(skillId))
        {
            _image.color = unlockedColor;
        }
        else if (!SkillTreeReader.Instance.CanSkillBeUnlocked(skillId))
        {
            _button.interactable = false;
        }
        else
        {
            _image.color = Color.white;
            _button.interactable = true;
        }
    }

    public void BuySkill()
    {
        if (SkillTreeReader.Instance.UnlockSkill(skillId))
        {
            PlayerPrefs.SetInt("Score", SkillTreeReader.Instance.availablePoints);
            skillhub.RefreshButtons();
        }
    }
}