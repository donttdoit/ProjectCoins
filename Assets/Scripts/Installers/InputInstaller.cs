using UnityEngine;
using Zenject;

public class InputInstaller : MonoInstaller
{
    [SerializeField] private InputHandler _inputHandler;
    public override void InstallBindings()
    {
        BindGameInput();
    }
    private void BindGameInput()
    {
        Container.BindInstance(_inputHandler);
    }
}
