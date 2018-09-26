using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadoutSettings : MonoBehaviour {

    public static LoadoutSettings instance = null;

    public Dropdown L_Dropdown;
    public Dropdown R_Dropdown;


    public int LeftDownValue;
    public int RightDownValue;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
	
	// Update is called once per frame
	void Update () {
		if (L_Dropdown)
        {
            LeftDownValue = L_Dropdown.value;
        }
        if (R_Dropdown)
        {
            RightDownValue = R_Dropdown.value;
        }
    }
}
