using UnityEngine.SceneManagement;
using Zenject;

public class SceneLoader
{
    private ZenjectSceneLoader _loader;

    public SceneLoader(ZenjectSceneLoader loader) => _loader = loader;

    public void Load(SceneID sceneID, LevelLoadingData data)
        => _loader.LoadScene((int)sceneID, LoadSceneMode.Single, container => container.BindInstance(data).WhenInjectedInto<GameLevelInstaller>());

    public void Load(SceneID sceneID)
        => _loader.LoadScene((int)sceneID, LoadSceneMode.Single);
}
