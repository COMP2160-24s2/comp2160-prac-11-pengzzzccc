using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] private float zoomSpeed = 10f;
    [SerializeField] private float maxZoomForOrt = 20f;
    [SerializeField] private float minZoomForOrt = 5f;
    [SerializeField] private float maxZoomForPersp = 90f;
    [SerializeField] private float minZoomForPersp = 10f;
    
    private Actions actions;
    private InputAction roll;
    private Camera camera;
    private float zoomSpeeds;
    private float maxForOrtl;
    private float minForOrtl;
    private float maxForPersp;
    private float minForPersp;

    void Awake()
    {
        camera = Camera.main;
        actions = new Actions();
        roll = actions.camera.zoom;
       
    }
    
    void OnEnable()
    {
        roll.Enable();
    }
    
    void OnDisable()
    {
        roll.Disable();
    }
    
    void Start()
    {
        zoomSpeeds = zoomSpeed;
        maxForOrtl = maxZoomForOrt;
        minForOrtl = minZoomForOrt;
        maxForPersp = maxZoomForPersp;
        minForPersp = minZoomForPersp;
    }

    void Update()
    {
        float zoomInput = roll.ReadValue<float>();
        Debug.Log(zoomInput);
        
        if(camera.orthographic)
        {
            camera.orthographicSize = Mathf.Clamp(camera.orthographicSize + zoomInput * Time.deltaTime * zoomSpeeds
            , minForOrtl
            , maxForOrtl);
        }
        else
        {
            camera.fieldOfView = Mathf.Clamp(camera.fieldOfView + zoomInput * Time.deltaTime  * zoomSpeeds
            , minForPersp
            , maxForPersp);
        }
    }
}
