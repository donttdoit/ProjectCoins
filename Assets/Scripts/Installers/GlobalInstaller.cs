using System;
using Zenject;

public class GlobalInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindInput();
        BindResources();
    }

    private void BindInput()
    {
        Container.BindInterfacesAndSelfTo<InputHandler>().AsSingle();
    }

    private void BindResources()
    {   
        Container.BindInstance(new Wallet());
    }
}
