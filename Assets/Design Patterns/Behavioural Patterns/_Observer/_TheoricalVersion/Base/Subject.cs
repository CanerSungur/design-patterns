using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Observer
{
    public class Subject : MonoBehaviour
    {
        [SerializeField] private SubjectType _subjectType;
        public SubjectType SubjectType => _subjectType;

        private List<Observer> _observers = null;

        public void RegisterObserver(Observer observer)
        {
            if (_observers == null) _observers = new List<Observer>();

            if (!_observers.Contains(observer))
                _observers.Add(observer);
        }

        private void Start()
        {
            ObserverManager.Instance.RegisterSubject(this);
        }

        public void Notify(NotificationType notificationType)
        {
            foreach (var observer in _observers)
            {
                observer.OnNotify(notificationType);
            }
        }
    }
}
