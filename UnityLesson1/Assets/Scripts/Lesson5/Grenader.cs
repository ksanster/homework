using System;
using UnityEngine;

namespace Lesson5
{
    [RequireComponent(typeof(Rigidbody))]
    public class Grenader : MonoBehaviour
    {
        [SerializeField]
        private Grenade grenadePrefab;
        [SerializeField]
        private Transform placeholder;
        [SerializeField]
        private float throwForce;
        [SerializeField]
        private float speed;
        [SerializeField]
        private float jumpForce = 100f;
        
        private Rigidbody body;

        private void Awake()
        {
            body = GetComponent<Rigidbody>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Speed")
            {
                Destroy(other.gameObject);
                speed *= 1.5f;
            }
        }

        public Grenade ThrowGrenade()
        {
            var pos = transform.TransformPoint(placeholder.localPosition);
            var direction = transform.TransformDirection(placeholder.localPosition).normalized;
            var grenade = Instantiate(grenadePrefab, pos, Quaternion.identity);
            grenade.AddForce(direction, throwForce);
            
            return grenade;
        }
        
        public void Move(Vector3 direction)
        {
            body.AddForce(direction * speed);
        }
        
        public void Jump(float multiplier)
        {
            body.AddForce(Vector3.up * jumpForce * multiplier); 
        }
        
        public void LookTo(Vector3 target)
        {
            var newDir = Vector3.RotateTowards(transform.forward, (target - transform.position), Mathf.PI * 2f, 0.0F);
            transform.rotation = Quaternion.LookRotation(newDir);
        }
    }
}