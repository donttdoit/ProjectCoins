using System;
using UnityEngine;

public class MouseMovePattern : IMovementHandler, IDisposable
{
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
        if (_inputHandler.IsMouseLeftButtonPressed() && _IsMouseOverMover == false)
        {
            Vector2 mousePosition = _inputHandler.GetWorldMousePosition();
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
}
