using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Composites;
using UnityEngine.InputSystem.Controls;

public class CameraMovementNewIP : MonoBehaviour
{
    float moveSpeed = 3;
    float cameraHeight;
    Vector2 pos;
    float rot;
    Camera playerCam;
    public float zoomSpeed = 5f;
    float minZoom = 10f;
    float maxZoom = 50f;

    private float currentZoom;
    private CameraInputAction cameraInputAction;

    void Awake()
    {
        cameraInputAction = new CameraInputAction();
    }

    private void Start()
    {
        playerCam = GetComponent<Camera>();
        currentZoom = playerCam.fieldOfView;
    }

    void Update()
    {
        Vector3 newPos = new Vector3(pos.x, cameraHeight, pos.y);
        transform.position += newPos * moveSpeed * Time.deltaTime;
        transform.Rotate(0, rot, 0, Space.World);
    }

    public void Zoom(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Vector2 zoomValue = context.ReadValue<Vector2>();
            currentZoom += -zoomValue.y * zoomSpeed;
            currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
            playerCam.fieldOfView = currentZoom;
        }
    }

    public void Rotate(InputAction.CallbackContext context)
    {
        rot = context.ReadValue<float>();
    }

    public void Movement(InputAction.CallbackContext context)
    {
        pos = context.ReadValue<Vector2>();
    }
    public void Up(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            cameraHeight += 0.1f;
        }
        else
        {
            cameraHeight = 0;
        }
    }
    public void Down(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            cameraHeight -= 0.1f;
        }
        else
        {
            cameraHeight = 0;
        }
    }

    public void Run(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            moveSpeed = 10f;
        }
        else
        {
            moveSpeed = 3f;
        }
    }
}