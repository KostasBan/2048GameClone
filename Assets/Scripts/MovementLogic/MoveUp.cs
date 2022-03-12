
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : ItemMovement
{
    public override Swipe SwipeDirection => Swipe.Up;

    public override void MoveItems()
    {
        Debug.Log("Moving Up");
        ActiveItemService activeItemService = ServiceLocator.Current.Get<ActiveItemService>();
        foreach(var item in activeItemService.ActiveItems)
        {

        }
    }
}
