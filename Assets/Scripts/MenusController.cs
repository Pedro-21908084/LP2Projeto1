using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenusController : MonoBehaviour
{
    private const string SCENE_PATH = "Assets/Scenes/";
    private const string SCENE_EXTENTION = ".unity";
    
    private LoadSystem loadSystem;
    [SerializeField]
    private string GameScene;

    private void Awake()
    {
        loadSystem = new LoadSystem();
    }
    
    public void LoadScene(string sceneToLoad)
    {
        int index = SceneUtility.GetBuildIndexByScenePath(SCENE_PATH + sceneToLoad + SCENE_EXTENTION);

        if(index > 0)
            SceneManager.LoadScene(sceneToLoad);
    }

    public void OpenLoadMenu()
    {
        //view open load menu & hide gamemenu
    }

    public void SelectMap(int index)
    {
        if(index >= 0 && index < loadSystem.MapsFound.Count)
        {
            LoadSystem.SaveMapName(loadSystem.MapsFound[index]);
            LoadScene(GameScene);
        }
            
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
