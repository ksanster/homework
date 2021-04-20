using Lesson6;
using UnityEngine;

namespace Lesson5
{
    public class SecretController : MonoBehaviour
    {
        [SerializeField]
        private GameObject secretCube;
        [SerializeField]
        private SecretTarget secretTarget;
        [SerializeField]
        private Door door;

        private void Awake()
        {
            secretTarget.OnCollide += go =>
            {
                if (go == secretCube)
                {
                    door.Open();                    
                }
            };
        }
    }
}