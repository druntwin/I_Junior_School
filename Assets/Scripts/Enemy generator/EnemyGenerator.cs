using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Transform))]
[RequireComponent(typeof(Enemy))]
public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private Transform _pointsContainer;
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private int _enemyCount;

    private Transform[] _points;
    private int _maxAngle = 365;

    private void Start()
    {
        _points = new Transform[_pointsContainer.childCount];
        
        for (int i = 0; i < _pointsContainer.childCount; i++)
            _points[i] = _pointsContainer.GetChild(i);

        var CreateEnemyInJob = StartCoroutine(CreateEnemy());
    }

    private IEnumerator CreateEnemy()
    {
        float delay = 2f;
        var waitSomeSeconds = new WaitForSecondsRealtime(delay);

        for(int i = 0; i < _enemyCount; i++)
        {
            int pointIndex = Random.Range(0, _points.Length);

            var enemy = Instantiate(_enemyPrefab, _points[pointIndex].position, _enemyPrefab.transform.rotation * Quaternion.Euler(0, Random.Range(0, _maxAngle), 0));

            yield return waitSomeSeconds;
        }
    }
}

