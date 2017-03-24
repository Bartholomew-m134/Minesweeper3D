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
    private bool isPlacingFlag;

	// Use this for initialization
	void Start () {
        var capacity = gridLength * gridLength;
        if(Is3D) {
            capacity *= numberOfSides;
            bombNumber *= bombNumber;
        }

        cellValues = new List<CellValue>(capacity);
        InitializeGrid();

        var buttonList = GetComponentsInChildren<Button>();
        for (int i = 0; i < cellValues.Count; i++) {
            //buttonList[i].GetComponentInChildren<Text>().text = ((int)cellValues[i]).ToString();
            buttonList[i].GetComponentInChildren<Text>().text = (i).ToString();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool ToggleFlag() {
        isPlacingFlag = !isPlacingFlag;

        return isPlacingFlag;
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

        bool isLeftEdge = centerIndex < gridLength;
        bool isRightEdge = centerIndex >= (cellValues.Count - gridLength);
        bool isTopEdge = centerIndex % gridLength == 0;
        bool isBottomEdge = ((centerIndex - 4) % gridLength == 0) && centerIndex != 0;

        //if (!Is3D || !(isLeftEdge || isRightEdge || isTopEdge || isBottomEdge)) {
            int beginningRow = isLeftEdge ? 0 : -1;
            int endingRow = isRightEdge ? 1 : 2;

            int beginningColumn = isTopEdge ? 0 : -1;
            int endingColumn = isBottomEdge ? 1 : 2;

            for (int row = beginningRow; row < endingRow; row++) {
                for (int column = beginningColumn; column < endingColumn; column++) {
                    int adjIndex = centerIndex + (row * gridLength) + column;

                    if (IsWithinBounds(adjIndex)) {
                        adjIndexes.Add(adjIndex);
                    }
                }
            }
        //} 
        
        if (Is3D) {
            switch (centerIndex) {
                case 0:
                    adjIndexes.Add(79);
                    adjIndexes.Add(84);
                    adjIndexes.Add(120);
                    adjIndexes.Add(121);
                    break;
            }
        }

        /*for (int row = -1; row < 2; row++) {
            for (int column = -1; column < 2; column++) {
                //int columnAdjustment = column + (isRightEdge && column == 1 ? gridLength * gridLength - gridLength + 1: 0) - (isLeftEdge && column == -1 ? gridLength * gridLength - gridLength + 1 : 0);
                int columnAdjustment = column + (isRightEdge && column == 1 ? gridLength * gridLength - gridLength + 1 : 0);
                int adjIndex = centerIndex + (row * gridLength) + columnAdjustment;

                if (IsWithinBounds(adjIndex)) {
                    adjIndexes.Add(adjIndex);
                }

                Debug.Log((adjIndex + cellValues.Count) % cellValues.Count);
                adjIndexes.Add((adjIndex + cellValues.Count) % cellValues.Count);
            }
        }*/

        if(centerIndex == 0) {
            foreach(var item in adjIndexes)
            Debug.Log(item);
        }

        return adjIndexes;
    }

    private bool IsWithinBounds(int index) {
        return 0 <= index && index < cellValues.Count;
    }

}
