using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private NumberSpawner _spawner;
    private MovementFactory _movements = new MovementFactory();
    private IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        ServiceLocator.Current.Get<SwipeManager>().OnSwipeDetected += ExecuteSwipe;
        _spawner = ServiceLocator.Current.Get<NumberSpawner>();
    }

    private void ExecuteSwipe(Swipe swipeDirection, Vector2 swipeVelocity)
    {
        _movements.GetMovement(swipeDirection)?.MoveItems();
        _spawner.SpawnNumber();
    }
}
