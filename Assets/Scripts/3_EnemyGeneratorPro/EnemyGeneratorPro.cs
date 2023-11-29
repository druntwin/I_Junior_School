using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Transform))]
public class EnemyGeneratorPro : MonoBehaviour
{
    [SerializeField] private Transform _pointsContainer;
    [SerializeField] private int _enemyCount;

    private Transform[] _points;

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
        float delay = 2f;
        var waitSomeSeconds = new WaitForSecondsRealtime(delay);

        for(int i = 0; i < _enemyCount; i++)
        {
            int pointIndex = Random.Range(0, _points.Length);
            EnemySetter enemySetter = _points[pointIndex].GetComponent<EnemySetter>();
            Transform targetPoint = enemySetter.GetTargetPoint();
            EnemyTargetMover enemyPrefab = enemySetter.GetPrefab();

            var enemy = Instantiate(enemyPrefab, _points[pointIndex].position, Quaternion.identity);
            enemy.SetTargetPoint(targetPoint);
            yield return waitSomeSeconds;
        }
    }
}

