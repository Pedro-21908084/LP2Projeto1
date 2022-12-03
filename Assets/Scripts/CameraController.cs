using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [field:SerializeField]
    public float maxZoomIn { get; set; }

    [field: SerializeField]
    public float maxZoomOut { get; set; }

    /// <summary>
    /// Increases main camera´s ortographic size
    /// </summary>
    public void ZoomIn()
    {
        if (Camera.main.orthographicSize > maxZoomIn) 
        {
            Camera.main.orthographicSize = maxZoomIn;
        }
        else if (Camera.main.orthographicSize < maxZoomIn)
        {
            Camera.main.orthographicSize++;
        }

    }

    /// <summary>
    /// Increases main camera´s ortographic size
    /// </summary>
    public void ZoomOut()
    {
        
        if (Camera.main.orthographicSize < maxZoomOut)
        {
            Camera.main.orthographicSize = maxZoomOut;
        }
        else if (Camera.main.orthographicSize > maxZoomOut)
        {
            Camera.main.orthographicSize--;
        }
    }

    public void CameraMove() 
    {

    }
}
