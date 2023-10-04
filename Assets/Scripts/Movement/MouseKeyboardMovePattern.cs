using UnityEngine;

public class MouseKeyboardMovePattern : IMovementHandler
{
    private InputHandler _inputHandler;
    private MouseMovePattern _mouseMovement;
    private KeyboardMovePattern _keyboardMovement;

    public MouseKeyboardMovePattern(InputHandler inputHandler, IMover mover) 
    {
        _inputHandler = inputHandler;
        _mouseMovement = new MouseMovePattern(_inputHandler, mover);
        _keyboardMovement = new KeyboardMovePattern(_inputHandler, mover);
    }

    public void UpdateMove()
    {
        if (_inputHandler.IsMouseLeftButtonPressed())
            _mouseMovement.UpdateMove();    
        else
            _keyboardMovement.UpdateMove();
    }
}
