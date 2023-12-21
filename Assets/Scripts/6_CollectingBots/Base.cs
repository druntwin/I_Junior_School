using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Base : MonoBehaviour
{
    [SerializeField] private Harvester _harvesterPrefab;
    [SerializeField] private Transform _harvesterSpawnPointsContainer;
    [SerializeField] private Transform _harvesterContainer;
    [SerializeField] private DiamomdSpawner _diamomdSpawner;
    [SerializeField] private TextMeshProUGUI _text;
    
    private int _diamondsCount = 0;
    private Transform[] _harvesterSpawnPoints;
    private List<Harvester> _harvestersOnBase = new List<Harvester>();
    private List<Harvester> _harvesters = new List<Harvester>();
    private int _firstFreeHarvester = 0;
    private Vector3 _storagePosition = new Vector3(0, -5, 0);

    private void Start()
    {
        _storagePosition += transform.position;
        _harvesterSpawnPoints = new Transform[_harvesterSpawnPointsContainer.childCount];

        for (int i = 0; i < _harvesterSpawnPointsContainer.childCount; i++)
            _harvesterSpawnPoints[i] = _harvesterSpawnPointsContainer.GetChild(i);

        SpawnHarvesters();
    }

    private void FixedUpdate()
    {
        ShowInfo();
        AssignTarget();
    }

    private void AssignTarget()
    {
        if (_harvestersOnBase.Count > 0 && _diamomdSpawner.GetDiamondsCount() > 0)
        {
            if (_harvestersOnBase[_firstFreeHarvester].IsBusy == false)
            {
                _harvestersOnBase[_firstFreeHarvester].SetTargetTransform(_diamomdSpawner.GetDiamond().transform);
            }
        }
    }

    private void SpawnHarvesters()
    {
        for (int i = 0; i < _harvesterSpawnPoints.Length; i++)
        {
            Harvester harvester = Instantiate(_harvesterPrefab, _harvesterSpawnPoints[i].transform.position, Quaternion.identity, _harvesterContainer);
            harvester.SetBaseTransform(_harvesterSpawnPoints[i]);
            _harvesters.Add(harvester);
        }
    }

    private void ShowInfo()
    { 
        _text.text = $"Собрано кристаллов: {_diamondsCount}";
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent(out Harvester harvester)) 
        {
            if (!_harvestersOnBase.Contains(harvester))
            {
                _harvestersOnBase.Add(harvester);
                harvester.ResetPosition();
            }
        }

        if (collision.TryGetComponent(out Diamond diamond))
        {
            _diamondsCount++;
            diamond.gameObject.SetActive(false);
            diamond.transform.SetParent(null);
            diamond.transform.position = _storagePosition;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.TryGetComponent(out Harvester harvester))
        {
            if (_harvestersOnBase.Contains(harvester))
            {
                _harvestersOnBase.Remove(harvester);
            }
        }
    }
}
