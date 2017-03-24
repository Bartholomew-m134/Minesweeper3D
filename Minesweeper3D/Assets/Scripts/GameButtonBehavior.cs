using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameButtonBehavior : MonoBehaviour {

    public GameObject grid;
    // Use this for initialization
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

    // Update is called once per frame
    void Update () {
		
	}
}
