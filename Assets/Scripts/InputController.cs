using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    private CameraInputAction inputs;
    public Action OnMovement;
    public Action OnRun;
    public Action OnWalk;
    public Action OnUP;
    public Action OnDown;
    public Action OnNoUpDown;
    public Action OnRotate;
    public Action OnZoom;
    public static Vector2 pos;
    public static Vector2 rotation;
    public static Vector2 zoomValue;

    private void OnEnable()
    {
        inputs = new CameraInputAction();
        inputs.Enable();

        inputs.Camera.Movement.started += OnMoving;
        inputs.Camera.Movement.performed += OnMoving;
        inputs.Camera.Movement.canceled += OnStopMoving;

        inputs.Camera.Up.started += OnMoveUp;
        inputs.Camera.Up.performed += OnMoveUp;
        inputs.Camera.Up.canceled += OnStableHeight;

        inputs.Camera.Down.started += OnMoveDown;
        inputs.Camera.Down.performed += OnMoveDown;
        inputs.Camera.Down.canceled += OnStableHeight;

        inputs.Camera.Rotate.started += OnRotation;
        inputs.Camera.Rotate.performed += OnRotation;
        inputs.Camera.Rotate.canceled += OnRotationStop;

        inputs.Camera.Run.started += OnRunning;
        inputs.Camera.Run.performed += OnRunning;
        inputs.Camera.Run.canceled += OnWalking;
        
        inputs.Camera.Zoom.started += OnZooming;
        inputs.Camera.Zoom.performed += OnZooming;
        inputs.Camera.Zoom.canceled += OnZoomStop;
    }

    public void OnMoving(InputAction.CallbackContext context)
    {
        pos = context.ReadValue<Vector2>();
    }

    public void OnStopMoving(InputAction.CallbackContext context)
    {
        pos = Vector2.zero;
    }

    public void OnMoveUp(InputAction.CallbackContext context)
    {
        OnUP?.Invoke();
    }

    public void OnMoveDown(InputAction.CallbackContext context)
    {
        OnDown?.Invoke();
    }

    public void OnStableHeight(InputAction.CallbackContext context)
    {
        OnNoUpDown?.Invoke();
    }

    public void OnRotation(InputAction.CallbackContext context)
    {
        rotation = context.ReadValue<Vector2>();
    }

    public void OnRotationStop(InputAction.CallbackContext context)
    {
        rotation = Vector2.zero;
    }

    public void OnZooming(InputAction.CallbackContext context)
    {
        zoomValue = context.ReadValue<Vector2>();
    }

    public void OnZoomStop(InputAction.CallbackContext context)
    {
        zoomValue = Vector2.zero;
    }

    public void OnRunning(InputAction.CallbackContext context)
    {
        OnRun?.Invoke();
    }

    public void OnWalking(InputAction.CallbackContext context)
    {
        OnWalk?.Invoke();
    }
    private void OnDisable()
    {
        inputs.Camera.Movement.started -= OnMoving;
        inputs.Camera.Movement.performed -= OnMoving;
        inputs.Camera.Movement.canceled -= OnStopMoving;

        inputs.Camera.Up.started -= OnMoveUp;
        inputs.Camera.Up.performed -= OnMoveUp;
        inputs.Camera.Up.canceled -= OnStableHeight;

        inputs.Camera.Down.started -= OnMoveDown;
        inputs.Camera.Down.performed -= OnMoveDown;
        inputs.Camera.Down.canceled -= OnStableHeight;

        inputs.Camera.Rotate.started -= OnRotation;
        inputs.Camera.Rotate.performed -= OnRotation;
        inputs.Camera.Rotate.canceled -= OnRotationStop;

        inputs.Camera.Run.started -= OnRunning;
        inputs.Camera.Run.performed -= OnRunning;
        inputs.Camera.Run.canceled -= OnWalking;
        
        inputs.Camera.Zoom.started -= OnZooming;
        inputs.Camera.Zoom.performed -= OnZooming;
        inputs.Camera.Zoom.canceled -= OnZoomStop;

        inputs.Disable();
    }

}
