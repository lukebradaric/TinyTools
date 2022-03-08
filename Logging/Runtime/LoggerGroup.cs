using System.Collections.Generic;
using UnityEngine;

namespace TinyTools.Logging
{
    [CreateAssetMenu(menuName = "Game/LoggerGroup")]
    public class LoggerGroup : ScriptableObject
    {
        [SerializeField] private bool _enabled;
        [SerializeField] private List<Logger> _loggers;

        public void EnableLoggers()
        {
            foreach (Logger logger in _loggers)
                logger?.SetEnabled(true);
        }

        public void DisableLoggers()
        {
            foreach (Logger logger in _loggers)
                logger?.SetEnabled(false);
        }

        private void OnValidate()
        {
            if (_enabled)
                EnableLoggers();
            else
                DisableLoggers();
        }
    }
}