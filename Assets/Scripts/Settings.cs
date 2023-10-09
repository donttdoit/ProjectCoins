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

    private LevelLoadingData _levelData;

    [Inject]
    private void Construct(LevelLoadingData levelData) => _levelData = levelData;

    private void OnEnable() 
    { 
        _movementControl.onValueChanged.AddListener(OnMovementControlChanged);
        _backButton.onClick.AddListener(OnCloseClicked);
    }

    private void OnDisable()
    {
        _movementControl.onValueChanged.RemoveListener(OnMovementControlChanged);
        _backButton.onClick.RemoveListener(OnCloseClicked);
    }

    private void Awake()
    {
        InitializeMovementControlOption();
    }


    private void InitializeMovementControlOption()
    {
        _movementControl.ClearOptions();
        List<string> movementOptions = new List<string>(Enum.GetNames(typeof(Movement)));
        _movementControl.AddOptions(movementOptions);
    }

    private void OnCloseClicked()
    {
        gameObject.SetActive(false);
    }

    private void OnMovementControlChanged(int idSelectedItem) => _levelData.Movement = (Movement)idSelectedItem;

}
