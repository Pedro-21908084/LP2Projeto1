using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;

public class TestView : MonoBehaviour
{
    //Info Panel Text Refs
    [SerializeField]private TextMeshProUGUI mapText;
    [SerializeField]private TextMeshProUGUI infoText;
    public Controller controller{get; set;}
    [SerializeField]private TMP_InputField cols;
    [SerializeField]private TMP_InputField rows;


    public void ShowMap(Tile[][] map)
    {
        if(map != null)
        {
            StringBuilder mapInfo = new StringBuilder();

            for(int i = 0; i < map.Length; i++)
            {
                for(int j = 0; j < map[i].Length; j++)
                {
                    mapInfo.Append( "|"+ map[i][j].Terrain.Type);
                }
                mapInfo.Append("|\n");
            }

            mapText.text = mapInfo.ToString();
        }
    }

    public void SelectTile()
    {
        int rowsInt, colsInt;

        if(int.TryParse(rows.text, out rowsInt) && int.TryParse(cols.text, out colsInt))
        {
            //controller.SelectTileAt(rowsInt, colsInt);
        }
    }

    public void ShowTileInfo(Tile tile)
    {
        StringBuilder tileInfo = new StringBuilder();

        tileInfo.Append(tile.Terrain.Type + "\n");
        if(tile.Resources != null)
        {
            foreach(Resource rec in tile.Resources)
            {
                tileInfo.Append(rec.Type + "\n");
            }
        }

        tileInfo.Append("Total food: " + tile.Food + "\n");
        tileInfo.Append("Total coin: " + tile.Coin);

        infoText.text = tileInfo.ToString();
    }
}
