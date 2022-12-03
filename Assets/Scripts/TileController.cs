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


    public MenusController controller { get; set;}

    /// <summary>
    /// Selects a tile in a certain row and column
    /// </summary>
    public void TileSelect() 
    {
        controller.SelectTileAt(Rows, Cols);
    }

    /// <summary>
    /// Using AreaObject 1 and 2 estipulates limits and returns a random valued Vector2 within of those limits
    /// </summary>
    /// <returns></returns>
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
