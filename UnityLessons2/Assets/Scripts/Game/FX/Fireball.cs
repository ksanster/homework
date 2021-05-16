using UnityEngine;

namespace Game.FX
{
    public class Fireball : MonoBehaviour
    {
        [SerializeField]
        private GameObject explosionPrefab;
        
        [SerializeField]
        private float speed;
        
        public Vector3 Direction { get; set; }

        private void OnTriggerEnter(Collider other)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        private void OnBecameInvisible()
        {
            Destroy(gameObject);
        }

        private void Update()
        {
            transform.Translate(speed * Time.deltaTime * Direction);
        }
    }
}