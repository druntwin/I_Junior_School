using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour
{
    [SerializeField] private float _checkDistance;
    [SerializeField] private Transform _raycastPoint;
    [SerializeField] private Block _blockPrefab;
    [SerializeField] private BuildPreview _buildPreviewer;

    private RaycastHit _raycastInfo;

    private Vector3 BuildPosition => _raycastInfo.transform.position + _raycastInfo.normal;

    private void Update()
    {
        if(_raycastInfo.transform == null)
            return;

        if (_raycastInfo.transform.GetComponent<Block>() == null)
            return;

        if (Input.GetMouseButton(0))
            Build();
    }

    private void FixedUpdate()
    {
        if(Physics.Raycast(_raycastPoint.position, _raycastPoint.forward, out _raycastInfo, _checkDistance))
        {
            if(_buildPreviewer.IsActive == false)
            {
                _buildPreviewer.Enable();
            }

            _buildPreviewer.SetPosition(BuildPosition);
        }
        else
        {
            _buildPreviewer.Disable();
        }
    }

    private void Build()
    {
        Vector3 position = BuildPosition;

        Instantiate(_blockPrefab, position, Quaternion.identity);
    }
}
