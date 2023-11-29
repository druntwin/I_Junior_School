using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletsShooting : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
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
            Vector3 direction = (_target.position - transform.position).normalized;
            GameObject bullet = Instantiate(_bulletPrefab, transform.position + direction, Quaternion.identity);
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();

            bulletRigidbody.transform.up = direction;
            bulletRigidbody.velocity = direction * _speed * Time.deltaTime;

            yield return new WaitForSeconds(_shootingDelay);
        }
    }
}