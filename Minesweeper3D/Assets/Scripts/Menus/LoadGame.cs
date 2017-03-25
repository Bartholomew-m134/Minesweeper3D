using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

   public void LoadPreviousGame() {
        LevelSerializer.SaveEntry sg = (LevelSerializer.SavedGames[LevelSerializer.PlayerName])[0];
        LevelSerializer.LoadSavedLevel(sg.Data);
    }
}
