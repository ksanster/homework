using UnityEngine;

namespace Lesson6
{
    public class FollowTarget : MonoBehaviour
    {
        [SerializeField]
        private Transform target;
        [SerializeField]
        private float smooth = 0.9f;
        
        private Vector3 offset;

        private void Start()
        {
            offset = transform.position - target.position;
        }

        private void Update()
        {
            transform.position = Vector3.Lerp (transform.position, target.position + offset, Time.deltaTime * smooth);
        }
    }
}