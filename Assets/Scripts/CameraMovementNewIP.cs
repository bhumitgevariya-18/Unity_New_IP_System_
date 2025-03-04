using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Composites;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UIElements;

public class CameraMovementNewIP : MonoBehaviour
{
    float moveSpeed = 3;
    float deltaHeight;
    float minHeight = 0.5f;
    float maxHeight = 10f;
    Vector2 pos;
    Vector2 rotation;
    Camera playerCam;
    public float zoomSpeed = 5f;
    float minZoom = 10f;
    float maxZoom = 50f;
    float currentZoom;
    bool mouseRightbutton;
    float rotateValue = 50f;
    CameraInputAction cameraInputAction;

    void Start()
    {
        cameraInputAction = new CameraInputAction();
        playerCam = GetComponent<Camera>();
        currentZoom = playerCam.fieldOfView;
    }

    void Update()
    {
        Vector3 newPos = new Vector3(pos.x, deltaHeight, pos.y);
        //transform.position += newPos * moveSpeed * Time.deltaTime;
        transform.Translate(newPos * moveSpeed * Time.deltaTime);
        
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, minHeight, maxHeight), transform.position.z);

        if (mouseRightbutton)
        {
            Vector3 newRotation = new Vector3(-rotation.y, rotation.x, 0);
            transform.eulerAngles += newRotation * rotateValue * Time.deltaTime;
        }
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
        if (context.performed)
        {
            rotation = context.ReadValue<Vector2>();
        }
    }

    public void MouseRightButton(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            mouseRightbutton= true;
        }
        else
        {
            mouseRightbutton= false;
        }
        
    }

    public void Movement(InputAction.CallbackContext context)
    {
        pos = context.ReadValue<Vector2>();
    }
    public void Up(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            deltaHeight += 0.1f;
        }
        else
        {
            deltaHeight = 0;
        }
        
    }
    public void Down(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            deltaHeight -= 0.1f;
        }
        else
        {
            deltaHeight = 0;
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