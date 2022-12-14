using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameDisplay : MonoBehaviour, IGameView
{
    //References
    private Controller controller;
    private GameData gameData;
    private MenusController menusController;

    //Menu GameObjects
    [SerializeField]
    private GameObject TileInfoPanel;
    [SerializeField]
    private GameObject MapLegend;
    [SerializeField]
    private GameObject PauseMenu;
    [SerializeField]
    private GameObject FutureMenu;
    [SerializeField]
    private GameObject LoadMenu;
    [SerializeField]
    private GameObject UiMessage;

    //Tile Info Slots
    [SerializeField]
    private TextMeshProUGUI TerrTypeTxt;
    [SerializeField]
    private TextMeshProUGUI ResourcesTxt;
    [SerializeField]
    private TextMeshProUGUI TotalCoinTxt;
    [SerializeField]
    private TextMeshProUGUI TotalFoodTxt;
    [SerializeField]
    private TextMeshProUGUI uiMessageText;
    [SerializeField]
    private Image terrainIcon;

    //For The Future Text
    [SerializeField]
    private TextMeshProUGUI forTheFutureText;

    //Buttons
    [SerializeField]
    private List<Button> gameButtons;
    
    //Map Instantiation
    [SerializeField]
    private Transform instStart;
    [field:SerializeField]
    public float XPadding { get; set; }
    [field: SerializeField]
    public float YPadding { get; set; }
    [SerializeField]
    private GameObject resourcePrefab;
    [SerializeField]
    private GameObject terrainPrefab;
    private GameObject[][] terrainsStored;
    private List<GameObject>[][] terrResourcesStored;

    //Resource Icon Instatiation
    [SerializeField]
    private float detectionRadius;

    

    public void SetupDisplay(Controller controller, float xPadding, float yPadding, GameData gameData, MenusController menusController)
    {
        this.controller = controller;
        this.gameData = gameData;
        this.menusController = menusController;
        XPadding = xPadding;
        YPadding = yPadding;
        HideButtons();
        HideFutureMenu();
        HideLoadMenu();
        HideMapLegend();
        HideTileInfo();
        HidePauseMenu();
        HideUIMessage();
    }

    /// <summary>
    /// Activates all buttons in a button List
    /// </summary>
    public void ShowButtons()
    {
        foreach (Button button in gameButtons)
        {
            button.gameObject.SetActive(true);
        }
        HideTileInfo();
        HideUIMessage();
        HideMapLegend();
        HideFutureMenu();
        HideLoadMenu();
        HideTileInfo();
        HidePauseMenu();
    }
    /// <summary>
    /// Deactivates all butons in a button List
    /// </summary>
    public void HideButtons() 
    {
        foreach (Button button in gameButtons)
        {
            button.gameObject.SetActive(false);

        }
    }

    /// <summary>
    /// Instantiates a map of Tiles
    /// </summary>
    /// <param name="map">Bidimensional array of Tiles</param>
    public void ShowMap(Tile[][] map)
    {
        terrainsStored = new GameObject[map.Length][];
        terrResourcesStored = new List<GameObject>[map.Length][];
        for (int i = 0; i < map.Length; i++)
        {
            terrainsStored[i] = new GameObject[map[i].Length];
            terrResourcesStored[i] = new List<GameObject>[map[i].Length];
            for (int j = 0; j < map[i].Length; j++)
            {
                terrainPrefab.GetComponent<Image>().sprite = gameData.GetTerrain(map[i][j].Terrain.Type).sprite;
                terrainsStored[i][j] = Instantiate(terrainPrefab,instStart);
                terrainsStored[i][j].GetComponent<RectTransform>().anchoredPosition = new Vector2(XPadding * j, -YPadding * i);
                TileController tileController = terrainsStored[i][j].GetComponent<TileController>();
                tileController.controller = menusController;
                tileController.Rows = i;
                tileController.Cols = j;
                ShowTileResources(map[i][j],terrainsStored[i][j], terrResourcesStored[i][j]);
            }
        }
    }

    /// <summary>
    /// Displays Map Legend Game Object
    /// </summary>
    public void ShowMapLegend()
    {
        MapLegend.SetActive(true);
        HideTileInfo();
        HideUIMessage();
        HideButtons();
        HideFutureMenu();
        HideLoadMenu();
        HideTileInfo();
        HidePauseMenu();
    }

    /// <summary>
    /// Hides Map Legend Game Object
    /// </summary>
    public void HideMapLegend()
    {
        MapLegend.SetActive(false);
    }

    /// <summary>
    /// Displays Pause Menu GameObject
    /// </summary>
    public void ShowPauseMenu()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0;
        HideButtons();
        HideMapLegend();
        HideTileInfo();
        HideFutureMenu();
        HideLoadMenu();
        HideUIMessage();
        HideUIMessage();
    }

    /// <summary>
    /// Hides Pause Menu GameObject
    /// </summary>
    public void HidePauseMenu()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    /// <summary>
    /// Displays Tile Info GameObject and all Tile information in each respective text and image slot
    /// </summary>
    public void ShowTileInfo(Tile tile)
    {
        TileInfoPanel.SetActive(true);
        terrainIcon.sprite = gameData.GetTerrain(tile.Terrain.Type).sprite;
        TerrTypeTxt.text = tile.Terrain.Type;
        ResourcesTxt.text = "";
        foreach (Resource resource in tile.Resources)
        {
            ResourcesTxt.text += string.Format($"{resource.Type}\n");
        }
        TotalCoinTxt.text = tile.Coin.ToString();
        TotalFoodTxt.text = tile.Food.ToString();
        HideButtons();
        HideMapLegend();
        HidePauseMenu();
        HideUIMessage();
        HideLoadMenu();
        HidePauseMenu();
        HideFutureMenu();
    }

    /// <summary>
    /// Hides Tile Info GameObject
    /// </summary>
    public void HideTileInfo()
    {
        TileInfoPanel.SetActive(false);
    }

    /// <summary>
    /// Instantiates each resource prefab of a Tile in a randomly chosen position on top of the terrain
    /// </summary>
    /// <param name="tile">The Tile</param>
    /// <param name="terrainPrefab">The terrain prefab</param>
    /// <param name="resourceList">The Tile's resource List</param>
    public void ShowTileResources(Tile tile, GameObject terrainPrefab, List<GameObject> resourceList)
    {
        resourceList = new List<GameObject>();
        foreach (Resource resource in tile.Resources)
        {
            resourcePrefab.GetComponent<Image>().sprite = gameData.GetResource(resource.Type).sprite;
            Vector2 resourceIconPos;
            do
            {
                resourceIconPos = terrainPrefab.GetComponent<TileController>().GetIconInstArea();
            } while (Physics2D.OverlapCircle(resourceIconPos, detectionRadius) != null);
            
            resourceList.Add(Instantiate(resourcePrefab, resourceIconPos, new Quaternion(), terrainPrefab.transform));
        }
    }

    /// <summary>
    /// Displays UI Message GameObject
    /// </summary>
    /// <param name="message"></param>
    public void ShowUIMessage(string message)
    {
        UiMessage.SetActive(true);
        uiMessageText.text = message;
        HideButtons();
        HideFutureMenu();
        HideLoadMenu();
        HideMapLegend();
        HidePauseMenu();
        HideTileInfo();
    }

    /// <summary>
    /// Hides UI Message GameObject
    /// </summary>
    public void HideUIMessage()
    {
        UiMessage.SetActive(false);
    }

    /// <summary>
    /// Displays Future Menu GameObject
    /// </summary>
    public void ShowFutureMenu(string text)
    {
        FutureMenu.SetActive(true);
        forTheFutureText.text = text;
        HideButtons();
        HideLoadMenu();
        HideMapLegend();
        HidePauseMenu();
        HideTileInfo();
        HideUIMessage();
    }

    /// <summary>
    /// Hides Future Menu GameObject
    /// </summary>
    public void HideFutureMenu()
    {
        FutureMenu.SetActive(false);
    }

    /// <summary>
    /// Displays Load Menu GameObject
    /// </summary>
    public void ShowLoadMenu()
    {
        LoadMenu.SetActive(true);
        HideButtons();
        HideFutureMenu();
        HideMapLegend();
        HidePauseMenu();
        HideTileInfo();
        HideUIMessage();
    }

    /// <summary>
    /// Hides Load Menu GameObject
    /// </summary>
    public void HideLoadMenu()
    {
        LoadMenu.SetActive(false);
    }

    
}
