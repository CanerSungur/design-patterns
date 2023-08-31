using UnityEngine;

namespace DesignPatterns.Observer
{
    public class Cannon : MonoBehaviour
    {
        [SerializeField] private GameObject _projectilePrefab;
        [SerializeField] private Transform _firePointTransform;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                SpawnProjectile();
        }

        private void SpawnProjectile()
        {
            Instantiate(_projectilePrefab, _firePointTransform.position, _firePointTransform.rotation);
        }
    }
}
