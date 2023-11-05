using UnityEngine;
using System;

namespace Core.Pong
{
    public class EventManager : MonoBehaviour
    {
        public event Action<Vector3> OnSpeedChanged;
        public event Action<bool> OnEndZoneChanged;
        
        public static EventManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        public void OnSpeedChangedEvent(Vector3 velocity)
        {
            OnSpeedChanged?.Invoke(velocity);
        }
        public void OnEndZoneEvent(bool endzone)
        {
            OnEndZoneChanged?.Invoke(endzone);
        }
    }
}