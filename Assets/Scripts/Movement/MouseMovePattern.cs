using System;
using UnityEngine;

public class MouseMovePattern : IMovementHandler, IDisposable
{
    private const float MinDistanceToMove = 0.1f;
    private IMover _mover;
    private InputHandler _inputHandler;
    private bool _IsMouseOverMover;

    public MouseMovePattern(InputHandler inputHandler, IMover mover)
    {
        _inputHandler = inputHandler;
        _mover = mover;
        _mover.MouseOverMover += OnMouseOverMover;
        _mover.MouseExitMover += OnMouseExitMover;
    }

    public void Dispose() 
    { 
        _mover.MouseOverMover -= OnMouseOverMover;
        _mover.MouseExitMover -= OnMouseExitMover;
    }

    public void UpdateMove()
    {
        Debug.Log($"Forward: {_mover.Transform.up}");
        //Debug.Log($"Player Position: {_mover.Transform.position}");
        //Vector2 forwardBorderPoint = new Vector2(_mover.Transform.position.x + _mover.Transform.up.x * _mover.Collider.bounds.extents.x,
        //                                         _mover.Transform.position.y + _mover.Transform.up.y * _mover.Collider.bounds.extents.y);

        //Debug.Log($"BorderForwardPoint: {ConvertToWorldPosition(forwardBorderPoint)}");
        //Debug.Log($"BorderForwardPoint: {forwardBorderPoint}");
        //Debug.Log($"WorldMousePosition: {_inputHandler.GetWorldMousePosition()}");
        Vector2 mousePosition = _inputHandler.GetWorldMousePosition();
        //Debug.Log(_inputHandler.GetMousePosition());
        //Vector2 
        //Vector2 distanceBetweenCollider = new Vector2

        if (_inputHandler.IsMouseLeftButtonPressed() && _IsMouseOverMover == false)
        {
            
            Vector2 direction = (mousePosition - new Vector2(_mover.Transform.position.x, _mover.Transform.position.y)).normalized;
            _mover.RigidBody.velocity = direction * _mover.Speed;

            if (direction != Vector2.zero)
                _mover.Transform.up = direction;
        }
        else
            _mover.RigidBody.velocity = Vector2.zero;
    }

    private void OnMouseOverMover() => _IsMouseOverMover = true;
    private void OnMouseExitMover() => _IsMouseOverMover = false;

    private Vector2 ConvertToWorldPosition(Vector2 localPosition) => Camera.main.ScreenToWorldPoint(localPosition);
}