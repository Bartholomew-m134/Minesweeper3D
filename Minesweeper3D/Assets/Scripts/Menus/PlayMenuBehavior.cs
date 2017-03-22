using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMenuBehavior : MonoBehaviour {

    public GameObject playMenu;

    public void LaunchNew2DGame() {
        SceneManager.LoadScene("Minesweeper");
    }

    public void LaunchNew3DGame() {
        SceneManager.LoadScene("Minesweeper");
    }
}
