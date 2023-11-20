using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private Transform _pointsContainer;
    [SerializeField] private GameObject _enemy;
    [SerializeField] private int _enemyCount;

    private Transform[] _points;
    private int _angles = 365;

    private void Start()
    {
        _points = new Transform[_pointsContainer.childCount];
        
        for (int i = 0; i < _pointsContainer.childCount; i++)
        {
            _points[i] = _pointsContainer.GetChild(i);
        }

        var CreateEnemyInJob = StartCoroutine(CreateEnemy());
    }

    private IEnumerator CreateEnemy()
    {
        var waitSomeSeconds = new WaitForSecondsRealtime(2f);

        for(int i = 0; i < _enemyCount; i++)
        {
            int pointIndex = Random.Range(0, _points.Length);

            var enemy = Instantiate(_enemy, _points[pointIndex].position, _enemy.transform.rotation * Quaternion.Euler(0, Random.Range(0, _angles), 0));
            //enemy.transform.Rotate(0, Random.Range(0, angles), 0);

            yield return waitSomeSeconds;
        }
    }
}

