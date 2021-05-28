using UnityEngine;
using TinyTools.Events;

// Demo to handle GameEvents via scritp
public class EventListenerTest : MonoBehaviour
{
    // Subscribe to Events using code
    public VoidEventSO voidEvent;
    public BoolEventSO boolEvent;
    public IntEventSO intEvent;
    public FloatEventSO floatEvent;

    private void OnEnable()
    {
        voidEvent.OnInvoke += HandleVoidEvent;
        boolEvent.OnInvoke += HandleBoolEvent;
        intEvent.OnInvoke += HandleIntEvent;
        floatEvent.OnInvoke += HandleFloatEvent;
    }

    private void OnDisable()
    {
        voidEvent.OnInvoke -= HandleVoidEvent;
        boolEvent.OnInvoke -= HandleBoolEvent;
        intEvent.OnInvoke -= HandleIntEvent;
        floatEvent.OnInvoke -= HandleFloatEvent;
    }

    // Methods to Handle Events
    public void HandleVoidEvent() => Debug.Log("Void Event");

    public void HandleBoolEvent(bool value) => Debug.Log($"Bool Event: {value}");

    public void HandleIntEvent(int value) => Debug.Log($"Int Event: {value}");

    public void HandleFloatEvent(float value) => Debug.Log($"Float Event: {value}");
}
