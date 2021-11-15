using UnityEngine;

[ExecuteAlways]
public class DemoOptionalVariable : MonoBehaviour
{
    // Optional variable of any serializable type
    // The variable is disabled when not enabled in inspector
    public Optional<Color> overrideCameraColor;

    // If the optional variable is enabled, the camera background will be changed
    private void Update()
    {
        if (overrideCameraColor.Enabled)
            Camera.main.backgroundColor = overrideCameraColor.Value;
        else
            Camera.main.backgroundColor = Color.grey;
    }
}
