using UnityEngine;
using UnityEngine.Events;

public class OnChangeColor : MonoBehaviour
{
    private static string eventName = "EVENT:ChangeColor";
    private UnityAction handler;
    private Transform tr;

    private void OnEnable()
    {
        handler = new UnityAction(ChangeColor);
        EventManager.StartListening(eventName, handler);
    }

    void OnDisable()
    {
        EventManager.StopListening(eventName, handler);
    }

    public virtual void ChangeColor()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(Color.cyan.r, Color.cyan.g, Color.cyan.b, Color.cyan.a);
    }

}
