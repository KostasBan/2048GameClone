using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : ItemMovement
{
    public override Swipe SwipeDirection => Swipe.Down;

    public override void MoveItems()
    {
        Debug.Log("Moving Down");
        ActiveItemService activeItemService = ServiceLocator.Current.Get<ActiveItemService>();
        foreach (var item in activeItemService.ActiveItems)
        {

        }
    }
}
