using UnityEngine;

namespace Game.FX
{
    public class Explosion : MonoBehaviour
    {
        private const float MinLightIntensity = 0.1f; 
        [SerializeField]
        private float fadeSpeed;
        
        private Light light;
        
        private void Start()
        {
            light = GetComponent<Light>();
        }

        private void Update()
        {
            light.intensity = Mathf.Lerp(light.intensity, 0, fadeSpeed * Time.deltaTime);
            if (light.intensity < MinLightIntensity)
            {
                Destroy(gameObject);
            }
        }
    }
}