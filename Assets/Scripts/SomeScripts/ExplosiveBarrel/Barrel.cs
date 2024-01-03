using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    [SerializeField] private float _explosiveRadius;
    [SerializeField] private float _explosiveForce;
    [SerializeField] private ParticleSystem _explosiveEffect;

    private void OnMouseUpAsButton()
    {
        Explode();
        Instantiate(_explosiveEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void Explode()
    {
        foreach(Rigidbody explodableObject in GetExplodibleObjects())
        {
            explodableObject.AddExplosionForce(_explosiveForce, transform.position, _explosiveRadius);
        }
    }

    private List<Rigidbody> GetExplodibleObjects()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosiveRadius);

        List<Rigidbody> barrels = new();

        foreach(Collider hit in hits)
        {
            if(hit.attachedRigidbody != null)
            {
                barrels.Add(hit.attachedRigidbody);
            }
        }

        return barrels;
    }
}
