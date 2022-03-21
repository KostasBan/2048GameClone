using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillItem : MonoBehaviour
{
    public int Value { get; set; }
    public GridCell Cell { get; set; }

    private void Start()
    {
        Cell = transform.parent.GetComponent<GridCell>();
    }

    private void OnEnable() => ServiceLocator.Current.Get<ActiveItemService>().ActiveItems.Add(this);
    private void OnDisable() => ServiceLocator.Current.Get<ActiveItemService>().ActiveItems.Remove(this);
    private void OnDestroy() => ServiceLocator.Current.Get<ActiveItemService>().ActiveItems.Remove(this);

    public IEnumerator MoveFillItem()
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
