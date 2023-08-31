using UnityEngine;

namespace DesignPatterns.Observer
{
    /// <summary>
    /// This class is a simple projectile that is the catalyst for triggering a Damaged event.
    /// This is also a fairly typical scenario of the type of way you may implement damage in your games.
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float _travelSpeed = 5f;
        [SerializeField] private int _damage = 20;

        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            Travel(_rigidbody);
        }

        private void Travel(Rigidbody rigidbody)
        {
            Vector3 moveOffset = transform.forward * _travelSpeed;
            rigidbody.MovePosition(rigidbody.position + moveOffset);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out Health health))
            {
                health.TakeDamage(_damage);
                Destroy(gameObject);
            }
            // Health health = collision.gameObject.GetComponent<Health>();
            // health?.TakeDamage(_damage);
            // Destroy(gameObject);
        }
    }
}
