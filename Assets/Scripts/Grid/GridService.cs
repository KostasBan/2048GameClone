using System.Collections.Generic;
using UnityEngine;

public class GridService : MonoBehaviour, IGameService
{
    [SerializeField] private List<GridCell> _gridPositions;

    public List<GridCell> GridPositions => _gridPositions;
}
