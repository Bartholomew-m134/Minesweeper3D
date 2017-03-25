using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCubeBehavior : MonoBehaviour {

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RightButtonPress() {
        transform.Rotate(0, 45, 0);
    }

    public void LeftButtonPress() {
        transform.Rotate(0, -45, 0);
    }
}
