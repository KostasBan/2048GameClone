using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemMovement
{
    public virtual void MoveItems() { }
    public virtual Swipe SwipeDirection { get; }
}
