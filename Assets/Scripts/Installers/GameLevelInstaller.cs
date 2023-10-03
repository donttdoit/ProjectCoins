using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameLevelInstaller : MonoInstaller
{
    [SerializeField] private CinemachineVirtualCameraBase _CinemachineCamera;
    [SerializeField] private Player _playerPrefab;
    [SerializeField] private Transform _playerSpawnPositon;
    [SerializeField] private PlayerConfig _playerConfig;

    public override void InstallBindings()
    {
        //BindConfigs();
        BinsInstances();
        BindCoinSpawner(); 
    }

    private void BindConfigs()
    {
        Container.BindInstance(_playerConfig);
    }

    private void BinsInstances()
    {
        Player player = Container.InstantiatePrefabForComponent<Player>(_playerPrefab, _playerSpawnPositon.position, Quaternion.identity, null);
        Container.BindInstance(player);
        _CinemachineCamera.Follow = player.transform;
    }

    private void BindCoinSpawner()
    {
        Container.Bind<CoinFactory>().AsSingle();
    }
}
