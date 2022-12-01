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

    public void SetupLoadButton( int index, MenusController menusController, string mapName) 
    {
        this.index = index;
        this.menusController = menusController;
        this.mapName.text = mapName;
    }

    public void SelectMap() 
    {
        menusController.SelectMap(index);
    }

    
}
