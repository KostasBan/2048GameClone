using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveItemService : IGameService
{
    private List<FillItem> _activeItems = new List<FillItem>();

    public List<FillItem> ActiveItems => _activeItems;
}
