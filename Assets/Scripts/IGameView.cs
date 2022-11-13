using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public interface IGameView 
{
    //Info Panel Text Refs
    public TextMeshProUGUI TerrTypeTxt { get; set; }
    public TextMeshProUGUI ResourcesTxt { get; set; }
    public TextMeshProUGUI TotalCoinTxt { get; set; }
    public TextMeshProUGUI TotalFoodTxt { get; set; }
    
    //Info Panel Icons
    public Sprite PlantIcon { get; set;}
    public Sprite AnimalsIcon { get; set; }
    public Sprite MetalsIcon { get; set; }
    public Sprite FossilFuelIcon { get; set; }
    public Sprite LuxuryIcon { get; set; }
    public Sprite PollutionIcon { get; set; }
    
    //Methods
    public void ShowMap();
    public void ShowTiles();
    public void ShowTileResources();
    public void ShowButtons();
    public void ShowTileInfo();

}
