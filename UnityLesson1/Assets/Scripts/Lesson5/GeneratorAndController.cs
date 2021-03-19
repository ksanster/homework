using UnityEngine;

namespace Lesson5
{
    public class GeneratorAndController : GeneratorBase
    {
        private readonly Transform[] items = new Transform[NumObjects];
        protected override void InstantiateObjects()
        {
            var pos = startPos;
            for (var i = 0; i < NumObjects; i++)
            {
                items[i] = Instantiate(prefab, pos, Quaternion.identity).transform;
                pos += step; 
            }
        }

        private void Update()
        {
            for (var i = 0; i < NumObjects; i++)
            {
                items[i].Rotate(Vector3.forward, 0.1f);
            }
        }
    }
}