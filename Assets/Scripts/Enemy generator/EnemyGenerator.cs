using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Transform))]
[RequireComponent(typeof(EnemyMover))]
public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private Transform _pointsContainer;
    [SerializeField] private EnemyMover _enemyPrefab;
    [SerializeField] private int _enemyCount;

    private Transform[] _points;

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
            sbyte directionY = 0;
            int pointIndex = Random.Range(0, _points.Length);
            Vector2 direction2D = Random.insideUnitCircle.normalized;
            Vector3 direction = new Vector3(direction2D.x, directionY, direction2D.y);

            var enemy = Instantiate(_enemyPrefab, _points[pointIndex].position, Quaternion.identity);
            enemy.SetDirection(direction);

            yield return waitSomeSeconds;
        }
    }
}

