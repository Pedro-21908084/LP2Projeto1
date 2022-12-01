using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    public int Rows { get;set;}
    public int Cols { get; set;}

    [field: SerializeField]
    public Transform AreaObject1 { get; set; }

    [field: SerializeField]
    public Transform AreaObject2 { get; set; }


    public Controller controller { get; set;}

    public void TileSelect() 
    {
        controller.SelectTileAt(Rows, Cols);
    }

    public Vector2 GetIconInstArea() 
    {
        float xLeft = AreaObject1.position.x;
        float xRight = AreaObject2.position.x;
        float yTop = AreaObject1.position.y;
        float yBot = AreaObject2.position.y;

        float xValue = Random.Range(xLeft, xRight);
        float yValue = Random.Range(yTop, yBot);

        return new Vector2(xValue, yValue);

    }
}
