using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintName : MonoBehaviour {

	public void Print() {
        Debug.Log("Button Pressed: " + transform.name);
    }
}
