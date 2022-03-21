
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : ItemMovement
{
    public override Swipe SwipeDirection => Swipe.Up;

    public override void MoveItems()
    {
        Debug.Log("Moving Up");
        //ActiveItemService activeItemService = ServiceLocator.Current.Get<ActiveItemService>();
        //foreach (var item in activeItemService.ActiveItems)
        //    SlideUp(item.Cell);

        GridService grid = ServiceLocator.Current.Get<GridService>();
        foreach (var item in grid.GridPositions)
            SlideUp(item);
    }

    private void SlideUp(GridCell cell)
    {
        GridCell cellDown = cell.GetNeighbour(Swipe.Down);
        if (cellDown == null)
            return;

        Debug.Log(cell.gameObject.name);
        if (cell.Fill != null)
        {
            GridCell nextCell = cellDown;
            while (nextCell.GetNeighbour(Swipe.Down) != null && nextCell.Fill == null)
                nextCell = nextCell.GetNeighbour(Swipe.Down);

            if (nextCell.Fill != null)
            {
                if (cell.Fill.Value == nextCell.Fill.Value)
                {
                    nextCell.Fill.transform.parent = cell.transform;
                    nextCell.Fill.Cell = cell;
                    cell.Fill = nextCell.Fill;
                    nextCell.Fill = null;
                }
                else
                {
                    nextCell.Fill.transform.parent = cellDown.transform;
                    cellDown.Fill = nextCell.Fill;
                    nextCell.Fill = null;
                }
            }
        }
        else
        {
            GridCell nextCell = cellDown;
            while (nextCell.GetNeighbour(Swipe.Down) != null && nextCell.Fill == null)
                nextCell = nextCell.GetNeighbour(Swipe.Down);

            if (nextCell.Fill != null)
            {
                nextCell.Fill.transform.parent = cell.transform;
                cell.Fill = nextCell.Fill;
                nextCell.Fill = null;
                SlideUp(cell);
            }
        }

        // TODO Check if this is redundunt.
        if (cellDown == null)
            return;
        SlideUp(cellDown);
    }
}
