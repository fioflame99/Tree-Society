using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.SceneManagement;

public class CreateAndJoin : MonoBehaviourPunCallbacks
{

    public TMP_InputField input_create;
    public TMP_InputField input_join;

    public void CreateRoom()
    {
        if (PhotonNetwork.IsConnected)
        {
            if (!string.IsNullOrEmpty(input_create.text))
            {
                ExitGames.Client.Photon.Hashtable roomProps = new ExitGames.Client.Photon.Hashtable();
                roomProps.Add("GardenIndex", 0);
                PhotonNetwork.CreateRoom(input_create.text, new RoomOptions() { IsVisible = true, IsOpen = true, CustomRoomProperties = roomProps }, TypedLobby.Default, null) ;
            }
        }
    }

    public void JoinRoom()
    {

        if (PhotonNetwork.IsConnected)
        {
            if (!string.IsNullOrEmpty(input_join.text))
            {
                PhotonNetwork.JoinRoom(input_join.text);
                Debug.Log($"{PhotonNetwork.CurrentRoom.Name} joined!");
            }
        }
        
    }

    public void JoinRoomInList(string roomName)
    {
        PhotonNetwork.JoinRoom(roomName);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log($"{PhotonNetwork.CurrentRoom.Name} joined!");

        //switch scene
        SceneManager.LoadScene("RoomScene");
    }

    public void LeaveRoom()
    {
        PhotonNetwork.DestroyPlayerObjects(PhotonNetwork.LocalPlayer);
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene("PhotonTrial");
    }
}
