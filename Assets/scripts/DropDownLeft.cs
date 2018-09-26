using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDownLeft : MonoBehaviour
{
    public Dropdown L_Dropdown;
    public int LeftDownValue;

    void Start()
    {
        //L_Dropdown = GetComponent<Dropdown>();
    }
  


    public void Update()
    {
        if (L_Dropdown)
        {
            LeftDownValue = L_Dropdown.value;
        }
    }
}
