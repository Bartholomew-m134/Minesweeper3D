using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagToggle : MonoBehaviour {
    MinesweeperManager manager;
	// Use this for initialization
	void Start () {
        manager = GameObject.Find("Cube").GetComponent<MinesweeperManager>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void FlagButtonPress()
    {
        manager.ToggleFlag();

    }
}
