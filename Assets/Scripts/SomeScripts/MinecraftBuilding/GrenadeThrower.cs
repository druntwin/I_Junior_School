using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeThrower : MonoBehaviour
{
    [SerializeField] private Grenade _grenadePrefab;
    [SerializeField] private float _throwForce;
    [SerializeField] private Transform _throwPoint;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Grenade grenade = Instantiate(_grenadePrefab, _throwPoint.position, _throwPoint.rotation);
            grenade.Throw(_throwPoint.forward * _throwForce);
        }
    }
}
