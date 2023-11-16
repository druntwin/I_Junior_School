using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndScale : MonoBehaviour
{
    [SerializeField][Range(0f, 10f)] private float _moveSpeed = 5f;
    [SerializeField][Range(-100f, 100f)] private float _rotationY = 60f;
    [SerializeField][Range(0.1f, 1f)] private float _scaleSpeed = 0.1f;

    private void Update()
    {
        Vector3 currentScale = transform.localScale;

        transform.Rotate(0, _rotationY * Time.deltaTime, 0);
        gameObject.transform.position += transform.forward * _moveSpeed * Time.deltaTime;
        transform.localScale += currentScale * _scaleSpeed * Time.deltaTime;
    }
}
