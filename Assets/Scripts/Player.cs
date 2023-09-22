using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using Zenject;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    private InputHandler _inputHandler;

    private Rigidbody2D _rigidBody;

    //private NavMeshAgent _navMeshAgent;

    [Inject]
    private void Construct(InputHandler inputHandler) => _inputHandler = inputHandler;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        //_navMeshAgent = GetComponent<NavMeshAgent>();
        //_navMeshAgent.updateRotation = false;
        //_navMeshAgent.updateUpAxis = false;
    }

    private void FixedUpdate()
    {
        //if (_inputHandler.IsMouseLeftButtonPressed())
        //    MovementMouseHandler();
        MovementKeyboardHandler();
    }

    private void MovementKeyboardHandler()
    {
        Vector2 direction = _inputHandler.GetMovementVectorNormalized();
        //transform.Translate( * _speed * Time.deltaTime);
        //transform.position += new Vector3(direction.x, direction.y, 0) * _speed * Time.deltaTime;
        _rigidBody.MovePosition(_rigidBody.position + direction * _speed * Time.deltaTime);

        if (direction != Vector2.zero)
            transform.up = direction;
    }

    private void MovementMouseHandler()
    {
        Vector2 mousePosition = _inputHandler.GetMousePosition();
        Debug.Log(_inputHandler.GetMousePosition());
        //_navMeshAgent.SetDestination(new Vector3(mousePosition.x, mousePosition.y, 0));
    }
}
