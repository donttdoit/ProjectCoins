using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MainMenuInstaller : MonoInstaller
{
    [SerializeField] private Settings _settingsPrefab;
    [SerializeField] private Canvas _levelCanvas;

    public override void InstallBindings()
    {
        BindInstances();
    }

    private void BindInstances()
    {
        Settings settingPanel = Container.InstantiatePrefabForComponent<Settings>(_settingsPrefab, _levelCanvas.transform);
        settingPanel.gameObject.SetActive(false);
        Container.BindInstance(settingPanel).AsTransient();
    }
}
