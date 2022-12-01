using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSelector : MonoBehaviour
{
    public int Rows { get;set;}
    public int Cols { get; set;}

    public Controller controller { get; set;}

    public void TileSelect() 
    {
        controller.SelectTileAt(Rows, Cols);
    }
}
