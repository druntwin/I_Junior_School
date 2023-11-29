using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByWaypoints : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private Transform _path;

    private Transform[] _points;
    private int _currentPointIndex;

    void Start()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
            _points[i] = _path.GetChild(i);
    }

    public void Update()
    {
        var targetPoint = _points[_currentPointIndex];

        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, _speed * Time.deltaTime);


        if (transform.position == targetPoint.position)
        {
            _currentPointIndex++;

            if (_currentPointIndex >= _points.Length)
            {
                _currentPointIndex = 0;
            }
        }
    }
}