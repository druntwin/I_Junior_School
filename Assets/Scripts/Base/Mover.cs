using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField][Range(0f, 10f)] private float _moveSpeed = 2f;

    private void Update()
    {
        transform.position += transform.forward * _moveSpeed * Time.deltaTime;
    }
}
