using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletsShooting : MonoBehaviour
{
    [SerializeField] private Rigidbody _bulletPrefab;
    [SerializeField] private float _shootingDelay;
    [SerializeField] private float _speed;
    [SerializeField] private Transform _target;

    void Start()
    {
        StartCoroutine(DoShot());
    }

    IEnumerator DoShot()
    {
        bool _isShooting = true;

        while (_isShooting)
        {
            var waitSomeSeconds = new WaitForSeconds(_shootingDelay);
            Vector3 direction = (_target.position - transform.position).normalized;
            Rigidbody bulletRigidbody = Instantiate(_bulletPrefab, transform.position + direction, Quaternion.identity);

            bulletRigidbody.transform.up = direction;
            bulletRigidbody.velocity = direction * _speed * Time.deltaTime;

            yield return waitSomeSeconds;
        }
    }
}