using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargetMover : MonoBehaviour 
{
    [SerializeField][Range(0f, 10f)] private float _speed = 2f;

    private Transform _targetPoint;

    private void OnEnable()
    {
        if (_targetPoint == null)
            _targetPoint = transform;
    }

    private void Update()
    {
        Move();
    }

    public void SetTargetPoint(Transform targetPoint)
    {
        _targetPoint = targetPoint;
    }

    private void Move()
    {
        transform.LookAt(_targetPoint.position);
        transform.position = Vector3.MoveTowards(transform.position, _targetPoint.position, _speed * Time.deltaTime);
    }
}
