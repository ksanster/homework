using UnityEngine;

namespace DefaultNamespace
{
    public class ListGenerator : MonoBehaviour
    {
        [SerializeField]
        private Transform content;
        [SerializeField]
        private Transform prefab;

        private void Start()
        {
            const int Count = 1000;
            
            for (var i = 0; i < Count; i++)
            {
                var item = Instantiate(prefab, content);
            }
        }
    }
}