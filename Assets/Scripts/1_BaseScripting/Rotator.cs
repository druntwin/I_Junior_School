using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private bool _isPositiveRotation = false;
    [SerializeField] [Range(0f, 1000f)] private float _rotationSpeed = 100f;
    private sbyte _negativeRotation = -1;
    private sbyte _positiveRotation = 1;
    private sbyte _directionIndex;
    private float _currentRotationY;
    private float _newRotationY;

    private void Update()
    {
        if (_isPositiveRotation)
            _directionIndex = _positiveRotation;
        else
            _directionIndex = _negativeRotation;

        _currentRotationY = gameObject.transform.rotation.y;
        _newRotationY = (_currentRotationY + _rotationSpeed) * _directionIndex * Time.deltaTime;
        gameObject.transform.Rotate(0, _newRotationY, 0);
    }
}
