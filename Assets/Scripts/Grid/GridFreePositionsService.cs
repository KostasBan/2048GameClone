using System.Collections.Generic;
using UnityEngine;

public class GridFreePositionsService : IGameService
{
    private List<GridCell> _freePositions = null;
    public GridFreePositionsService(List<GridCell> freePositions)
    {
        _freePositions = freePositions;
    }
    public GridCell GetFreePosition()
    {
        if (_freePositions.Count == 0)
            return null;
        int rnd = Random.Range(0, _freePositions.Count - 1);
        GridCell result = _freePositions[rnd];
        _freePositions.RemoveAt(rnd);
        return result;
    }
    public void FreePosition(GridCell gridCell) => _freePositions.Add(gridCell);
}
