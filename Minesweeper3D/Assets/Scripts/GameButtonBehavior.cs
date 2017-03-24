using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameButtonBehavior : MonoBehaviour {

    public GameObject grid;
    MinesweeperManager manager;
    public int buttonValue;

    public void Start() {

         manager = grid.GetComponent<MinesweeperManager>();
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

    public void FlagButtonPress() {
        manager.ToggleFlag();

    }

    public void PressGridButton() {
        if (manager.IsPlacingFlag)
        {
            gameObject.GetComponent<Button>().image.overrideSprite = Resources.Load<Sprite>("flag");
        }
        else {
             if (buttonValue == -1)
            {
                gameObject.GetComponent<Button>().image.overrideSprite = Resources.Load<Sprite>("bomb");
            }
            else
            {
                gameObject.GetComponentInChildren<Text>().text = buttonValue.ToString();
                gameObject.GetComponent<Button>().image.overrideSprite = Resources.Load<Sprite>("minesweeperBlank");
            }
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
