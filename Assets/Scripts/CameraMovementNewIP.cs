using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovementNewIP : MonoBehaviour
{
    float speed;
    Vector3 pos;
    private CameraInputAction cameraInputAction;

    void Awake()
    {
        cameraInputAction = new CameraInputAction();
    }

    void Update()
    {
        Vector3 newpos = new Vector3(pos.x, pos.y, pos.z);
        transform.position += newpos * speed * Time.deltaTime;
    }

    public void Movement(InputAction.CallbackContext context)
    {
        pos = context.ReadValue<Vector3>();
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
