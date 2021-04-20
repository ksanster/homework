using System;
using UnityEngine;

namespace Lesson5
{
    public class SecretTarget : MonoBehaviour
    {
        public event Action<GameObject> OnCollide; 
        
        private void OnTriggerEnter(Collider other)
        {
            OnCollide?.Invoke(other.gameObject);
        }
    }
}