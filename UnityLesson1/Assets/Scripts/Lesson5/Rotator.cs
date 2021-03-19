using UnityEngine;

namespace Lesson5
{
    public class Rotator : MonoBehaviour
    {
        private void Update()
        {
            transform.Rotate(Vector3.forward, 1f);
        }
    }
}