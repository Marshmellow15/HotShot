using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DropDownRight : MonoBehaviour {


    public Dropdown R_Dropdown;
    public int RightDownValue;
    void Start ()
    {
        R_Dropdown = GetComponent<Dropdown>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        RightDownValue = R_Dropdown.value;
    }
}
