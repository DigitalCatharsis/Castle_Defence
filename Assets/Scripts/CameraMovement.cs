using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private InputManager inputManager;
    private Camera cameraMain;

    private void Awake()
    {
        inputManager = InputManager.Instance;
        cameraMain = Camera.main;

    }
    private void OnEnable()
    {
        inputManager.OnStartTouch += Move;
    }

    private void OnDisable()
    {
        inputManager.OnEndTouch -= Move;
    }

    public void Move(Vector2 screenPosition, float time)
    {
        Vector3 screenCoordinates = new Vector3(screenPosition.x, screenPosition.y, cameraMain.nearClipPlane);  //z is the distance camera has from the plane we are trying to touch
        Vector3 worldCoordinates = cameraMain.ScreenToWorldPoint(screenCoordinates);
        worldCoordinates.y = 10;
        transform.position = worldCoordinates;
    }

}
