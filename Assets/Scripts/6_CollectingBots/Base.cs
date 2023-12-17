using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] private Harvester _harvesterPrefab;
    [SerializeField] private Transform _harvesterSpawnPointsContainer;
    [SerializeField] private Transform _harvesterContainer;

    private Transform[] _harvesterSpawnPoints;

    private void Start()
    {
        _harvesterSpawnPoints = new Transform[_harvesterSpawnPointsContainer.childCount];

        for (int i = 0; i < _harvesterSpawnPointsContainer.childCount; i++)
            _harvesterSpawnPoints[i] = _harvesterSpawnPointsContainer.GetChild(i);

        SpawnHarvesters();
    }

    private void Update()
    {
        ScanArea();
    }

    private void SpawnHarvesters()
    {
        for (int i = 0; i < _harvesterSpawnPoints.Length; i++)
        {
            Harvester harvester = Instantiate(_harvesterPrefab, _harvesterSpawnPoints[i].transform.position, Quaternion.identity, _harvesterContainer);
            harvester.SetBaseTransform(_harvesterSpawnPoints[i]);
        }
    }

    private void ScanArea()
    {

    }
}
