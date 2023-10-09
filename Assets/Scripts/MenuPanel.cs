using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MenuPanel : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _settingsButton;
    [SerializeField] private Button _exitButton;
    
    private Settings _settingsPanel;
    private SceneLoader _sceneLoader;

    [Inject]
    private void Construct(SceneLoader sceneLoader, Settings settinsPanel)
    {
        _sceneLoader = sceneLoader;
        _settingsPanel = settinsPanel;
    }

    private void OnEnable()
    {
        _playButton.onClick.AddListener(OnPlayClicked);
        _settingsButton.onClick.AddListener(OnSettingsClicked);
        _exitButton.onClick.AddListener(OnExitClicked);
    }

    private void OnDisable()
    {
        _playButton.onClick.RemoveListener(OnPlayClicked);
        _settingsButton.onClick.RemoveListener(OnSettingsClicked);
        _exitButton.onClick.RemoveListener(OnExitClicked);
    }

    private void OnExitClicked() => Application.Quit();

    private void OnSettingsClicked() => _settingsPanel.Show(true);

    private void OnPlayClicked() => _sceneLoader.Load(SceneID.GameplayScene);

    
}
