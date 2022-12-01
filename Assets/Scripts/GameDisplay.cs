using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameDisplay : MonoBehaviour, IGameView
{
    public GameObject TileInfoPanel { get ; set ; }
    public GameObject MapLegend { get ; set ; }
    public GameObject PauseMenu { get ; set ; }
    public GameObject BackgroundImage { get; set ; }
    public TextMeshProUGUI TerrTypeTxt { get ; set ; }
    public TextMeshProUGUI ResourcesTxt { get ; set ; }
    public TextMeshProUGUI TotalCoinTxt { get ; set ; }
    public TextMeshProUGUI TotalFoodTxt { get ; set; }
    public List<Button> gameButtons { get ; set ; }
    public GameObject UiMessage { get; set; }

    public KeyCode GetPlayerInput()
    {
        if (Input.anyKeyDown) 
        {
            foreach (KeyCode kcode in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(kcode))
                {
                    return kcode;
                }
            }
        }
        return KeyCode.None;
    }

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

    public void ShowMap(Tile[][] map, float xPadding, float yPadding)
    {
        Vector2 screenCorner = Camera.main.ScreenToViewportPoint(new Vector2(0, Camera.main.pixelHeight));
        for (int i = 0; i < map.Length; i++)
        {
            for (int j = 0; j < map[i].Length; j++)
            {
                
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

    public void ShowTileInfo()
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

    public void ShowTileResources()
    {
        
    }

    public void ShowUIMessage()
    {
        UiMessage.SetActive(true);
    }
    public void HideUIMessage()
    {
        UiMessage.SetActive(false);
    }

    public void ZoomIn() 
    {
        Camera.main.orthographicSize++;
    }

    public void ZoomOut() 
    {
        Camera.main.orthographicSize--;
    }


}
