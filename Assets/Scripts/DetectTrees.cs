using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class DetectTrees : MonoBehaviour
{
    private int treeOwnerActorId;
    public GameObject chopButton;
    private PhotonView tree;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Detect()
    {
        //add condition to check if 'chopping' is active
        float distanceThreshold = 5.0f; // Distance threshold to trigger action
        GameObject[] treeObjects = GameObject.FindGameObjectsWithTag("Tree");
        Player currentPlayer = PhotonNetwork.LocalPlayer;

        foreach (GameObject treeObject in treeObjects)
        {
            float distance = Vector3.Distance(transform.position, treeObject.transform.position);

            // Check if the tree belongs to another player and is within distance threshold
            if (distance < distanceThreshold)
            {
                PhotonView photonView = treeObject.GetComponent<PhotonView>();
                if (photonView != null && photonView.Owner != currentPlayer)
                {
                    PhotonView treeView = treeObject.GetComponent<PhotonView>();
                    treeOwnerActorId = treeView.OwnerActorNr;
                    tree = treeView;
                    // Do something when the player gets close to a tree that belongs to another player
                    Debug.Log("Player is close to a tree that belongs to another player");
                    chopButton.SetActive(true);
                    
                }
            }
        }
    }

    public void SendChopMessage()
    {
        // Define an event code to represent the "chop" message
        const byte CHOP_MESSAGE = 1;

        // Define a custom data object to hold the tree object's ID
        object[] data = new object[] { tree.ViewID };

        // Define the RaiseEventOptions to send the message to the owner of the tree object
        RaiseEventOptions options = new RaiseEventOptions();
        options.TargetActors = new int[] { treeOwnerActorId };

        // Send the message to the owner of the tree object
        PhotonNetwork.RaiseEvent(CHOP_MESSAGE, data, options, SendOptions.SendReliable);
    }
}
