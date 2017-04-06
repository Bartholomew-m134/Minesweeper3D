using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AccelerometerBehavior : MonoBehaviour {

    bool canLoad = true;
    public bool CanShake { get; set; }

    void Start() {
        CanShake = false;
    }
	// Update is called once per frame
	void Update () {

        if (Input.acceleration.magnitude > 2 && canLoad && CanShake) {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
            canLoad = false;
        }
    }

    public void ToggleCanShake() {
        CanShake = !CanShake;
    }
}
