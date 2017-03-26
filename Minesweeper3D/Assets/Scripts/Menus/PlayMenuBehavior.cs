using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMenuBehavior : MonoBehaviour {

    public GameObject playMenu;
    private bool canLoad = true;

    public void LaunchNew2DGame() {
        if (canLoad) {
            SceneManager.LoadScene("Minesweeper", LoadSceneMode.Single);
            canLoad = false;
        }
    }

    public void LaunchNew3DGame() {
     if (canLoad) { 
        SceneManager.LoadScene("Minesweeper3D", LoadSceneMode.Single);
        canLoad = false;
    }
}
}
