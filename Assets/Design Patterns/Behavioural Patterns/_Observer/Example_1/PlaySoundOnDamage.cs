using System.Runtime.Serialization;
using UnityEngine;

namespace DesignPatterns.Observer
{
    /// <summary>
    /// This script uses the observer pattern to play sound effects
    /// whenever the observed health takes damage or is killed.
    /// Note that this script doesn't know about any other scripts
    /// or Observers other than the Health, our Subject.
    /// Usually you may want to combine this into other class behaviour, but I think this is a usefull 
    /// way of seeing how event calls allow you to break down classes as much as you need.
    /// </summary>
    [RequireComponent(typeof(Health))]
    public class PlaySoundOnDamage : MonoBehaviour
    {
        [SerializeField] private AudioClip _damagedSound = null;
        [SerializeField] private AudioClip _killedSound = null;

        private Health _health = null;

        private void Awake()
        {
            _health = GetComponent<Health>();
        }

        private void OnEnable()
        {
            _health.Damaged += OnDamaged;
            _health.Killed += OnKilled;
        }

        private void OnDisable()
        {
            _health.Damaged -= OnDamaged;
            _health.Killed -= OnKilled;
        }

        private void OnDamaged(int amount)
        {
            if (_damagedSound != null)
                AudioSource.PlayClipAtPoint(_damagedSound, Vector3.zero);
        }

        private void OnKilled()
        {
            if (_killedSound != null)
                AudioSource.PlayClipAtPoint(_killedSound, Vector3.zero);
        }
    }
}
