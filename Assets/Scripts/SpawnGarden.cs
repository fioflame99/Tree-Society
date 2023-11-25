using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.XR.ARFoundation;

public class SpawnGarden : MonoBehaviour
{
    public GameObject gardenPrefab;
    public ARSessionOrigin sessionCamera;
    public GameObject playerPrefab;
    public GameObject player2Prefab;
    public GameObject tree;

    public float[,] positions = new float[,]{ { 0, 0, 2 }, {5,0,2 },{0,0,7 }, {5, 0, 7} };
    public float[,] cameraPositions = new float[,] { { 0, 1.6f, -0.4f }, {5, 1.6f, -1f }, { 0, 1.6f, 4f }, { 5, 1.6f, 4f } };
    public float[,] playerPositions = new float[,] { { 0, 0, 0 }, { 5, 0, 0 }, { 0, 0, 5 }, { 5, 0, 5 } };

    public Vector3 offset = new Vector3(0, -3, 1);

    private GameObject playerObject;
    private GameObject gardenObject;

    private Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {

        int gardenIndex = (int)PhotonNetwork.CurrentRoom.CustomProperties["GardenIndex"];
        PlayerPrefs.SetInt("PlayerIndex",gardenIndex);
        Vector3 position = new Vector3(positions[gardenIndex,0], positions[gardenIndex,1], positions[gardenIndex,2]);
        
        Vector3 cameraPosition = new Vector3(cameraPositions[gardenIndex, 0], cameraPositions[gardenIndex, 1], cameraPositions[gardenIndex, 2]);
        Vector3 playerPosition = new Vector3(playerPositions[gardenIndex, 0], playerPositions[gardenIndex, 1], playerPositions[gardenIndex, 2]);
        pos = playerPosition;
        gardenObject = PhotonNetwork.Instantiate(gardenPrefab.name, position, Quaternion.identity);
        Debug.Log("Instantiating garden at " + position);
        
        sessionCamera.transform.position = cameraPosition;
       if(PlayerPrefs.GetString("avatar") == "avatar1")
        {
            playerObject = PhotonNetwork.Instantiate(playerPrefab.name, playerPosition, Quaternion.identity);
        }
        else
        {
            playerObject = PhotonNetwork.Instantiate(player2Prefab.name, playerPosition, Quaternion.identity);
        }
        
        
        ExitGames.Client.Photon.Hashtable roomProps = PhotonNetwork.CurrentRoom.CustomProperties;
        roomProps["GardenIndex"] = gardenIndex + 1;
        PhotonNetwork.CurrentRoom.SetCustomProperties(roomProps);
    }

    // Update is called once per frame
    void Update()
    {
        
        // Update the position and rotation of the player object based on the ARSessionOrigin's transform
       playerObject.transform.position = sessionCamera.transform.position + offset;
       playerObject.transform.rotation = sessionCamera.transform.rotation;
    }
}
