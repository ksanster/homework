using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace Game.FX
{
    public class DepthOfFieldFx : FxBase
    {
        [SerializeField]
        private Transform cam;

        [Range(0, 1)]
        [SerializeField]
        private float focusSpeed = 1;
        
        [SerializeField]
        private float offset;

        [SerializeField]
        private LayerMask mask;

        private float initialFocus = 50f;
        
        
        private DepthOfField dofSettings;

        protected override void Init()
        {
            base.Init();

            if (!activeVolume.profile.TryGetSettings(out dofSettings))
            {
                dofSettings = activeVolume.profile.AddSettings<DepthOfField>();
            }
            dofSettings.focusDistance.value = initialFocus;
        }

        protected override void ApplyFx()
        {
            dofSettings = activeVolume.sharedProfile.GetSetting<DepthOfField>();
            RaycastHit hit;       
            
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 500, mask))
            {
                var pos = cam.transform.position + offset * cam.transform.forward; //камера висит сзади персонажа
                var distance = Vector3.Distance(pos, hit.point);
                dofSettings.focusDistance.value = Mathf.Lerp(dofSettings.focusDistance.value , distance, focusSpeed);            
            }
            else
            {
                dofSettings.focusDistance.value = initialFocus;
            }
        }
    }
}