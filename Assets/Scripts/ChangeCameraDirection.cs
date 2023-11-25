using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ChangeCameraDirection : MonoBehaviour
{

    [SerializeField] public ARCameraManager cameraManager;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ChangeToFront()
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
    }

    public void ChangeToBack()
    {
        if (cameraManager == null)
        {
            Debug.LogError("Camera manager is not set!");
            return;
        }

        if (cameraManager.currentFacingDirection == CameraFacingDirection.User)
        {
            cameraManager.requestedFacingDirection = CameraFacingDirection.World;
        }
    }
}
