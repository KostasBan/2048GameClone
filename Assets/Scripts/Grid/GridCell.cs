using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCell : MonoBehaviour
{
    [SerializeField] private GridCell _up = null;
    [SerializeField] private GridCell _down = null;
    [SerializeField] private GridCell _left = null;
    [SerializeField] private GridCell _right = null;

    public void InitGridCell(GridCell up, GridCell down, GridCell left, GridCell right)
    {
        _up = up;
        _down = down;
        _left = left;
        _right = right;
    }
}
