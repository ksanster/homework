using UnityEngine;

namespace Lesson7
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioVisualizer : MonoBehaviour
    {
        private const int NumPoints = 512;
        private const float Delta = 360f / (NumPoints - 1f);
        
        [SerializeField]
        private float radius = 5f;
        [SerializeField]
        private Transform cube;
        [SerializeField]
        private float amplitude = 100f;
        
        private int offset = 128;
        
        private float minSize = 2f;
        private float maxSize = 5f;

        private readonly float[] spectrum = new float[NumPoints];
        
        private AudioSource audioSource;
        private LineRenderer lineRenderer;
        

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
            lineRenderer = gameObject.AddComponent<LineRenderer>();
            lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
            lineRenderer.widthMultiplier = 0.1f;
            lineRenderer.positionCount = NumPoints;
            lineRenderer.colorGradient = CreateGradient();
        }

        private Gradient CreateGradient()
        {
            var result = new Gradient();
            result.mode = GradientMode.Blend;
            var colors = new []
            {
                new GradientColorKey(Color.red, 0f),
                new GradientColorKey(Color.blue, 0.5f),
                new GradientColorKey(Color.red, 1f)
            };
            var alphas = new []
            {
                new GradientAlphaKey(1, 0), 
                new GradientAlphaKey(1, 0.5f), 
                new GradientAlphaKey(1, 1f) 
            };
            
            result.SetKeys(colors, alphas);
            return result;
        }

        private void Update()
        {
            float height=0;
            float max = 0;
            int indexOfMax = 0;

            audioSource.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);
            for (int i = 0; i < NumPoints; i++)
            {
                var index = (i + offset) % NumPoints;
                var amp = radius + Mathf.Lerp(0, 0.5f, spectrum[index] * amplitude);
                var pos = Quaternion.AngleAxis(Delta * i, Vector3.forward) * (amp * Vector3.up);
                lineRenderer.SetPosition(i, pos);
                
                if (spectrum[i] > max)
                {
                    max = spectrum[i];
                    indexOfMax = i;
                }
                //calculate the sum of all amplitudes
                height += spectrum[i];
            }
            
            //height shows the average amplitude of the sample
            height = minSize + (maxSize-minSize)*(height / NumPoints);
            //width shows the Frequenz with the highest amplitude of the sample
            float width = minSize + indexOfMax * (maxSize - minSize) / NumPoints;
            //depth shows the highest amplitude of the sample
            float depth = minSize + (maxSize - minSize) * max;
            cube.transform.localScale = new Vector3(width, height, depth);

        }
    }
}