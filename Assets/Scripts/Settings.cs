using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class Settings : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown _movementControl;
    [SerializeField] private Button _backButton;
    [SerializeField] private Button _mainMenuButton;

    public event Action SettingsChanged;

    private PauseHandler _pauseHandler;
    private InputHandler _inputHandler;
    private SceneLoader _sceneLoader;
    private LevelLoadingData _levelData;

    [Inject]
    private void Construct(LevelLoadingData levelData, PauseHandler pauseHandler, InputHandler inputHandler, SceneLoader sceneLoader)
    {
        _levelData = levelData;
        _pauseHandler = pauseHandler;
        _inputHandler = inputHandler;
        _sceneLoader = sceneLoader;
    }

    private void OnEnable() 
    { 
        _movementControl.onValueChanged.AddListener(OnMovementControlChanged);
        _backButton.onClick.AddListener(OnCloseClicked);
        _mainMenuButton.onClick.AddListener(OnMainMenuClicked);
        _inputHandler.EscPressed += OnPauseCancel;
    }

    private void OnDisable()
    {
        _movementControl.onValueChanged.RemoveListener(OnMovementControlChanged);
        _backButton.onClick.RemoveListener(OnCloseClicked);
        _mainMenuButton.onClick.RemoveListener(OnMainMenuClicked);
        _inputHandler.EscPressed -= OnPauseCancel;
    }

    private void Awake()
    {
        InitializeMovementControlOption();
    }

    public void Show(bool isShowed) => gameObject.SetActive(isShowed);

    private void InitializeMovementControlOption()
    {
        _movementControl.ClearOptions();
        List<string> movementOptions = new List<string>(Enum.GetNames(typeof(Movement)));
        _movementControl.AddOptions(movementOptions);
    }

    private void OnCloseClicked()
    {
        OnPauseCancel();
    }

    private void OnMainMenuClicked()
    {
        _sceneLoader.Load(SceneID.MainMenuScene);
    }

    private void OnMovementControlChanged(int idSelectedItem)
    {
        _levelData.Movement = (Movement)idSelectedItem;
        SettingsChanged?.Invoke();
    }

    private void OnPauseCancel()
    {
        _pauseHandler.SetPause(false);
        gameObject.SetActive(false);
    }
}
