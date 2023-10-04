using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameLevelInstaller : MonoInstaller
{
    [SerializeField] private CinemachineVirtualCameraBase _CinemachineCamera;
    [SerializeField] private CoordinateViewer _coordinateViewer;
    [SerializeField] private Player _playerPrefab;
    [SerializeField] private Transform _playerSpawnPositon;

    public override void InstallBindings()
    {
        BinsInstances();
        BindCoinFactory(); 
    }

    private void BinsInstances()
    {
        Player player = Container.InstantiatePrefabForComponent<Player>(_playerPrefab, _playerSpawnPositon.position, Quaternion.identity, null);
        Container.BindInstance(player);
        _CinemachineCamera.Follow = player.transform;
        _coordinateViewer.SetSourceTransform(player.transform);
    }

    private void BindCoinFactory()
    {
        Container.Bind<CoinFactory>().AsSingle();
    }
}
