using UnityEngine;
using System;

namespace DesignPatterns.Observer
{
    /// <summary>
    /// This is a generic health class that acts as the 'Subject' in our Observer pattern.
    /// Other classes can watch for Damaged, Healed, and Killed events and respond appropriately.
    /// We can also optionally send out the amount associated with being Damaged/Healed if we want, which
    /// could be useful for UI systems, Pop-up damage text, etc.
    /// </summary>
    public class Health : MonoBehaviour
    {
        public event Action<int> Damaged = delegate { };
        public event Action<int> Healed = delegate { };
        public event Action Killed = delegate { };

        [SerializeField] private int _maxHealth = 100;
        public int MaxHealth => _maxHealth;

        private int _currentHealth;
        public int CurrentHealth
        {
            get => _currentHealth;
            set
            {
                // ensure we can't go above our max health
                if (value > _maxHealth)
                    value = _maxHealth;
                else if (value < 0)
                    value = 0;

                _currentHealth = value;
            }
        }

        private void Awake()
        {
            CurrentHealth = _maxHealth;
        }

        public void Heal(int amount)
        {
            _currentHealth += amount;
            Healed.Invoke(amount);
        }

        public void TakeDamage(int amount)
        {
            _currentHealth -= amount;
            Damaged.Invoke(amount);

            if (_currentHealth <= 0)
                Kill();
        }

        public void Kill()
        {
            Killed.Invoke();
            gameObject.SetActive(false);
        }
    }
}
