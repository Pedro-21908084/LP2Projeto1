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

    private List<Resource>[][] terrResourcesStored;



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
        
        for (int i = 0; i < map.Length; i++)
        {
            for (int j = 0; j < map[i].Length; j++)
            {
                Instantiate(terrainPrefab, new Vector2(instStart.position.x + XPadding * j, instStart.position.y + YPadding * i), new Quaternion());
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

    public void ShowTileResources(Tile tile, GameData gameData, GameObject gameObject)
    {
        foreach (Resource resource in tile.Resources)
        {
            Instantiate(resourcePrefab, gameObject.GetComponent<TileController>().GetIconInstArea(), new Quaternion());
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
