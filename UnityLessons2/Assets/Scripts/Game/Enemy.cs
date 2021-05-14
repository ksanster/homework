using System.Linq;
using Game.FX;
using UnityEngine;

namespace Game
{
    public class Enemy : MonoBehaviour
    {
        private const float Force = 50f;
        private Rigidbody[] rigidBodies;
        private Animator animator;

        private bool IsAlive
        {
            set => animator.enabled = value;
        }
        
        private void Start()
        {
            rigidBodies = GetComponentsInChildren<Rigidbody>();
            animator = GetComponent<Animator>();
        }
        
        private void KillMyself(Vector3 forcePosition, Vector3 forceDirection)
        {
            Debug.Log("kill");
            IsAlive = false;
            rigidBodies.OrderBy(body => (body.position - forcePosition).sqrMagnitude).First().AddForce(Force * forceDirection, ForceMode.Impulse);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Bullet"))
            {
                KillMyself(other.transform.position, other.GetComponent<Fireball>().Direction.normalized);
            }
        }
    }
}