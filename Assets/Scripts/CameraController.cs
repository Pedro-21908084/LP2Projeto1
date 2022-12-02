using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform topLefMapPoint;
    [field:SerializeField]
    public float maxZoomIn { get; set; }

    [field: SerializeField]
    public float maxZoomOut { get; set; }
    [SerializeField]
    private float moveVelocity;
    [SerializeField]
    private float zooomVelocity;

    [SerializeField]
    private CharacterController characterController;
    public float ZoomModifier{get => Camera.main.orthographicSize/maxZoomIn;}

    private Vector3 ButtomRight;

    public void setUpLimits(float xTileSize, float yTileSize, float xTileNumver, float yTileNumber)
    {
        ButtomRight = new Vector3(topLefMapPoint.position.x + xTileSize * xTileNumver, 
            topLefMapPoint.position.y - yTileSize * yTileNumber, topLefMapPoint.position.y);
    }

    public void ZoomIn()
    {
        if (Camera.main.orthographicSize > maxZoomIn) 
        {
            Camera.main.orthographicSize = maxZoomIn;
        }
        else if (Camera.main.orthographicSize < maxZoomIn)
        {
            Camera.main.orthographicSize+= zooomVelocity;
        }

    }

    public void ZoomOut()
    {
        
        if (Camera.main.orthographicSize < maxZoomOut)
        {
            Camera.main.orthographicSize = maxZoomOut;
        }
        else if (Camera.main.orthographicSize > maxZoomOut)
        {
            Camera.main.orthographicSize-= zooomVelocity;
        }
    }

    public void CameraMoveHorizontal(float force) 
    {
        characterController.Move(new Vector3( moveVelocity * force * ZoomModifier, 0, 0));
        if(transform.position.x > ButtomRight.x)
        {
            characterController.enabled = false;
            transform.position = new Vector3(ButtomRight.x, transform.position.y,
                transform.position.z);
            characterController.enabled = true;
        }else if(transform.position.x < topLefMapPoint.position.x)
        {
            characterController.enabled = false;
            transform.position = new Vector3(topLefMapPoint.position.x, 
                transform.position.y, transform.position.z);
            characterController.enabled = true;
        }
    }
    public void CameraMoveVertically(float force) 
    {
        characterController.Move(new Vector3( 0, moveVelocity * force * ZoomModifier, 0));

        if(transform.position.y < ButtomRight.y)
        {
            characterController.enabled = false;
            transform.position = new Vector3(transform.position.x, ButtomRight.y,
                transform.position.z);
            characterController.enabled = true;
        }else if(transform.position.y > topLefMapPoint.position.y)
        {
            characterController.enabled = false;
            transform.position = new Vector3(transform.position.x, 
                topLefMapPoint.position.y, transform.position.z);
            characterController.enabled = true;
        }
    }
}
