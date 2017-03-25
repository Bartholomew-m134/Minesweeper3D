using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameButtonBehavior : MonoBehaviour {

    public GameObject grid;
    MinesweeperManager manager;
    public int buttonValue;
    public string spriteImage;

    public void Start() {

        manager = grid.GetComponent<MinesweeperManager>();
        if (!LevelSerializer.IsDeserializing) { 
            if (spriteImage == "")
            {
                spriteImage = "minesweeperTile";
            }
        }
        Debug.Log(spriteImage);
        gameObject.GetComponent<Button>().image.sprite = Resources.Load<Sprite>(spriteImage);
    }

    public void UpButtonPress() {
        grid.transform.Rotate(45, 0, 0);
    }

    public void DownButtonPress()
    {
        grid.transform.Rotate(-45, 0, 0);
    }

    public void RightButtonPress() {
        grid.transform.Rotate(0, 45, 0);
    }

    public void LeftButtonPress() {
        grid.transform.Rotate(0, -45, 0);
    }

 

    public void PressGridButton() {
        if (manager.IsPlacingFlag)
        {
            spriteImage = "flag";
        }
        else {
             if (buttonValue == -1 && !manager.GameOver)
            {
                //gameObject.GetComponent<Button>().image.sprite = Resources.Load<Sprite>("bomb");
                spriteImage = "bomb";
                gameObject.GetComponent<Button>().interactable = false;
                GameObject.Find("Canvases").transform.Find("GameOverCanvas").gameObject.SetActive(true);
                manager.GameOver = true;
                
            }
            else if (!manager.GameOver)
            {
                gameObject.GetComponentInChildren<Text>().text = buttonValue.ToString();
                //gameObject.GetComponent<Button>().image.sprite = Resources.Load<Sprite>("minesweeperBlank");
                spriteImage = "minesweeperBlank";
                gameObject.GetComponent<Button>().interactable = false;
                manager.EmptySpaces--;
                if (manager.EmptySpaces == 0) {
                    manager.GameOver = true;
                    GameObject.Find("Canvases").transform.Find("GameOverCanvas").gameObject.SetActive(true);
                    GameObject.Find("Canvases").transform.Find("GameOverCanvas").transform.Find("GameOverText").GetComponent<Text>().text = "You win!";
                }
            }
        }
    }

    // Update is called once per frame
    void Update () {
        gameObject.GetComponent<Button>().image.sprite = Resources.Load<Sprite>(spriteImage);
    }
}
