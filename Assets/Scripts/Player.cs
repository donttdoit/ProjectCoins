using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    private PlayerInput _input;
    private CharacterController _controller;

    private void Awake()
    {
        _input = new PlayerInput();
        _controller = GetComponent<CharacterController>();
    }

    private void OnEnable() => _input.Enable();

    private void OnDisable() => _input.Disable();

    private void Update()
    {
        MovementHandler();
    }

    private void MovementHandler()
    {
        Vector2 direction = _input.PlayerHandler.Movement.ReadValue<Vector2>();
        _controller.Move(direction * _speed * Time.deltaTime);
        if (direction != Vector2.zero)
            transform.up = direction;
    }
}
