using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SnakeMovement : MonoBehaviour
{
    [Header("Snake Speed")]
    [SerializeField, Range(1, 100)] private float _snakeSpeed;
    [SerializeField, Range(1, 100)] private float _snakeMovementSpeed;

    [Header("Snake Component")]
    [SerializeField] private Rigidbody _snakeRigibody;

    [Header("Hide Variable")]
    private Vector3 _moveForward = Vector3.forward;
    private Vector3 _delta = new Vector3(1, 0, 1);

    void Update()
    {
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + _moveForward.z);
        _snakeRigibody.MovePosition(newPosition);
        _moveForward = _snakeSpeed * Time.deltaTime * _moveForward.normalized;

        if (Input.GetKey(KeyCode.A))
        {
            _delta = _snakeMovementSpeed * Time.deltaTime * _delta.normalized;
            newPosition = new Vector3(transform.position.x - _delta.x, transform.position.y, transform.position.z + _moveForward.z);
            _snakeRigibody.MovePosition(newPosition);
        }

        if (Input.GetKey(KeyCode.D))
        {
            _delta = _snakeMovementSpeed * Time.deltaTime * _delta.normalized;
            newPosition = new Vector3(transform.position.x + _delta.x, transform.position.y, transform.position.z + _moveForward.z);
            _snakeRigibody.MovePosition(newPosition);
        }
    }
}
