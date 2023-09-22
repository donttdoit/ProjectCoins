using Zenject;

public class CoinSpawnerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<CoinFactory>().AsSingle();
    }
}
