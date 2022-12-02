using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenusController : MonoBehaviour
{
    private const string SCENE_PATH = "Assets/Scenes/";
    private const string SCENE_EXTENTION = ".unity";
    
    [SerializeField] private bool onMainMenu;
    private Controller controller;
    private LoadSystem loadSystem;
    [SerializeField] private string GameScene;
    private bool gameOnPause;
    private CameraController cameraController;

    private void Awake()
    {
        
        if(!onMainMenu)
        {
            controller = GetComponent<Controller>();
            cameraController = FindObjectOfType<CameraController>();
        }else
            loadSystem = new LoadSystem();
    }
    
    private void Start()
    {
        if(!onMainMenu)
            cameraController.setUpLimits(controller.XPadding, controller.YPadding,
                controller.mapSize.x, controller.mapSize.y);
    }

    private void Update()
    {
        if(!onMainMenu)
        {
            if(Input.GetButtonDown("Cancel"))
                PauseToogle();

            cameraController.CameraMoveHorizontal(Input.GetAxis("Horizontal"));
            cameraController.CameraMoveVertically(Input.GetAxis("Vertical"));

            if(Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                cameraController.ZoomOut();
            }else if(Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                cameraController.ZoomIn();
            }

            if(Input.GetMouseButton(1))
            {
                cameraController.CameraMoveHorizontal(-Input.GetAxis("Mouse X"));
                cameraController.CameraMoveVertically(-Input.GetAxis("Mouse Y"));
            }
        }
    }

    private void PauseToogle()
    {
        
        if(gameOnPause)
        {
            //call view to stop pause
            gameOnPause = false;
        }else
        {
            //call view to pause
            gameOnPause = true;
        }
        
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
