using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamomdSpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnArea;
    [SerializeField] private Diamond _diamondPrefab;
    [SerializeField] private int _diamondsMaxCount;
    [SerializeField] private int _minSpawnDelay = 1;
    [SerializeField] private int _maxSpawnDelay = 5;

    private Queue<Diamond> _diamonds = new Queue<Diamond>();
    private MeshRenderer _renderer;

    private float _spawnMinPositionX;
    private float _spawnMaxPositionX;
    private float _spawnMinPositionZ;
    private float _spawnMaxPositionZ;

    private void Start()
    {
        _renderer = _spawnArea.GetComponent<MeshRenderer>();        

        CalculateSpawnArea();
        StartCoroutine(CreateDiamonds());
    }

    private void CalculateSpawnArea()
    {
        Vector3 areaSize = _renderer.bounds.size;
        int halfSizeDivider = 2;

        _spawnMinPositionX = transform.position.x - areaSize.x / halfSizeDivider;
        _spawnMaxPositionX = transform.position.x + areaSize.x / halfSizeDivider;
        _spawnMinPositionZ = transform.position.z - areaSize.z / halfSizeDivider;
        _spawnMaxPositionZ = transform.position.z + areaSize.z / halfSizeDivider;
    }

    private IEnumerator CreateDiamonds()
    {
        var waitSomeSeconds = new WaitForSecondsRealtime(Random.Range(_minSpawnDelay, _maxSpawnDelay));

        yield return waitSomeSeconds;

        for (int i = 0; i < _diamondsMaxCount; i++)
        {
            float spawnPositionX = Random.Range(_spawnMinPositionX, _spawnMaxPositionX);
            float spawnPositionZ = Random.Range(_spawnMinPositionZ, _spawnMaxPositionZ);
            int spawnPositionY = 0;

            Diamond diamond = Instantiate(_diamondPrefab, new Vector3(spawnPositionX, spawnPositionY, spawnPositionZ), _diamondPrefab.transform.rotation, transform);
            _diamonds.Enqueue(diamond);

            yield return waitSomeSeconds;
        }
    }

    public Diamond GetDiamond()
    {
        if (_diamonds.Count > 0)
            return _diamonds.Dequeue();

        return null;
    }

    public int GetDiamondsCount()
    {
        return _diamonds.Count;
    }
}
