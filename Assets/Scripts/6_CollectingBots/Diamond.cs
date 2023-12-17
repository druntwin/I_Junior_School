using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    private Vector3 _transportPosition = new Vector3(0, 3, 0);
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent(out Harvester harvester))
        {
            Debug.Log("HARV");
            harvester.ChangeTargetToBase();
            transform.parent = collision.transform;
            transform.localPosition = _transportPosition;
        }
    }
}
