using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinesweeperManager : MonoBehaviour {

    public bool Is3D;

    private enum CellValue {
        Flag = -2, Bomb, Zero, One, Two, Three, Four, Five, Six, Seven, Eight
    }

    private int numberOfSides = 4;
    private int gridLength = 5;
    private int bombNumber = 5;

    private List<CellValue> cellValues;
    private List<Button> buttonList;
    public bool IsPlacingFlag { get; set; }
    public bool GameOver { get; set; }
    public int EmptySpaces {get; set;}
	// Use this for initialization
	void Start () {
        var capacity = gridLength * gridLength;
        if(Is3D) {
            capacity *= numberOfSides;
            bombNumber *= bombNumber;
        }

        GameOver = false;
        EmptySpaces = capacity - bombNumber;
        cellValues = new List<CellValue>(capacity);
        InitializeGrid();

        var buttonList = GetComponentsInChildren<Button>();
        for (int i = 0; i < cellValues.Count; i++) {
            buttonList[i].GetComponent<GameButtonBehavior>().buttonValue = ((int)cellValues[i]);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool ToggleFlag() {
        IsPlacingFlag = !IsPlacingFlag;

        return IsPlacingFlag;
    }


    private void InitializeGrid() {
        CreateBombs();
        InitializeCells();
    }

    private void CreateBombs() {
        for (int i = 0; i < cellValues.Capacity; i++) {
            cellValues.Add(CellValue.Zero);
        }
        
        for (int i = 0; i < bombNumber; i++) {
            int index = Random.Range(0, cellValues.Count);

            while (cellValues[index] == CellValue.Bomb) {
                index = Random.Range(0, cellValues.Capacity);
            }

            cellValues[index] = CellValue.Bomb;
        }
    }

    private void InitializeCells() {
        for(int i = 0; i < cellValues.Count; i++) {
            cellValues[i] = CalculateCellValue(i);
        }
    }

    private CellValue CalculateCellValue(int index) {
        CellValue value = CellValue.Zero;

        if(cellValues[index] == CellValue.Bomb) {
            value = CellValue.Bomb;
        } else {
            foreach(var adjIndex in GetAdjacentIndexes(index)) {
                if(cellValues[adjIndex] == CellValue.Bomb) {
                    value++;
                }
            }
        }

        return value;
    }

    private List<int> GetAdjacentIndexes(int centerIndex) {
        List<int> adjIndexes = new List<int>();

        bool isTopEdge = (centerIndex % (gridLength * gridLength)) < gridLength;
        bool isBottomEdge = (centerIndex % (gridLength * gridLength)) >= (gridLength * gridLength - gridLength) && centerIndex != 0;
        bool isLeftEdge = centerIndex % gridLength == 0;
        bool isRightEdge = ((centerIndex + 1) % gridLength == 0) && centerIndex != 0;

        int beginningRow = isTopEdge ? 0 : -1;
        int endingRow = isBottomEdge ? 1 : 2;

        int beginningColumn = isLeftEdge && !Is3D ? 0 : -1;
        int endingColumn = isRightEdge && !Is3D ? 1 : 2;

        for (int row = beginningRow; row < endingRow; row++) {
            for (int column = beginningColumn; column < endingColumn; column++) {
                int adjIndex = centerIndex + (row * gridLength) + column;

                if (isLeftEdge && column == -1) {
                    adjIndex -= gridLength * gridLength - gridLength;
                }

                if (isRightEdge && column == 1) {
                    adjIndex += gridLength * gridLength - gridLength;
                }

                adjIndex = (adjIndex + cellValues.Count) % cellValues.Count;
                adjIndexes.Add(adjIndex);
            }
        }

        return adjIndexes;
    }

    private bool IsWithinBounds(int index) {
        return 0 <= index && index < cellValues.Count;
    }

}
