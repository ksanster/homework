using UnityEngine;

namespace Game.FX
{
    public class SkyLight : MonoBehaviour
    {
        [SerializeField]
        private Color sky;
        [SerializeField]
        private Color equator;
        [SerializeField]
        private Color ground;
        [SerializeField]
        private Color sunColor;
        
        [SerializeField]
        private float rotateSpeed;
        
        private Light sun;
        
        void Start ()
        {
            sun = GetComponent<Light>();
        }   

        void Update ()
        {
            // Настраиваем Ambient Skybox Color
            RenderSettings.ambientSkyColor = sky;
            RenderSettings.ambientGroundColor = ground;
            RenderSettings.ambientEquatorColor = equator;
            // Настраиваем цвет солнца
            sun.color = sunColor;
            // Вращаем солнце
            transform.Rotate(transform.right, rotateSpeed, Space.Self);
        }

    }
}