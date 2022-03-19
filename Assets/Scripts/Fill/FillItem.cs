using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillItem : MonoBehaviour
{
    GridCell _currentGridCell;

    public int Value { get; set; }

    private void Start()
    {
        _currentGridCell = transform.parent.GetComponent<GridCell>();
    }

    private void OnEnable() => ServiceLocator.Current.Get<ActiveItemService>().ActiveItems.Add(this);
    private void OnDisable() => ServiceLocator.Current.Get<ActiveItemService>().ActiveItems.Remove(this);
    private void OnDestroy() => ServiceLocator.Current.Get<ActiveItemService>().ActiveItems.Remove(this);

    private void ChangeParent(Transform newParent)
    {
        transform.parent = newParent;
    }

    IEnumerator MoveFillItem()
    {
        float time = 0;
        Vector3 startPosition = transform.position;
        while (time <= 1)
        {
            yield return null;
            time += Time.deltaTime;
            transform.position = Vector3.Lerp(startPosition, Vector3.zero, time);
        }
    }
}
