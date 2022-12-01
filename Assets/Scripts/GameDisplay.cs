using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameDisplay : MonoBehaviour, IGameView
{
    [SerializeField]
    private GameObject TileInfoPanel;
    [SerializeField]
    private GameObject MapLegend;
    [SerializeField]
    private GameObject PauseMenu;
    [SerializeField]
    private GameObject BackgroundImage;
    [SerializeField]
    private TextMeshProUGUI TerrTypeTxt;
    [SerializeField]
    private TextMeshProUGUI ResourcesTxt;
    [SerializeField]
    private TextMeshProUGUI TotalCoinTxt;
    [SerializeField]
    private TextMeshProUGUI TotalFoodTxt;
    [SerializeField]
    private List<Button> gameButtons;
    [SerializeField]
    private GameObject UiMessage;

    [SerializeField]
    private Transform instStart;

    [SerializeField]
    private GameObject resourcePrefab;

    [SerializeField]
    private GameObject terrainPrefab;

    [field:SerializeField]
    public float XPadding { get; set; }
    [field: SerializeField]
    public float YPadding { get; set; }

    private GameObject[][] terrainsStored;

    private List<GameObject>[][] terrResourcesStored;



    public void ShowButtons()
    {
        foreach (Button button in gameButtons)
        {
            button.gameObject.SetActive(true);
        }
    }

    public void HideButtons() 
    {
        foreach (Button button in gameButtons)
        {
            button.gameObject.SetActive(false);

        }
    }

    public void ShowMap(Tile[][] map, GameData gameData)
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
                terrainsStored[i][j] = Instantiate(terrainPrefab, new Vector2(XPadding * j, YPadding * i), new Quaternion(), instStart);
                ShowTileResources(map[i][j], gameData,terrainsStored[i][j], terrResourcesStored[i][j]);
            }
        }
    }

    public void ShowMapLegend()
    {
        MapLegend.SetActive(true);
        HideTileInfo();
        HideUIMessage();
    }

    public void HideMapLegend()
    {
        MapLegend.SetActive(false);
    }

    public void ShowPauseMenu()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0;
        HideButtons();
        HideMapLegend();
        HideTileInfo();
        HideUIMessage();
    }
    public void HidePauseMenu()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 1;
    }

    public void ShowTileInfo(Tile tile, GameData gameData)
    {
        TileInfoPanel.SetActive(true);
        HideButtons();
        HideMapLegend();
        HidePauseMenu();
        HideUIMessage();
    }

    public void HideTileInfo()
    {
        TileInfoPanel.SetActive(false);
    }

    public void ShowTileResources(Tile tile, GameData gameData, GameObject gameObject, List<GameObject> resourceList)
    {
        resourceList = new List<GameObject>();
        foreach (Resource resource in tile.Resources)
        {
            resourcePrefab.GetComponent<Image>().sprite = gameData.GetResource(resource.Type).sprite;
            resourceList.Add(Instantiate(resourcePrefab, gameObject.GetComponent<TileController>().GetIconInstArea(), new Quaternion()));
        }
    }

    public void ShowUIMessage(string message)
    {
        UiMessage.SetActive(true);
    }
    public void HideUIMessage()
    {
        UiMessage.SetActive(false);
    }

    


}
