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
        {

        }
    }
}
