using UnityEngine;
using UnityEngine.UI;

namespace DesignPatterns.Observer
{
    /// <summary>
    /// This class handles the communication between the health slider and the health events.
    /// This is also where we may add additional functionality if it was relevant to the Target.
    /// We start listening to the Health events in OnEnable, and stop listening in OnDisable.
    /// </summary>
    public class Target : MonoBehaviour
    {
        [SerializeField] private Slider _slider = null;

        public Health Health { get; private set; }

        private void Awake()
        {
            Health = GetComponent<Health>();

            _slider.maxValue = Health.MaxHealth;
            _slider.value = Health.MaxHealth;
        }

        private void OnEnable()
        {
            // subscribe to get notified when this health takes damage!
            Health.Damaged += OnTakeDamage;
        }

        private void OnDisable()
        {
            Health.Damaged -= OnTakeDamage;
        }

        private void OnTakeDamage(int damage)
        {
            // on damaged, display the new health
            _slider.value = Health.CurrentHealth;
        }
    }
}
