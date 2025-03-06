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
    [SerializeField] private InputController inputController; 
    float moveSpeed = 3;
    float deltaHeight;
    float minLength = -45f;
    float maxLength = 75f;
    float minHeight = 0.5f;
    float maxHeight = 8f;
    float minWidth = -55f;
    float maxWidth = 70f;
    Camera playerCam;
    public float zoomResponse = 5f;
    float minZoom = 10f;
    float maxZoom = 50f;
    float currentZoom;
    float rotateValue = 50f;

    void OnEnable()
    {
        inputController.OnMovement += Movement;
        inputController.OnRun += Run;
        inputController.OnWalk += Walk;
        inputController.OnUP += Up;
        inputController.OnDown += Down;
        inputController.OnNoUpDown += StableHeight;
        inputController.OnRotate += Rotate;
        inputController.OnZoom += Zoom;
    }

    void Start()
    {
        playerCam = GetComponent<Camera>();
        currentZoom = playerCam.fieldOfView;
    }

    void Update()
    {    
        Movement();
        Zoom();
        Rotate();
        Up();
        Down();
    }

    public void Zoom()
    {
        currentZoom += -InputController.zoomValue.y * zoomResponse;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
        playerCam.fieldOfView = currentZoom;
    }

    public void Rotate()
    {
        Vector3 newRotation = new Vector3(-InputController.rotation.y, InputController.rotation.x, 0);
        transform.eulerAngles += newRotation * rotateValue * Time.deltaTime;
    }
            
    void Movement()
    {
        Vector3 newPos = new Vector3(InputController.pos.x, deltaHeight, InputController.pos.y);

        transform.Translate(newPos * moveSpeed * Time.deltaTime);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minLength, maxLength), Mathf.Clamp(transform.position.y, minHeight, maxHeight),
        Mathf.Clamp(transform.position.z, minWidth, maxWidth));

    }
    public void Up()
    {
        deltaHeight += 0.1f;
    }

    public void Down()
    {
        deltaHeight -= 0.1f;
    }
    
    public void StableHeight()
    {
        deltaHeight = 0;
    }

    void Run()
    {
        moveSpeed = 10f;
    }

    void Walk()
    {
        moveSpeed = 3f;
    }

    private void OnDisable()
    {
        inputController.OnMovement -= Movement;
        inputController.OnRun -= Run;
        inputController.OnWalk -= Walk;
        inputController.OnUP -= Up;
        inputController.OnDown -= Down;
        inputController.OnNoUpDown -= StableHeight;
        inputController.OnRotate -= Rotate;
        inputController.OnZoom -= Zoom;
    }

}