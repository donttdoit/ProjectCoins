using System;
using UnityEngine;
using Zenject;

public class GlobalInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindResources();
    }

    private void BindResources()
    {   
        Container.BindInstance(new Wallet());
    }
}
