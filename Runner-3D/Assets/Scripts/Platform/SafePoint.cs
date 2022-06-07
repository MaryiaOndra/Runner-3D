using System;
using Runner.Level.Player;
using UnityEngine;

namespace Platform
{
    public class SafePoint : MonoBehaviour
    {
        public event Action OnTrigger;
    
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(typeof(PlayerMovement), out _))
            {
                OnTrigger?.Invoke();
            }
        }
    }
}
