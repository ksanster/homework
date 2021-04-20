using System;
using UnityEngine;

namespace Lesson5
{
    public class GrenadeController : MonoBehaviour
    {
        private const float GrenadeRange = 5f;
        private const float ExplosionForce = 1000f;
        [SerializeField]
        private Grenader player;
        
        [SerializeField]
        private Rigidbody[] environment;
        
        private Camera mainCamera;

        private void Start()
        {
            mainCamera = Camera.main;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var grenade = player.ThrowGrenade();
                grenade.OnCollide += Explode;
            }
            if (Input.GetKeyDown(KeyCode.Space))
                player.Jump();
        }

        private void FixedUpdate()
        {
            var hmove = Input.GetAxis("Horizontal");
            var vmove = Input.GetAxis("Vertical");
            var movement = new Vector3(hmove, 0, vmove);

            player.Move(movement);
            
            if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out var hit, 100))
                player.LookTo(hit.point);

        }

        private void Explode(Transform t)
        {
            foreach (var item in environment)
            {
                if (Vector3.Distance(item.position, t.position) < GrenadeRange)
                    item.AddExplosionForce(ExplosionForce, t.position, GrenadeRange);
            }
            
            GameObject.Destroy(t.gameObject);
        }


    }
}