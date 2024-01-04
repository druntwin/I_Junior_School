using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementWithMouse : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);
    private const string MouseX = "Mouse X";
    private const string MouseY = "Mouse Y";

    [SerializeField] private Transform _camera;
    [SerializeField] private Transform _body;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;

    private void Update()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        Vector3 direction = new Vector3(Input.GetAxis(Horizontal), 0, Input.GetAxis(Vertical));

        transform.Translate(direction * _moveSpeed * Time.deltaTime);
    }

    private void Rotate()
    {
        _camera.Rotate( -Input.GetAxis(MouseY) * Vector3.right * _rotateSpeed * Time.deltaTime );
        _body.Rotate(Input.GetAxis(MouseX) * Vector3.up * _rotateSpeed * Time.deltaTime);
    }
}
