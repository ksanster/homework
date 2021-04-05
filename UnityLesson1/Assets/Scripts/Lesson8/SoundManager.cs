using UnityEngine;

namespace Lesson8
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager Instance;
        
        [SerializeField]
        private AudioSource musicSource;
        
        private float volume = 1f;
        
        public float Volume
        {
            get => volume; 
            set
            {
                volume = value;
                musicSource.volume = value;
            }
        }
        
        public float Pitch 
        { 
            get => musicSource.pitch; 
            set => musicSource.pitch = value;
        }

        private void Awake()
        {
            Instance = this;
            musicSource = GetComponent<AudioSource>();
            DontDestroyOnLoad(gameObject);
        }

        public void Play()
        {
            musicSource.Play();
        }
        
        public void Stop()
        {
            musicSource.Stop();
        }
    }
}