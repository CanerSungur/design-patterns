using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Observer
{
    public class ObserverManager : MonoBehaviour
    {
        [SerializeField] private Observer[] _observers;

        #region Singleton
        private static ObserverManager _instance = null;
        public static ObserverManager Instance => _instance;
        #endregion

        private void Awake()
        {
            if (_instance == null)
                _instance = this;
        }

        private List<Subject> _subjects = null;

        public void RegisterSubject(Subject subject)
        {
            if (_subjects == null) _subjects = new List<Subject>();

            if (!_subjects.Contains(subject))
                _subjects.Add(subject);

            foreach (var observer in _observers)
            {
                if (observer.SubjectType == subject.SubjectType)
                    subject.RegisterObserver(observer);
            }
        }
    }

    public enum NotificationType
    {
        ForwardButton,
        BackButton,
        LeftButton,
        RightButton
    }

    public enum SubjectType
    {
        Movement
    }
}
