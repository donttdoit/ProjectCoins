using UnityEngine;

public class KeyboardMovePattern : IMovementHandler
{
    private IMover _mover;
    private InputHandler _inputHandler;
    public KeyboardMovePattern(InputHandler inputHandler, IMover mover) 
    {
        _inputHandler = inputHandler;
        _mover = mover;
    }


    public void UpdateMove()
    {
        Vector2 direction = _inputHandler.GetMovementVectorNormalized();
        _mover.RigidBody.velocity = direction * _mover.Speed;

        if (direction != Vector2.zero)
            _mover.Transform.up = direction;
    }
}
