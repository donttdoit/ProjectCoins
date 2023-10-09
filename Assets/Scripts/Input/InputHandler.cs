using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class InputHandler : IInitializable, IDisposable
{
    public event Action Interacted;
    public event Action CancelInteracted;
    public event Action EscPressed;
    private PlayerInput _input;

    public void Initialize()
    {
        _input = new PlayerInput();
        _input.Enable();
        _input.PlayerHandler.Interact.performed += Interact;
        _input.PlayerHandler.Interact.canceled += CancelInteract;
        _input.PlayerHandler.Pause.performed += EscPress;
    }

    public void Dispose()
    {
        _input.Disable();
        _input.PlayerHandler.Interact.performed -= Interact;
        _input.PlayerHandler.Interact.canceled -= CancelInteract;
        _input.PlayerHandler.Pause.performed += EscPress;
    }

    public Vector2 GetMovementVectorNormalized() => _input.PlayerHandler.Movement.ReadValue<Vector2>().normalized;

    public Vector2 GetMousePosition() => Mouse.current.position.ReadValue();
    public Vector2 GetWorldMousePosition() => Camera.main.ScreenToWorldPoint(GetMousePosition());

    public bool IsMouseLeftButtonPressed() => Mouse.current.leftButton.isPressed;

    private void Interact(InputAction.CallbackContext context)
        => Interacted?.Invoke();

    private void CancelInteract(InputAction.CallbackContext context)
        => CancelInteracted?.Invoke();
    private void EscPress(InputAction.CallbackContext context) 
        => EscPressed?.Invoke();

}
