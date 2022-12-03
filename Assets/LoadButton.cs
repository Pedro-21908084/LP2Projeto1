using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadButton : MonoBehaviour
{
    private int index;

    private MenusController menusController;

    [SerializeField]
    private TextMeshProUGUI mapName;

    /// <summary>
    /// Setups Load Button variables
    /// </summary>
    /// <param name="index"></param>
    /// <param name="menusController"></param>
    /// <param name="mapName"></param>
    public void SetupLoadButton( int index, MenusController menusController, string mapName) 
    {
        this.index = index;
        this.menusController = menusController;
        this.mapName.text = mapName;
    }

    /// <summary>
    /// Selects respective menusController map at a certain index
    /// </summary>
    public void SelectMap() 
    {
        menusController.SelectMap(index);
    }

    
}
