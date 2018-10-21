using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeapons : MonoBehaviour
{
    public GameObject ShotgunR;
    public GameObject ShotgunL;
    public GameObject PistolL;
    public GameObject PistolR;
    public GameObject SmgL;
    public GameObject SmgR;

    public int selectedWeaponR = 0;


    void Start()
    {
        SelectWeapon();   
    }


    void SelectWeapon()
    {

        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeaponR)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }



}
