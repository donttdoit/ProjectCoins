using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameLevelInstaller : MonoInstaller
{
    [SerializeField] private CinemachineVirtualCamera _cinemachineCamera;
    [SerializeField] private CoordinateViewer _coordinateViewer;
    [SerializeField] private Player _playerPrefab;
    [SerializeField] private Settings _settingsPrefab;
    [SerializeField] private Canvas _levelCanvas;
    [SerializeField] private Transform _playerSpawnPositon;

    public override void InstallBindings()
    {
        BindInstances();
        BindCoinFactory(); 
    }

    private void BindInstances()
    {
        Settings settingPanel = Container.InstantiatePrefabForComponent<Settings>(_settingsPrefab, _levelCanvas.transform);
        settingPanel.gameObject.SetActive(false);
        Container.BindInstance(settingPanel).AsTransient();

        Player player = Container.InstantiatePrefabForComponent<Player>(_playerPrefab, _playerSpawnPositon.position, Quaternion.identity, null);
        Container.BindInstance(player);
        _cinemachineCamera.Follow = player.transform;
        _coordinateViewer.SetSourceTransform(player.transform);
    }

    private void BindCoinFactory()
    {
        Container.Bind<CoinFactory>().AsSingle();
    }
}
