using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamomdSpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnArea;
    [SerializeField] private Diamond _diamondPrefab;
    [SerializeField] private int _diamondsMaxCount;
    [SerializeField] private int _spawnDelay = 5;

    private List<Diamond> _diamonds = new List<Diamond>();
    private MeshRenderer _renderer;
    private Vector3 _areaSize;

    private void Start()
    {
        _renderer = _spawnArea.GetComponent<MeshRenderer>();
        _areaSize = _renderer.bounds.size;
        
        StartCoroutine(CreateDiamonds());
    }

    private IEnumerator CreateDiamonds()
    {
        var waitSomeSeconds = new WaitForSecondsRealtime(_spawnDelay);

        for (int i = 0; i < _diamondsMaxCount; i++)
        {
            int halfSizeDivider = 2;
            float spawnMinPositionX = transform.position.x - _areaSize.x / halfSizeDivider;
            float spawnMaxPositionX = transform.position.x + _areaSize.x / halfSizeDivider;
            float spawnPositionX = Random.Range(spawnMinPositionX, spawnMaxPositionX);

            float spawnMinPositionZ = transform.position.z - _areaSize.z / halfSizeDivider;
            float spawnMaxPositionZ = transform.position.z + _areaSize.z / halfSizeDivider;
            float spawnPositionZ = Random.Range(spawnMinPositionZ, spawnMaxPositionZ);

            int spawnPositionY = 1;

            var diamond = Instantiate(_diamondPrefab, new Vector3(spawnPositionX, spawnPositionY, spawnPositionZ), Quaternion.identity, transform);
            _diamonds.Add(diamond);

            yield return waitSomeSeconds;
        }
    }
}
