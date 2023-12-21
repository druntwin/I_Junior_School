using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Diamond : MonoBehaviour
{
    public bool IsCollected { get; private set; }

    private void OnEnable()
    {
        IsCollected = false;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent(out Harvester harvester))
        {
            IsCollected = true;
        }
    }
}
