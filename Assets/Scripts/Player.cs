using System;
using UnityEngine;
using Zenject;

public class Player : MonoBehaviour, IMover, IDisposable, IPause
{
    [SerializeField] private PlayerConfig _playerConfig;

    public event Action MouseOverMover;
    public event Action MouseExitMover;
    private const float SpeedUpMultiplier = 2f;

    private IMovementHandler _movementHandler;
    private Settings _settingsPanel;
    private LevelLoadingData _levelData;
    private InputHandler _inputHandler;
    private Rigidbody2D _rigidBody;
    private Collider2D _collider;
    private PauseHandler _pauseHandler;
    private bool _isPaused;

    public Transform Transform => transform;
    public float Speed => _playerConfig.Speed;
    public Rigidbody2D RigidBody => _rigidBody;
    public Collider2D Collider => _collider;

    [Inject]
    private void Construct(InputHandler inputHandler, LevelLoadingData levelData, PauseHandler pauseHandler, Settings settingsPanel)
    {
        _inputHandler = inputHandler;
        _levelData = levelData;

        _pauseHandler = pauseHandler;
        _inputHandler.ShiftPressed += OnSpeedUp;
        _inputHandler.CancelShiftPressed += OnSpeedDown;
        _pauseHandler.Add(this);

        _settingsPanel = settingsPanel;
        _settingsPanel.SettingsChanged += OnUpdateSettings;
    }

    private void OnUpdateSettings()
    {
        MovementInitialize();
    }

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
        MovementInitialize();
    }

    private void FixedUpdate()
    {
        if (_isPaused == false)
            _movementHandler.UpdateMove();
    }

    private void OnMouseOver() => MouseOverMover?.Invoke();

    private void OnMouseExit() => MouseExitMover?.Invoke();

    public void Dispose()
    {
        _inputHandler.ShiftPressed -= OnSpeedUp;
        _inputHandler.CancelShiftPressed -= OnSpeedDown;
        _settingsPanel.SettingsChanged -= OnUpdateSettings;
    }

    public void SetPause(bool isPaused) => _isPaused = isPaused;

    private void MovementInitialize()
    {
        switch (_levelData.Movement)
        {
            case Movement.KeyboardMovement:
                _movementHandler = new KeyboardMovePattern(_inputHandler, this);
                break;

            case Movement.MouseMovement:
                _movementHandler = new MouseMovePattern(_inputHandler, this);
                break;

            default:
            case Movement.MouseKeyboardMovement:
                _movementHandler = new MouseKeyboardMovePattern(_inputHandler, this);
                break;
        }
    }

    private void OnSpeedUp() => _playerConfig.Speed *= SpeedUpMultiplier;
    private void OnSpeedDown() => _playerConfig.Speed /= SpeedUpMultiplier;
}
