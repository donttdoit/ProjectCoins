using System;
using UnityEngine;
using Zenject;

public class Bootstrap : MonoBehaviour
{
    private Settings _settingsPanel;
    private PauseHandler _pauseHandler;
    private InputHandler _inputHandler;

    [Inject]
    private void Construct(PauseHandler pauseHandler, InputHandler inputHandler, Settings settinsPanel)
    {
        _pauseHandler = pauseHandler;
        _settingsPanel = settinsPanel;

        _inputHandler = inputHandler;
        _inputHandler.EscPressed += OnPaused;
    }

    public void OnDisable()
    {
        _inputHandler.EscPressed -= OnPaused;
    }

    private void OnPaused()
    {
        _pauseHandler.SetPause(true);
        _settingsPanel.Show(true);
    }
}
