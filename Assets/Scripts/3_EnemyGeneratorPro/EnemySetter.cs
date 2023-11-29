using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySetter : MonoBehaviour
{
    [SerializeField] private EnemyTargetMover _enemyPrefab;

    public EnemyTargetMover GetPrefab()
    {
        return _enemyPrefab;
    }

    public Transform GetTargetPoint()
    {
        int _firstChild = 0;
        Transform targetPoint = transform.GetChild(_firstChild);

        return targetPoint;
    }
}
