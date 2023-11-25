using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.ARFoundation;


public class SwitchCamera : MonoBehaviour
{
    public Button myButton;
    [SerializeField] public ARCameraManager cameraManager;

    void Start()
    {
        myButton.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        // Load a new scene
        SwitchFacingDirection();
        
    }

    public void SwitchFacingDirection()
    {
        if (cameraManager == null)
        {
            Debug.LogError("Camera manager is not set!");
            return;
        }

        if (cameraManager.currentFacingDirection == CameraFacingDirection.World)
        {
            cameraManager.requestedFacingDirection = CameraFacingDirection.User;
        }
        else
        {
            cameraManager.requestedFacingDirection = CameraFacingDirection.World;
        }
    }
}