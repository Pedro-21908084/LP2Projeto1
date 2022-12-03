using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public interface IGameView
{
    //Methods
    public void SetupDisplay(Controller controller, float xPadding, float yPadding, GameData gameData, MenusController menusController);
    public void ShowMap(Tile[][] map);
    public void ShowTileResources(Tile tile, GameObject terrainPrefab, List<GameObject> resourceList);
    public void ShowButtons();
    public void HideButtons();
    public void ShowTileInfo(Tile tile);
    public void HideTileInfo();
    public void ShowMapLegend();
    public void HideMapLegend();
    public void ShowPauseMenu();
    public void HidePauseMenu();
    public void ShowUIMessage(string message);
    public void HideUIMessage();
    public void ShowFutureMenu(string text);
    public void HideFutureMenu();
    public void ShowLoadMenu();
    public void HideLoadMenu();
    

}
