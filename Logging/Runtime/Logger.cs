using UnityEngine;

namespace TinyTools.Logging
{
    [CreateAssetMenu(menuName = "Game/Logger")]
    public class Logger : ScriptableObject
    {
        [Tooltip("Enable or disable the logger.")]
        [SerializeField] private bool _enabled = true;
        [Tooltip("Should the logger include its name in the debug message.")]
        [SerializeField] private bool _logName = true;
        [Tooltip("Color of the message logged.")]
        [SerializeField] private Color _color = Color.white;

        public virtual void Log(string message)
        {
            if (!_enabled)
                return;

            string hexColor = "#" + ColorUtility.ToHtmlStringRGB(_color);
            string prefix = _logName ? $"[{this.name}] " : " ";
            Debug.Log($"<color={hexColor}>{prefix}{message}</color>");
        }

        public void SetEnabled(bool value)
        {
            if (_enabled == value)
                return;

            _enabled = value;
        }
    }
}