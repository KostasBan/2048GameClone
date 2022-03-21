using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRight : ItemMovement
{
    public override Swipe SwipeDirection => Swipe.Right;

    public override void MoveItems()
    {
        Debug.Log("Moving Right");
        ActiveItemService activeItemService = ServiceLocator.Current.Get<ActiveItemService>();
        foreach (var item in activeItemService.ActiveItems)
            SlideRight(item.Cell);
    }

    private void SlideRight(GridCell cell)
    {
        GridCell cellLeft = cell.GetNeighbour(Swipe.Left);
        if (cellLeft == null)
            return;

        Debug.Log(cell.gameObject.name);
        if (cell.Fill != null)
        {
            GridCell nextCell = cellLeft;
            while (nextCell.GetNeighbour(Swipe.Left) != null && nextCell.Fill == null)
                nextCell = nextCell.GetNeighbour(Swipe.Left);

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
                    nextCell.Fill.transform.parent = cellLeft.transform;
                    cellLeft.Fill = nextCell.Fill;
                    nextCell.Fill = null;
                }
            }
        }
        else
        {
            GridCell nextCell = cellLeft;
            while (nextCell.GetNeighbour(Swipe.Left) != null && nextCell.Fill == null)
                nextCell = nextCell.GetNeighbour(Swipe.Left);

            if (nextCell.Fill != null)
            {
                nextCell.Fill.transform.parent = cell.transform;
                cell.Fill = nextCell.Fill;
                nextCell.Fill = null;
                SlideRight(cell);
            }
        }

        // TODO Check if this is redundunt.
        if (cellLeft == null)
            return;
        SlideRight(cellLeft);
    }
}
