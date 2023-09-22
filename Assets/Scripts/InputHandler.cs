using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    public event Action Interacted;
    public event Action CancelInteracted;
    private PlayerInput _input;

    private void Awake()
    {
        _input = new PlayerInput();
    }

    private void OnEnable()
    {
        _input.Enable();
        _input.PlayerHandler.Interact.performed += Interact;
        _input.PlayerHandler.Interact.canceled += CancelInteract;
    }
    
    private void OnDisable()
    {
        _input.Disable();
        _input.PlayerHandler.Interact.performed -= Interact;
        _input.PlayerHandler.Interact.canceled -= CancelInteract;
    }

    public Vector2 GetMovementVectorNormalized() => _input.PlayerHandler.Movement.ReadValue<Vector2>().normalized;

    public Vector2 GetMousePosition() => Mouse.current.position.ReadValue();
    public Vector2 GetWorldMousePosition() => Camera.main.ScreenToWorldPoint(GetMousePosition());

    public bool IsMouseLeftButtonPressed() => Mouse.current.leftButton.isPressed;

    private void Interact(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        Interacted?.Invoke();
    }

    private void CancelInteract(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        CancelInteracted?.Invoke();
    }



}
