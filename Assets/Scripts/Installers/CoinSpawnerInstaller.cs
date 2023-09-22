using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CoinSpawnerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<CoinFactory>().AsSingle();
    }
}
