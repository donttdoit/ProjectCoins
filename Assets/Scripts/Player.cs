using System;
using UnityEngine;
using Zenject;

public class Player : MonoBehaviour, IMover
{
    [SerializeField] private PlayerConfig _playerConfig;

    public event Action MouseOverMover;
    public event Action MouseExitMover;

    private IMovementHandler _movementHandler;
    private InputHandler _inputHandler;
    private Rigidbody2D _rigidBody;
    private Collider2D _collider;

    public Transform Transform => transform;
    public float Speed => _playerConfig.Speed;
    public Rigidbody2D RigidBody => _rigidBody;
    public Collider2D Collider => _collider;

    [Inject]
    private void Construct(InputHandler inputHandler) => _inputHandler = inputHandler;

    private void Awake()
    {
        //_movementHandler = new MouseMovePattern(_inputHandler, this);
        //_movementHandler = new KeyboardMovePattern(_inputHandler, this);
        _movementHandler = new MouseKeyboardMovePattern(_inputHandler, this);
        _rigidBody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
    }


    private void FixedUpdate()
    {
        _movementHandler.UpdateMove();
    }

    private void OnMouseOver() => MouseOverMover?.Invoke();

    private void OnMouseExit() => MouseExitMover?.Invoke();

}
