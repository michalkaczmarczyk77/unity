using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class TriggerDestroy : MonoBehaviour
{
    private string eventName = "EVENT:Destroy";

    private void OnMouseDown()
    {
        EventManager.TriggerEvent(eventName);
        myLog();
    }

    private void myLog()
    {
        UnityEvent evt;
        EventManager.eventInstance.eventDictionary.TryGetValue(eventName, out evt);

        Debug.Log("Number of Events: " + eventName + " : " + EventManager.eventInstance.eventDictionary.Count());
    }

}
