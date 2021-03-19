using System;
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
        private GameObject door;

        private void Awake()
        {
            secretTarget.OnCollide += go =>
            {
                if (go == secretCube)
                {
                    Debug.Log("Door is open!");
                    Destroy(door);
                }
            };
        }
    }
}