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


        private void Start()
        {
            StartCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            while (true)
            {
                var fireball = Instantiate(fireballPrefab, transform.position, Quaternion.identity);
                fireball.Direction = transform.rotation * Vector3.forward;
                yield return new WaitForSeconds(deltaTimeInSeconds);
            }
        }
    }
}