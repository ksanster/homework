using System;
using UnityEngine;

namespace Lesson5
{
    public class SecretTarget : MonoBehaviour
    {
        private bool secretFound;
        public event Action<GameObject> OnCollide; 
        
        private void OnTriggerEnter(Collider other)
        {
            if (!secretFound)
            {
                secretFound = true;
                OnCollide?.Invoke(other.gameObject);
            }
        }
    }
}