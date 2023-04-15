using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class TriggerChangeColor : MonoBehaviour
{
    private string eventName = "EVENT:ChangeColor";

    private void OnMouseDown()
    {
        EventManager.TriggerEvent("EVENT:ChangeColor");
        myLog();
    }

    private void myLog()
    {
        UnityEvent evt;
        EventManager.eventInstance.eventDictionary.TryGetValue(eventName, out evt);

        Debug.Log("Number of Events: " + eventName + " : " + EventManager.eventInstance.eventDictionary.Count());
        Debug.Log("Event string: " + evt.ToSafeString());
    }

}
