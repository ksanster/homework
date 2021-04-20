using UnityEngine;

namespace Lesson5
{
    public class GeneratorBase : MonoBehaviour
    {
        protected const int NumObjects = 10000;
        protected Vector3 startPos = Vector3.zero;
        protected Vector3 step = new Vector3(1f, 0, 0.1f);


        [SerializeField]
        protected GameObject prefab;

        private void Start()
        {
            InstantiateObjects();
        }

        protected virtual void InstantiateObjects()
        {
            var pos = startPos;
            
            for (var i = 0; i < NumObjects; i++)
            {
                Instantiate(prefab, pos, Quaternion.identity);
                pos += step; 
            }
        }
    }
}