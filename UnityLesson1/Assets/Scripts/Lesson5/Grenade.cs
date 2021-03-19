using System;
using UnityEngine;

namespace Lesson5
{
    [RequireComponent(typeof(Rigidbody))]
    public class Grenade : MonoBehaviour
    {
        private Rigidbody body;
        public event Action<Transform> OnCollide;

        private void Awake()
        {
            body = GetComponent<Rigidbody>();
        }

        private void OnCollisionEnter(Collision other)
        {
            OnCollide?.Invoke(transform);
        }

        public void AddForce(Vector3 direction, float force)
        {
            body.AddForce(direction * force);
        }
    }
}