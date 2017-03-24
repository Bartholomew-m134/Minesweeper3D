using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AccelerometerBehavior : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
        if (Input.acceleration.magnitude > 2) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        Debug.Log(Input.acceleration.magnitude);
    }
}
