using UnityEngine;

namespace Game.FX
{
    public class Spotlight : MonoBehaviour
    {
        [SerializeField]
        private float speed;

        [SerializeField]
        private Transform[] bounds;
        [SerializeField]
        private Quaternion toTransform;
        
        private Transform target;
        private int index;
        
        private void Start()
        {
            index = 0;
            target = bounds[index];
        }

        private void Update()
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, target.rotation, speed * Time.deltaTime);
            
            var left = Quaternion.Angle(transform.rotation, target.rotation);
            if (Mathf.Approximately(left, 0))
            {
                index = (index + 1) % bounds.Length;
                target = bounds[index];
            }
        }
    }
}