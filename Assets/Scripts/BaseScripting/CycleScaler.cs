using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleScaler : MonoBehaviour
{
    [SerializeField][Range(1f, 5f)] private float _minScale = 1;
    [SerializeField][Range(1f, 5f)] private float _maxScale = 2;
    [SerializeField][Range(0f, 2f)] private float _speed = 0.5f;

    private float _positiveDirection = 1;
    private float _negativeDirection = -1;
    private float _scaleDirection;
    private float _scaleIndex = 0f;
    private Vector3 _scaleVector = new Vector3(1, 1, 1);

    private void Update()
    {
        if(_scaleIndex <= 0)
            _scaleDirection = _positiveDirection;
        else if (_scaleIndex >= 1)
            _scaleDirection = _negativeDirection;

        _scaleIndex += Time.deltaTime * _speed * _scaleDirection;
        transform.localScale = Vector3.Lerp(_scaleVector * _minScale, _scaleVector * _maxScale, _scaleIndex);
    }
}
