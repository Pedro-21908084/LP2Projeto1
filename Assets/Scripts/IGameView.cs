using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public interface IGameView
{
    //Methods
    public void ShowMap(Tile[][] map, GameData gameData);
    public void ShowTileResources(Tile tile, GameData gameData, GameObject gameObject, List<GameObject> resourceList);
    public void ShowButtons();
    public void HideButtons();
    public void ShowTileInfo(Tile tile, GameData gameData);
    public void HideTileInfo();
    public void ShowMapLegend();
    public void HideMapLegend();
    public void ShowPauseMenu();
    public void HidePauseMenu();
    public void ShowUIMessage(string message);
    public void HideUIMessage();
    

}
