using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

namespace DesignPatterns.Singleton
{
    public class PlayRandomMusicOnStart : MonoBehaviour
    {
        [SerializeField] private List<AudioClip> _audioClips;

        private void Start()
        {
            if (_audioClips == null || _audioClips.Count < 1)
            {
                Debug.Log("No audio resource. Destroying this...");
                Destroy(this);
            }

            try
            {
                AmbientAudioPlayer.Instance.Play(_audioClips[Random.Range(0, _audioClips.Count)]);
            }
            catch (Exception e)
            {
                Debug.LogWarning(e);
                Destroy(this);
            }
        }
    }
}
