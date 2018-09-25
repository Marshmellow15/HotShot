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
        L_Dropdown = GetComponent<Dropdown>();
    }
  


    void Update()
        {
            LeftDownValue = L_Dropdown.value;
        }
}
