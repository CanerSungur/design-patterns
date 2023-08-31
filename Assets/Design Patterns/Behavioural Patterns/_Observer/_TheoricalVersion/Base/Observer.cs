using UnityEngine;

namespace DesignPatterns.Observer
{
    public abstract class Observer : MonoBehaviour
    {
        [SerializeField] private SubjectType _subjectType;
        public SubjectType SubjectType => _subjectType;
        public abstract void OnNotify(NotificationType notificationType);
    }
}
