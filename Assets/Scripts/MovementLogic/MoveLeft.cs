using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : ItemMovement
{
    public override Swipe SwipeDirection => Swipe.Left;

    public override void MoveItems()
    {
        Debug.Log("Moving Left");
        ActiveItemService activeItemService = ServiceLocator.Current.Get<ActiveItemService>();
        foreach (var item in activeItemService.ActiveItems)
            SlideLeft(item.Cell);
    }

    private void SlideLeft(GridCell cell)
    {
        GridCell cellRight = cell.GetNeighbour(Swipe.Right);
        if (cellRight == null)
            return;

        Debug.Log(cell.gameObject.name);
        if (cell.Fill != null)
        {
            GridCell nextCell = cellRight;
            while (nextCell.GetNeighbour(Swipe.Right) != null && nextCell.Fill == null)
                nextCell = nextCell.GetNeighbour(Swipe.Right);

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
                    nextCell.Fill.transform.parent = cellRight.transform;
                    cellRight.Fill = nextCell.Fill;
                    nextCell.Fill = null;
                }
            }
        }
        else
        {
            GridCell nextCell = cellRight;
            while (nextCell.GetNeighbour(Swipe.Right) != null && nextCell.Fill == null)
                nextCell = nextCell.GetNeighbour(Swipe.Right);

            if (nextCell.Fill != null)
            {
                nextCell.Fill.transform.parent = cell.transform;
                cell.Fill = nextCell.Fill;
                nextCell.Fill = null;
                SlideLeft(cell);
            }
        }

        // TODO Check if this is redundunt.
        if (cellRight == null)
            return;
        SlideLeft(cellRight);
    }
}
