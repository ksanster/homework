using UnityEngine;
using Random = UnityEngine.Random;

namespace Lesson5
{
    public class Rotator : MonoBehaviour
    {
        [SerializeField]
        private float speed = 1f;
        
        private Vector3 direction;

        private void Start()
        {
            direction = Random.insideUnitSphere;
        }

        private void Update()
        {
            transform.Rotate(direction, speed);
        }
    }
}