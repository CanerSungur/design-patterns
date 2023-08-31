using UnityEngine;

namespace DesignPatterns.Singleton
{
    [RequireComponent(typeof(AudioSource))]
    public class AmbientAudioPlayer : SingletonBase<AmbientAudioPlayer>
    {
        //private static AmbientAudioPlayer _instance;

        //public static AmbientAudioPlayer GetInstance()
        //{
        //    if (_instance == null)
        //    {
        //        throw new System.NullReferenceException("You are trying to access a non existing Ambient Audio Player. Please make sure one exist in the scene!");
        //    }

        //    return _instance;
        //}

        private AudioSource _audioSource;

        //private void Awake()
        //{
        //    if (_instance != null && _instance != this)
        //    {
        //        Debug.LogWarning("There is already an AmbientAudioPlayer in the Scene. There should only be one!\nDestriying this...");
        //        Destroy(this);
        //    }
        //    else
        //    {
        //        _instance = this;
        //        DontDestroyOnLoad(gameObject);
        //        _audioSource = GetComponent<AudioSource>();
        //    }
        //}

        private void Awake()
        {
            if (_audioSource == null)
                _audioSource = GetComponent<AudioSource>();
        }

        public void Play(AudioClip ambientMusic)
        {
            _audioSource.clip = ambientMusic;
            _audioSource.Play();
        }
    }
}
