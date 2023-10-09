using System;
using Zenject;

public class GlobalInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindInput();
        BindResources();
        BindSceneLoader();
    }

    private void BindSceneLoader()
    {
        Container.BindInstance(new LevelLoadingData(Movement.MouseKeyboardMovement)).AsSingle();
        Container.Bind<SceneLoader>().AsSingle();
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
