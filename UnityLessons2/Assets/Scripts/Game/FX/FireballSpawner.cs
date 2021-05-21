using System.Collections;
using UnityEngine;

namespace Game.FX
{
    public class FireballSpawner : MonoBehaviour
    {
        [SerializeField]
        private Fireball fireballPrefab;
        
        [SerializeField]
        private float deltaTimeInSeconds;
        
        [SerializeField]
        private bool autoSpawn;
        
        private void Start()
        {
            if (autoSpawn)
                StartCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            while (true)
            {
                CreateFireball();
                yield return new WaitForSeconds(deltaTimeInSeconds);
            }
        }
        
        private void CreateFireball()
        {
            var direction = transform.rotation * Vector3.forward;
            var fireball = Instantiate(fireballPrefab, (transform.position + 2f * direction), Quaternion.identity);
            fireball.Direction = direction;
        }

        private void OnTriggerEnter(Collider other)
        {
            CreateFireball();
        }
    }
}