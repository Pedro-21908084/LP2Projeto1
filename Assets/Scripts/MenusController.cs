using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenusController : MonoBehaviour
{
    private LoadSystem loadSystem;
    [SerializeField]
    private string GameScene;

    private void Awake()
    {
        loadSystem = new LoadSystem();
    }
    
    public void LoadScene(string sceneToLoad)
    {
        Scene scene =  SceneManager.GetSceneByName(sceneToLoad);

        if(scene != null)
            SceneManager.LoadScene(scene.name);
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
