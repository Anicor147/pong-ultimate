using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core.Pong.Runtime
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        
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
        private void Start()
        {
            EventManager.Instance.OnEndZoneChanged += EndZoneReset;
        }

      
        private void EndZoneReset(bool reset)
        {
            if (!reset) return;
            this.StartTimer(3, (() => SceneManager.LoadScene(0)));
        }
        
    }
    
}
