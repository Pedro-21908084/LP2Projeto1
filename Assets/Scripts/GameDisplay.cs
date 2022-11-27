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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

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

    public void ShowMap(Tile[,] map)
    {
        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                //Show respective tiles
            }
        }
    }

    public void ShowMapLegend()
    {
        MapLegend.SetActive(true);
    }

    public void HideMapLegend()
    {
        MapLegend.SetActive(false);
    }

    public void ShowPauseMenu()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void HidePauseMenu()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 1;
    }

    public void ShowTileInfo()
    {
        TileInfoPanel.SetActive(true);
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








}
