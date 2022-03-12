using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberSpawner : MonoBehaviour, IGameService
{
    [SerializeField] private GameObject numberPrefab;

    private GridFreePositionsService _freePositions;

    private IEnumerator Start()
    {
        ServiceLocator.Current.Register<NumberSpawner>(this);
        yield return new WaitForEndOfFrame();
        _freePositions = ServiceLocator.Current.Get<GridFreePositionsService>();
    }

    public void SpawnNumber()
    {
        GridCell cell = _freePositions.GetFreePosition();
        if (cell == null)
        {
            Debug.Log("Gameover");
            return;
        }
        Instantiate(numberPrefab, cell.transform.position, Quaternion.identity, cell.transform);
    }

}
