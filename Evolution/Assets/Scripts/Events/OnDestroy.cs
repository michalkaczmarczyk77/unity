using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnDestroy : MonoBehaviour
{
    private static string eventName = "EVENT:Destroy";
    private UnityAction handler;

    private void OnEnable()
    {
        handler = new UnityAction(Destroy);
        EventManager.StartListening(eventName, handler);
    }

    void OnDisable()
    {
        EventManager.StopListening(eventName, handler);
    }

    void Destroy()
    {
        Destroy(transform.gameObject);
    }
}
