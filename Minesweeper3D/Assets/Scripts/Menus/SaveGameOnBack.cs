using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveGameOnBack : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SaveGame() {
        LevelSerializer.SaveGame("Your Game");
        SceneManager.LoadScene("MainMenu");
    }
}
