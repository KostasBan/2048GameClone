using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : ItemMovement
{
    public override Swipe SwipeDirection => Swipe.Down;

    public override void MoveItems()
    {
        Debug.Log("Moving Down");
        //ActiveItemService activeItemService = ServiceLocator.Current.Get<ActiveItemService>();
        //foreach (var item in activeItemService.ActiveItems)
        //    SlideDown(item.Cell);

        GridService grid = ServiceLocator.Current.Get<GridService>();
        foreach (var item in grid.GridPositions)
            SlideDown(item);
    }
    private void SlideDown(GridCell cell)
    {
        GridCell cellUp = cell.GetNeighbour(Swipe.Up);
        if (cellUp == null)
            return;

        Debug.Log(cell.gameObject.name);
        if (cell.Fill != null)
        {
            GridCell nextCell = cellUp;
            while (nextCell.GetNeighbour(Swipe.Up) != null && nextCell.Fill == null)
                nextCell = nextCell.GetNeighbour(Swipe.Up);

            if (nextCell.Fill != null)
            {
                if (cell.Fill.Value == nextCell.Fill.Value)
                {
                    nextCell.Fill.transform.parent = cell.transform;
                    cell.Fill = nextCell.Fill;
                    nextCell.Fill = null;
                }
                else
                {
                    nextCell.Fill.transform.parent = cellUp.transform;
                    cellUp.Fill = nextCell.Fill;
                    nextCell.Fill = null;
                }
            }
        }
        else
        {
            GridCell nextCell = cellUp;
            while (nextCell.GetNeighbour(Swipe.Up) != null && nextCell.Fill == null)
                nextCell = nextCell.GetNeighbour(Swipe.Up);

            if (nextCell.Fill != null)
            {
                nextCell.Fill.transform.parent = cell.transform;
                cell.Fill = nextCell.Fill;
                nextCell.Fill = null;
                SlideDown(cell);
            }
        }

        // TODO Check if this is redundunt.
        if (cellUp == null)
            return;
        SlideDown(cellUp);
    }
}
