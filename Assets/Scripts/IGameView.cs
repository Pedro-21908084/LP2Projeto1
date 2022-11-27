using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public interface IGameView 
{
    //GameObjects
    public GameObject TileInfoPanel { get; set;}
    public GameObject MapLegend { get; set;}
    public GameObject PauseMenu { get; set; }
    public GameObject BackgroundImage { get; set; }

    public GameObject UiMessage { get; set; }

    //Info Panel Texts
    public TextMeshProUGUI TerrTypeTxt { get; set; }
    public TextMeshProUGUI ResourcesTxt { get; set; }
    public TextMeshProUGUI TotalCoinTxt { get; set; }
    public TextMeshProUGUI TotalFoodTxt { get; set; }

    
    //Button List
    [SerializeField]
    List<Button> gameButtons { get; set; }

    //Methods
    public void ShowMap(Tile[,] map);
    public void ShowTileResources();
    public void ShowButtons();
    public void HideButtons();
    public void ShowTileInfo();
    public void HideTileInfo();
    public void ShowMapLegend();
    public void HideMapLegend();
    public void ShowPauseMenu();
    public void HidePauseMenu();
    public void ShowUIMessage();
    public void HideUIMessage();
    public KeyCode GetPlayerInput();

}
