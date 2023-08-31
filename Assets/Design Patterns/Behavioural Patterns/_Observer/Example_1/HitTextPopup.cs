using UnityEngine;
using TMPro;
using System.Collections;

namespace DesignPatterns.Observer
{
    /// <summary>
    /// This script uses the Observer pattern to start watching a
    /// Health object. This example shows how you can subscribe/unsubscribe
    /// whenever you need it, without using OnEnable or OnDisable.
    /// Technically we start observing in Awake, but we can call the 
    /// 'StartObservingHealth' method whenever we want. Think of it as
    /// 'AcquireTarget' and 'LoseTarget' if we wanted to put it in a GameContext
    /// </summary>
    public class HitTextPopup : MonoBehaviour
    {
        [SerializeField] private Health _healthToObserve = null;
        [SerializeField] private TextMeshProUGUI _textPopupUI = null;

        [SerializeField] private string _hitText = "Hit!";
        [SerializeField] private string _killText = "KILL";
        [SerializeField] private float _textPopupDuration = 1;

        private Health _observedHealth = null;
        private Coroutine _popupCoroutine = null;

        private void Awake()
        {
            StartObservingHealth(_healthToObserve);
        }

        private void StartObservingHealth(Health newHealthToObserve)
        {
            _observedHealth = newHealthToObserve;
            // notify when target is damaged
            _observedHealth.Damaged += OnObservedHealthDamaged;
            _observedHealth.Killed += OnObservedHealthKilled;
        }

        private void StopObservingHealth()
        {
            // no longer watch target
            _observedHealth.Damaged -= OnObservedHealthDamaged;
            _observedHealth.Killed -= OnObservedHealthKilled;

            _observedHealth = null;
        }

        private void OnObservedHealthDamaged(int amount)
        {
            string hitText = _hitText + " " + amount;

            if (_popupCoroutine != null)
                StopCoroutine(_popupCoroutine);
            _popupCoroutine = StartCoroutine(TextPopup(hitText));
        }

        private void OnObservedHealthKilled()
        {
            if (_popupCoroutine != null)
                StopCoroutine(_popupCoroutine);
            _popupCoroutine = StartCoroutine(TextPopup(_killText));
            StopObservingHealth();
        }

        private IEnumerator TextPopup(string textToShow)
        {
            _textPopupUI.text = textToShow;
            yield return new WaitForSeconds(_textPopupDuration);
            _textPopupUI.text = string.Empty;
        }
    }
}
