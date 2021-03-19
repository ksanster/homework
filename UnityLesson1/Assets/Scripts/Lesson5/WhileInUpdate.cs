using UnityEngine;

namespace Lesson5
{
    public class WhileInUpdate : MonoBehaviour
    {
        [SerializeField]
        private float speed = 0.001f;
        [SerializeField]
        private int numIterations = 10000;
        
        private void Update()
        {
            var i = 0;
            while (i < numIterations)
            {
                transform.Translate(speed, 0, 0);
                i++;
            }
        }
    }
}