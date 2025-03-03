using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Composites;
using UnityEngine.InputSystem.Controls;

public class CameraMovementNewIP : MonoBehaviour
{
    float speed = 3;
    float h;
    Vector2 pos;
    float rot;
    private CameraInputAction cameraInputAction;

    void Awake()
    {
        cameraInputAction = new CameraInputAction();
    }

    void Update()
    {
        Vector3 newpos = new Vector3(pos.x, h, pos.y);
        transform.position += newpos * speed * Time.deltaTime;
        transform.Rotate(0, rot, 0, Space.World);
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
            h += 0.1f;
        }
        else
        {
            h = 0;
        }
    }
    public void Down(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            h -= 0.1f;
        }
        else
        {
            h = 0;
        }
    }

    public void Run(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            speed = 10f;
        }
        else
        {
            speed = 3f;
        }
    }
}