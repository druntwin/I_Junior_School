using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingY : MonoBehaviour
{
    [SerializeField] private bool _direction = false;
    [SerializeField] [Range(0f, 1000f)] private float _rotationSpeed = 100f;
    private sbyte _negativeDirection = -1;
    private sbyte _positiveDirection = 1;
    private sbyte _directionIndex;
    private float _currentRotationY;
    private float _newRotationY;

    private void Update()
    {
        if (_direction)
            _directionIndex = _positiveDirection;
        else
            _directionIndex = _negativeDirection;

        _currentRotationY = gameObject.transform.rotation.y;
        _newRotationY = (_currentRotationY + _rotationSpeed) * _directionIndex * Time.deltaTime;
        gameObject.transform.Rotate(0, _newRotationY, 0);
    }
}
