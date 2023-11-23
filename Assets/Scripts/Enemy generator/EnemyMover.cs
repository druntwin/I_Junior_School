using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour 
{
    [SerializeField][Range(0f, 10f)] private float _moveSpeed = 2f;
    private Vector3 _direction;

    private void OnEnable()
    {
        if (_direction == null)
            _direction = transform.forward;
    }

    private void Update()
    {
        Move();        
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = direction;
        transform.LookAt(transform.position + _direction);
    }

    private void Move()
    {
        transform.position += _direction * _moveSpeed * Time.deltaTime;
    }
}
