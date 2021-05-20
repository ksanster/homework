using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace Game.FX
{
    public class ColorGradingFx : FxBase
    {
        [SerializeField]
        private Transform target;
        [SerializeField]
        private float minDistance;
        [SerializeField]
        private float targetTemperature;
        
        private ColorGrading cgSettings;
        private float initialTemperature = 0;


        protected override void Init()
        {
            base.Init();

            if (!activeVolume.profile.TryGetSettings(out cgSettings))
            {
                cgSettings = activeVolume.profile.AddSettings<ColorGrading>();
            }
            cgSettings.temperature.value = initialTemperature;
        }

        protected override void ApplyFx()
        {
            cgSettings = activeVolume.sharedProfile.GetSetting<ColorGrading>();
            var distance = Vector3.Distance(transform.position, target.position);
            distance = Mathf.Clamp(distance, 0, minDistance);

            cgSettings.temperature.value = Mathf.Lerp(
                initialTemperature, 
                targetTemperature, 
                1f - distance / minDistance);
        }
    }
}