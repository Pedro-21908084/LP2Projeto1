using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public interface IGameView 
{
    //Methods
    public void ShowMap(Tile[][] map, float xPadding, float yPadding);
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
    

}
