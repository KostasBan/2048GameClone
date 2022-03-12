using UnityEngine;

public class ServiceLocatorBootstrapper : MonoBehaviour
{
    [SerializeField] private GridService _gridService;
    void Awake()
    {
        ServiceLocator.Initiailze();
        ServiceLocator.Current.Register<GridService>(_gridService);
        ServiceLocator.Current.Register<GridFreePositionsService>(new GridFreePositionsService(_gridService.GridPositions));
        ServiceLocator.Current.Register<ActiveItemService>(new ActiveItemService());
    }
}
