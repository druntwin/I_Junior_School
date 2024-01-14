using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Surface : MonoBehaviour
{
    [SerializeField] private SurfaceType _type;

    public SurfaceType Type { get { return _type; } }
}
