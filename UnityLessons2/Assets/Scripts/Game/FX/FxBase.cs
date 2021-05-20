using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace Game.FX
{
    public class FxBase : MonoBehaviour
    {
        protected PostProcessVolume activeVolume;

        private void Start()
        {
            Init();
        }

        protected virtual void Init()
        {
            var volumes = new List<PostProcessVolume>();
            PostProcessManager.instance.GetActiveVolumes(GetComponent<PostProcessLayer>(), volumes);
            activeVolume = volumes.First();
        }
        
        protected virtual void ApplyFx()
        {
            
        }

        private void Update()
        {
            ApplyFx();
        }
    }
}