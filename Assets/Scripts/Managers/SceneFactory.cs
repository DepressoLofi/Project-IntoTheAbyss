using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class SceneController : MonoBehaviour
{
    public abstract void LoadScene();
}

public class MainMenuScene : SceneController
{
    public override void LoadScene()
    {

    }
}

public class LevelOneScene : SceneController
{
    public GameObject transistionPrefab;
    public override void LoadScene()
    {

    }
}

public class LevelOneSnowScene : SceneController
{
    public override void LoadScene()
    {

    }
}

public class SceneFactory
{
    public SceneController GetSceneController(string sceneType)
    {
        switch (sceneType)
        {
            case "MainMenuScene":
                return new MainMenuScene();
            case "LevelOneScene":
                return new LevelOneScene();
            case "LevelOneSnowScene":
                return new LevelOneSnowScene();
            default:
                Debug.Log("Unknown Scene, make sure you add the scene in Scene Factory");
                return null;
        }
    }
}

