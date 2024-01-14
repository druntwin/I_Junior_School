using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class MovementWithSound : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);
    private const string MouseX = "Mouse X";
    private const string MouseY = "Mouse Y";

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _stepDistance;
    [SerializeField] private FootStepsSounds _stepsSounds;
    [SerializeField] private Transform _camera;
    [SerializeField] private Transform _body;

    private float _coveredDistance = 0f;

    private void Update()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        float sideDirection = Input.GetAxis(Horizontal);
        float forwardDirection = Input.GetAxis(Vertical);
        Vector3 direction = new Vector3(sideDirection, 0, forwardDirection);

        if (sideDirection == 0f && forwardDirection == 0f)
        {
            _coveredDistance = 0f;
            return;
        }

        float distance = Mathf.Sqrt(Mathf.Pow(sideDirection, 2f) + Mathf.Pow(forwardDirection, 2f)) * _moveSpeed * Time.deltaTime;

        _coveredDistance += Mathf.Abs(distance);
        _body.transform.Translate(direction * _moveSpeed * Time.deltaTime);

        if (_coveredDistance >= _stepDistance)
        {
            _coveredDistance -= _stepDistance;
            _stepsSounds.Play();
        }
    }

    private void Rotate()
    {
        _camera.Rotate(-Input.GetAxis(MouseY) * Vector3.right * _rotationSpeed * Time.deltaTime);
        _body.Rotate(Input.GetAxis(MouseX) * Vector3.up * _rotationSpeed * Time.deltaTime);
    }
}
