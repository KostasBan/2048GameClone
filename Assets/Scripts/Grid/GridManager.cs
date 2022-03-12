using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    private const int width = 4;
    private const int height = 4;

    private List<GridCell> gridPositions;
    private GridCell[,] grid = new GridCell[width, height];

    void Start()
    {
        gridPositions = ServiceLocator.Current.Get<GridService>().GridPositions;
        if (gridPositions.Count != width * height)
            return;
        SetGrid();
        SetGridNeighbours();
    }

    private void SetGrid()
    {
        for (int i = 0; i < height; i++)
            for (int j = 0; j < width; j++)
                grid[i, j] = gridPositions[j + i * 4];
    }

    private void SetGridNeighbours()
    {
        for (int i = 0; i < height; i++)
            for (int j = 0; j < width; j++)
                grid[i, j].InitGridCell(GetUpGridCell(i, j), GetDownGridCell(i, j), GetleftGridCell(i, j), GetRightGridCell(i, j));
    }

    private GridCell GetUpGridCell(int i, int j) => i == 0 ? null : grid[i - 1, j];
    private GridCell GetDownGridCell(int i, int j) => i == height - 1 ? null : grid[i + 1, j];
    private GridCell GetleftGridCell(int i, int j) => j == 0 ? null : grid[i, j - 1];
    private GridCell GetRightGridCell(int i, int j) => j == width - 1 ? null : grid[i, j + 1];


}
