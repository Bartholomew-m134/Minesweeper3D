using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerUpdate : MonoBehaviour {
    public Text timerText;
    private float time;
    MinesweeperManager manager;
	// Use this for initialization
	void Start () {
        time = 0;
        manager = GameObject.Find("Cube").GetComponent<MinesweeperManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!manager.GameOver)
        {
            time += Time.deltaTime;
            timerText.text = time.ToString("F2");
        }
	}
}
