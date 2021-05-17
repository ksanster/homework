using UnityEngine;

namespace Game.FX
{
    public class Explosion : MonoBehaviour
    {
        private const float MinLightIntensity = 0.1f; 
        [SerializeField]
        private float fadeSpeed;
        
        private Light flash;
        
        private void Start()
        {
            flash = GetComponent<Light>();
        }

        private void Update()
        {
            flash.intensity = Mathf.Lerp(flash.intensity, 0, fadeSpeed * Time.deltaTime);
            if (flash.intensity < MinLightIntensity)
            {
                Destroy(gameObject);
            }
        }
    }
}