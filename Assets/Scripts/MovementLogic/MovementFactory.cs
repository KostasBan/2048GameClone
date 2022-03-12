using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;
using System.Linq;

public class MovementFactory
{
    private Dictionary<Swipe, Type> _movmentsBySwipe;

    public MovementFactory()
    {
        var movmentTypes = Assembly.GetAssembly(typeof(ItemMovement)).GetTypes()
            .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(ItemMovement)));

        _movmentsBySwipe = new Dictionary<Swipe, Type>();

        foreach (var type in movmentTypes)
        {
            var tempMovement = Activator.CreateInstance(type) as ItemMovement;
            _movmentsBySwipe.Add(tempMovement.SwipeDirection, type);
        }
    }

    public ItemMovement GetMovement(Swipe swipeDirection)
    {
        if (_movmentsBySwipe.ContainsKey(swipeDirection))
            return Activator.CreateInstance(_movmentsBySwipe[swipeDirection]) as ItemMovement;
        return null;
    }

}
