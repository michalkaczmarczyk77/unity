using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class OnChangeColor2 : MonoBehaviour
{
    private static string eventName = "EVENT:ChangeColor";
    private UnityAction onChangeColor;

    private void OnEnable()
    {
        onChangeColor = new UnityAction(ChangeColor2);
        EventManager.StartListening(eventName, onChangeColor);
    }

    void OnDisable()
    {
        //OnDestroyEnemiesPublisher.Handler -= Destroy;
        //OnChangeColorPublisher.Handler -= ChangeColor;
        EventManager.StopListening("EVENT:ChangeColor", onChangeColor);
    }

    public virtual void ChangeColor2()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(Color.red.r, Color.red.g, Color.cyan.b, Color.cyan.a);
    }

    /*void Destroy()
    {
        Destroy(transform.gameObject);
    }*/
}
