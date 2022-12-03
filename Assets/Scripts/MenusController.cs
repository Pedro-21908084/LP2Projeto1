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
    private bool inMenu;
    private bool inMapLeg;
    private bool inButton;
    private bool inFuture;
    private bool inTileInfo;
    private CameraController cameraController;
    [SerializeField] private Component viewComponent;
    [SerializeField] private DisplayLoadMapNames displayLoadMapNames;
    private IGameView view;

    private void Awake()
    {
        
        if(!onMainMenu)
        {
            controller = GetComponent<Controller>();
            cameraController = FindObjectOfType<CameraController>();
        }else
        {
            loadSystem = new LoadSystem();
            if(viewComponent is IGameView)
                view = viewComponent as IGameView;
        }
            
    }
    
    private void Start()
    {
        if(!onMainMenu)
        {
            cameraController.setUpLimits(controller.XPadding, controller.YPadding,
                controller.mapSize.x, controller.mapSize.y);

            view = controller.View;
            loadSystem = controller.LoadSystem;
        }
        inMenu = false;
        inButton = false;
        inFuture = false;
        inMapLeg = false;
        inTileInfo = false;
        displayLoadMapNames.SetMenusController(this);
    }

    private void Update()
    {
        if(!onMainMenu)
        {
            if(Input.GetButtonDown("Cancel"))
                PauseToogle();

            if(!gameOnPause)
            {
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

                if(Input.GetButtonDown("MapLegend") && !inMapLeg)
                    OpenMapLegen();
                else if(Input.GetButtonDown("MapLegend"))
                    CloseMapLegen();

                if(Input.GetButtonDown("FutereButtons") && !inButton)
                {
                    OpenButtons();
                    Debug.Log("buttons");
                }
                    
                else if(Input.GetButtonDown("FutereButtons"))
                    CloseButtons();
            }

            
        }
    }

    public void OpenMapLegen()
    {
        view.ShowMapLegend();
        inMenu = true;
        inMapLeg = true;
        inButton = false;
        inFuture = false;
        inTileInfo = false;
    }
    public void OpenFutureMenu()
    {
        view.ShowFutureMenu();
        inFuture = true;
        inMenu = true;
        inButton = false;
        inMapLeg=false;
        inTileInfo = false;
    }
    public void OpenButtons()
    {
        view.ShowButtons();
        inButton = true;
        inMenu = true;
        inMapLeg=false;
        inFuture = false;
        inTileInfo = false;
    }
    public void CloseMapLegen()
    {
        view.HideMapLegend();
        inMenu = false;
        inMapLeg=false;
    }
    public void CloseFutureMenu()
    {
        view.HideFutureMenu();
        inFuture = false;
        inMenu = false;
    }
    public void CloseButtons()
    {
        view.HideButtons();
        inButton = false;
        inMenu = false;
    }

    public void SelectTileAt(int rows, int cols)
    {
        if(controller.Map != null && !gameOnPause)
        {
            view.ShowTileInfo(controller.Map[rows][cols]);
            inTileInfo = true;
            inButton = false;
            inMenu = true;
            inMapLeg=false;
            inFuture = false;
        }
    }

    public void PauseToogle()
    {
        
        if(gameOnPause)
        {
            view.HidePauseMenu();
            gameOnPause = false;
        }else
        {
            
            if(!inMenu)
            {
                view.ShowPauseMenu();
                gameOnPause = true;
            }else
            {
                view.ShowMapLegend();
                view.HideMapLegend();
                inMenu = false;
                inButton = false;
                inMapLeg=false;
                inTileInfo = false;
                inFuture = false;
            }
            
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
        displayLoadMapNames.ResetButtonList();
        view.ShowLoadMenu();
        displayLoadMapNames.CreateButton(loadSystem.MapsName.ToArray());
    }

    public void ResetMapList()
    {
        
        displayLoadMapNames.ResetButtonList();
        loadSystem.SearchForMaps();
        displayLoadMapNames.CreateButton(loadSystem.MapsName.ToArray());
    }

    public void CloseLoadMenu()
    {
        displayLoadMapNames.ResetButtonList();
        view.HideLoadMenu();
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
