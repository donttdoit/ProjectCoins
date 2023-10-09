using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class InputHandler : IInitializable, IDisposable
{
    public event Action Interacted;
    public event Action CancelInteracted;
    public event Action EscPressed;
    public event Action ShiftPressed;
    public event Action CancelShiftPressed;
    private PlayerInput _input;

    public string InteractKey => _input.PlayerHandler.Interact.bindings[0].ToDisplayString();

    public void Initialize()
    {
        _input = new PlayerInput();
        _input.Enable();
        _input.PlayerHandler.Interact.performed += Interact;
        _input.PlayerHandler.Interact.canceled += CancelInteract;
        _input.PlayerHandler.Pause.started += EscPress;
        _input.PlayerHandler.SpeedUp.performed += ShiftPress;
        _input.PlayerHandler.SpeedUp.canceled += CancelShiftPress;
    }

    public void Dispose()
    {
        _input.Disable();
        _input.PlayerHandler.Interact.performed -= Interact;
        _input.PlayerHandler.Interact.canceled -= CancelInteract;
        _input.PlayerHandler.Pause.started -= EscPress;
        _input.PlayerHandler.SpeedUp.performed -= ShiftPress;
        _input.PlayerHandler.SpeedUp.canceled -= CancelShiftPress;
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
    private void ShiftPress(InputAction.CallbackContext context)
        => ShiftPressed?.Invoke();
    private void CancelShiftPress(InputAction.CallbackContext context)
        => CancelShiftPressed?.Invoke();
}
