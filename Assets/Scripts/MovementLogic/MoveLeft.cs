using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : ItemMovement
{
    public override Swipe SwipeDirection => Swipe.Left;

    public override void MoveItems()
    {
        Debug.Log("Moving Left");
        ActiveItemService activeItemService = ServiceLocator.Current.Get<ActiveItemService>();
        foreach (var item in activeItemService.ActiveItems)
        {

        }
    }
}
