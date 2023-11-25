using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class ChopTree : MonoBehaviour
{

    // Define an event code to represent the "chop" message
    const byte CHOP_MESSAGE = 1;

    // Implement the IOnEventCallback interface
    public void OnEvent(EventData eventData)
    {
        // Check if the event code is the "chop" message code
        if (eventData.Code == CHOP_MESSAGE)
        {

            // Get the tree object ID from the custom data object
            object[] customData = (object[])eventData.CustomData;
            int treeViewId = (int)customData[0];

            // Get the tree object's PhotonView component and destroy it
            PhotonView treeView = PhotonView.Find(treeViewId);
            if (treeView != null)
            {
                //PhotonNetwork.Destroy(treeView.gameObject);
                DelayedFunction2(treeView);
            }
        }
    }

    IEnumerator DelayedFunction2(PhotonView treeView)
    {
        yield return new WaitForSeconds(5);
        // Code to execute after the delay
        PhotonNetwork.Destroy(treeView.gameObject);
    }
    void Start()
    {
        // Register this instance as a listener for Photon events
        PhotonNetwork.AddCallbackTarget(this);
    }

    void OnDestroy()
    {
        // Unregister this instance as a listener for Photon events
        PhotonNetwork.RemoveCallbackTarget(this);
    }
}
