using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuBehavior : MonoBehaviour {
    public GameObject mainMenu;
    public GameObject playMenu;
    public GameObject aboutMenu;

    public void GoToPlayMenu() {
        DisableAll();
        playMenu.SetActive(true);
    }

    public void GoToMainMenu() {
        DisableAll();
        mainMenu.SetActive(true);
    }

    public void GoToAboutMenu() {
        DisableAll();
        aboutMenu.SetActive(true);
    }

    private void DisableAll() {
        mainMenu.SetActive(false);
        playMenu.SetActive(false);
        aboutMenu.SetActive(false);

    }


}
