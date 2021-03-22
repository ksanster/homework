using UnityEngine;
using UnityEngine.UI;

namespace Lesson5
{
    public class GrenadeController : MonoBehaviour
    {
        private const float GrenadeRange = 5f;
        private const float ExplosionForce = 1000f;
        [SerializeField]
        private Grenader player;
        [SerializeField]
        private float maxChargeTime = 5f; 
        
        [SerializeField]
        private Rigidbody[] environment;
        
        [SerializeField]
        private Slider jumpSlider;
        
        private Camera mainCamera;
        private float startChargeTime;
        

        private void Start()
        {
            mainCamera = Camera.main;
            jumpSlider.maxValue = maxChargeTime;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var grenade = player.ThrowGrenade();
                grenade.OnCollide += Explode;
            }
            if (Input.GetKeyDown(KeyCode.Space))
                startChargeTime = Time.time;
            
            if (startChargeTime > 0)
            {
                var mult = Mathf.Clamp(Time.time - startChargeTime, 0, maxChargeTime);
                jumpSlider.value = mult;
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    player.Jump(1 + mult);
                    startChargeTime = 0;
                    jumpSlider.value = 0;
                }                
            }
                
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
            
            Destroy(t.gameObject);
        }


    }
}