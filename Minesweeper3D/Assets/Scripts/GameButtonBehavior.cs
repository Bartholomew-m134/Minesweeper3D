using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameButtonBehavior : MonoBehaviour {

    public GameObject grid;
    
    public void UpButtonPress() {
        grid.transform.Rotate(45, 0, 0);
    }

    public void DownButtonPress()
    {
        grid.transform.Rotate(-45, 0, 0);
    }

    public void RightButtonPress() {
        grid.transform.Rotate(0, 45, 0);
    }

    public void LeftButtonPress() {
        grid.transform.Rotate(0, -45, 0);
    }

    public void FlagButtonPress() {
        var manager = grid.GetComponent<MinesweeperManager>();


    }

    // Update is called once per frame
    void Update () {
		
	}
}
