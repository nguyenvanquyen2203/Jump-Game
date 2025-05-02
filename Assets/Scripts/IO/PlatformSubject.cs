using System.Collections.Generic;
using UnityEngine;

public abstract class PlatformSubject : MonoBehaviour
{
    private List<IPlatformObs> _observers = new List<IPlatformObs>();
    public void AddObserver(IPlatformObs observer) => _observers.Add(observer);
    public void RemoveObserver(IPlatformObs observer) => _observers.Remove(observer);
    protected void NotifyObserver(Vector2 velocity)
    {
        _observers.ForEach((_observer) =>
        {
            _observer.SetVelocity(velocity);
        });
    }
}
