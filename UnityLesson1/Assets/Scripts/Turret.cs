using UnityEngine;

namespace DefaultNamespace
{
    public class Turret : MonoBehaviour
    {
        private const float MinAngle = 1f;
        [SerializeField]
        private Transform player;
        [SerializeField]
        private float maxRange; 
        [SerializeField]
        private float rotationSpeed;
        [SerializeField]
        private Bullet bulletPrefab;
        [SerializeField]
        private float pauseBetweenFire;
        
        private float fireTime;

        private void Update()
        {
            var relativePos = player.position - transform.position;
            var range = relativePos.magnitude;
            if (range <= maxRange)
            {
                var rotation = Quaternion.LookRotation(relativePos);
                transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
                
                var angle = Quaternion.Angle(transform.rotation, rotation);
                if (angle < MinAngle)
                    Fire();
            }
        }

        private void Fire()
        {
            if (Time.time - fireTime > pauseBetweenFire)
            {
                fireTime = Time.time;
                var bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
                bullet.Target = player.position;
            }
        }
        
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, maxRange);
        }
    }
}