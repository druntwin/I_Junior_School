using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harvester : MonoBehaviour
{
    [SerializeField] private float _speed = 7f;

    private Transform _baseTransform;
    private Transform _targetTransform;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (_targetTransform != null)
        {
            transform.LookAt(_targetTransform.position);
            transform.position = Vector3.MoveTowards(transform.position, _targetTransform.position, _speed * Time.deltaTime);
        }
    }

    public void SetBaseTransform(Transform baseTransform)
    {
        _baseTransform = baseTransform;
    }

    public void SetTargetTransform(Transform targetTransform)
    {
        _targetTransform = targetTransform;
    }

    public void ChangeTargetToBase()
    {
        _targetTransform = _baseTransform;
    }
}
