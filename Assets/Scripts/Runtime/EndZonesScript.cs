using System;
using UnityEngine;

namespace Core.Pong.Runtime
{
    public class EndZonesScript : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Ball"))
            {
                Debug.Log($"Should be true");
                EventManager.Instance.OnEndZoneEvent(true);
            }
        }
    }
}
