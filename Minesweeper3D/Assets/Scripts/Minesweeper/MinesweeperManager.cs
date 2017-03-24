using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinesweeperManager : MonoBehaviour {

    public bool Is3D;

    private enum CellValue {
        Flag = -2, Bomb, Zero, One, Two, Three, Four, Five, Six, Seven, Eight
    }

    private int numberOfSides = 6;
    private int gridLength = 5;
    private int bombNumber = 5;

    private List<CellValue> cellValues;
    private List<Button> buttonList;

	// Use this for initialization
	void Start () {
        var capacity = gridLength * gridLength;
        if(Is3D) {
            capacity *= numberOfSides;
        }

        cellValues = new List<CellValue>(capacity);
        InitializeGrid();

        var buttonList = GetComponentsInChildren<Button>();
        for (int i = 0; i < cellValues.Count; i++) {
            buttonList[i].GetComponentInChildren<Text>().text = ((int)cellValues[i]).ToString();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
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

        int beginningRow = (centerIndex < gridLength) ? 0 : -1;
        int endingRow = (centerIndex >= (cellValues.Count - gridLength)) ? 1 : 2;

        int beginningColumn = (centerIndex % gridLength == 0) ? 0 : -1;
        int endingColumn = (((centerIndex - 4) % gridLength == 0) && centerIndex != 0) ? 1 : 2;

        for (int row = beginningRow; row < endingRow; row++) {
            for (int column = beginningColumn; column < endingColumn; column++) {
                int adjIndex = centerIndex + (row * gridLength) + column;

                if(IsWithinBounds(adjIndex)) {
                    adjIndexes.Add(adjIndex);
                }
            }
        }

        return adjIndexes;
    }

    private bool IsWithinBounds(int index) {
        return 0 <= index && index < cellValues.Count;
    }

    /*
    private bool IsTopBomb(int index) {
        int adjacentIndex = index - gridLength;

        return 0 <= adjacentIndex && adjacentIndex < cellValues.Count && cellValues[adjacentIndex] == CellValue.Bomb;
    }

    private bool IsTopLeftBomb(int index) {
        int adjacentIndex = index - gridLength - 1;

        return 0 <= adjacentIndex && adjacentIndex < cellValues.Count && cellValues[adjacentIndex] == CellValue.Bomb;
    }

    private bool IsTopRightBomb(int index) {
        int adjacentIndex = index - gridLength + 1;

        return 0 <= adjacentIndex && adjacentIndex < cellValues.Count && cellValues[adjacentIndex] == CellValue.Bomb;
    }

    private bool IsLeftBomb(int index) {
        int adjacentIndex = index - 1;

        return 0 <= adjacentIndex && adjacentIndex < cellValues.Count && cellValues[adjacentIndex] == CellValue.Bomb;
    }

    private bool IsRightBomb(int index) {
        int adjacentIndex = index + 1;

        return 0 <= adjacentIndex && adjacentIndex < cellValues.Count && cellValues[adjacentIndex] == CellValue.Bomb;
    }

    private bool IsBottomBomb(int index) {
        int adjacentIndex = index + gridLength;

        return 0 <= adjacentIndex && adjacentIndex < cellValues.Count && cellValues[adjacentIndex] == CellValue.Bomb;
    }

    private bool IsBottomLeftBomb(int index) {
        int adjacentIndex = index + gridLength - 1;

        return 0 <= adjacentIndex && adjacentIndex < cellValues.Count && cellValues[adjacentIndex] == CellValue.Bomb;
    }

    private bool IsBottomRightBomb(int index) {
        int adjacentIndex = index + gridLength + 1;

        return 0 <= adjacentIndex && adjacentIndex < cellValues.Count && cellValues[adjacentIndex] == CellValue.Bomb;
    }*/
}
