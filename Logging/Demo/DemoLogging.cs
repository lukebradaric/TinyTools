using UnityEngine;

public class DemoLogging : MonoBehaviour
{
    public Logger _demoLogger;

    [TextArea] public string note;

    private void Start()
    {
        _demoLogger.Log("Scene started.");
    }

    private void Update()
    {
        if (Input.GetKeyDown("g"))
        {
            _demoLogger.Log("G key was pressed.");
        }
    }
}
