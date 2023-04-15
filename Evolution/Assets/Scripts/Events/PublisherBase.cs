using UnityEngine;

public abstract class PublisherBase : MonoBehaviour
{
    public delegate void EventHander();
    public static event EventHander Handler;

    public void Publish()
    {
        Handler?.Invoke();
    }
}