using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSelector : MonoBehaviour
{
    [SerializeField]
    private Controller controller;

    public void TileSelect(int rows, int cols) 
    {
        controller.SelectTileAt(rows, cols);
    }
}
