using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class JoinRoom : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab;
    public Button joinButton;
    public TextMeshProUGUI roomNameText;
    private string roomName;

    public void SetRoomName()
    {
        roomName = roomNameText.text;
        joinButton.onClick.AddListener(JoinSelectedRoom);
    }

    #region Pun Callbacks

    public void JoinSelectedRoom()
    {

        if (PhotonNetwork.IsConnected)
        {
            if (!string.IsNullOrEmpty(roomName))
            {
                Debug.Log("Connected room " + roomName);
                PhotonNetwork.JoinRoom(roomName);
                Debug.Log($"{PhotonNetwork.CurrentRoom.Name} joined!");
            }
        }
    }


    public override void OnJoinedRoom()
    {
        Debug.Log($"{PhotonNetwork.CurrentRoom.Name} joined!");
        PhotonNetwork.Instantiate(playerPrefab.name, new Vector3(0, 10.0f, 0), Quaternion.identity);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        // Failed to connect to random, probably because none exist
        Debug.Log(message);
    }


    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.LogWarning($"Failed to connect: {cause}");
    }

    #endregion

}