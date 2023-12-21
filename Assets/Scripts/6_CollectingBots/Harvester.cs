using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harvester : MonoBehaviour
{
    [SerializeField] private float _speed = 7f;

    private Transform _baseTransform;
    private Transform _targetTransform;
    private Vector3 _transportPosition = new Vector3(0, 2.5f, 0);
    private bool _isFull = false;
    public bool IsBusy {get; private set;}

    private void Start()
    {
        IsBusy = false;
    }

    private void Update()
    {
        if (IsBusy)
            Move();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (_isFull == false && collision.TryGetComponent(out Diamond diamond))
        {
            if(diamond.IsCollected == false)
            {
                ChangeTargetToBase();
                diamond.transform.parent = transform;
                diamond.transform.localPosition = _transportPosition;
                _isFull = true;
            }
        }
    }

    private void Move()
    {
        if (_targetTransform != null)
        {
            transform.LookAt(_targetTransform.position);
            transform.position = Vector3.MoveTowards(transform.position, _targetTransform.position, _speed * Time.deltaTime);
        }
    }

    public void ResetPosition()
    {
        transform.position = _baseTransform.position;
        transform.rotation = _baseTransform.rotation;
        IsBusy = false;
        _isFull = false;
    }

    public void SetBaseTransform(Transform baseTransform)
    {
        _baseTransform = baseTransform;        
    }

    public void SetTargetTransform(Transform targetTransform)
    {
        _targetTransform = targetTransform;
        IsBusy = true;
    }

    public void ChangeTargetToBase()
    {
        _targetTransform = _baseTransform;
    }
}
