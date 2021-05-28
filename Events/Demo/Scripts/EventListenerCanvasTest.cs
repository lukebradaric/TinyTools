using UnityEngine;
using UnityEngine.UI;

// Demo for EventListerComponents to interact with canvas UI
public class EventListenerCanvasTest : MonoBehaviour
{
    public GameObject boolObject;
    public Text intText;
    public Text floatText;
    public Image voidImage;

    public void HandleVoidEvent() => voidImage.color = new Color(Random.Range(0, 101)/100f, Random.Range(0, 101) / 100f, Random.Range(0, 101) / 100f);

    public void HandleBoolEvent(bool value) => boolObject.SetActive(value);

    public void HandleIntEvent(int value) => intText.text = "Int\n Event\n " + value;

    public void HandleFloatEvent(float value) => floatText.text = "Float\n Event\n " + value;
}
