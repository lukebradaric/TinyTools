using UnityEngine;
using TinyTools.Events;

// Demo to call GameEvents
public class EventTest : MonoBehaviour
{
    public VoidEventSO voidEvent;

    public BoolEventSO boolEvent;
    bool boolValue = true;

    public IntEventSO intEvent;
    int intValue;

    public FloatEventSO floatEvent;
    float floatValue;

    private void Update()
    {
        if (Input.GetKeyDown("v"))
            voidEvent.Invoke();

        if (Input.GetKeyDown("b"))
        {
            boolValue = !boolValue;
            boolEvent.Invoke(boolValue);
        }

        if (Input.GetKeyDown("i"))
        {
            intValue++;
            intEvent.Invoke(intValue);
        }

        if (Input.GetKeyDown("f"))
        {
            floatValue += 1.03f;
            floatEvent.Invoke(floatValue);
        }
    }
}
