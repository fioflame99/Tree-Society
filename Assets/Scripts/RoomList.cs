using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RoomList : MonoBehaviourPunCallbacks
{
    public GameObject RoomPrefab;
    public GameObject[] AllRooms;
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        Debug.Log("roomlistupdate");
        for(int i=0;i<AllRooms.Length;i++)
        {
            if(AllRooms[i]!=null)
            {
                Destroy(AllRooms[i]);
            }
        }
        AllRooms = new GameObject[roomList.Count];
        Debug.Log("No of rooms " + roomList.Count);
        for(int i=0; i<roomList.Count;i++)
        {
            print(roomList[i].Name);
            if(roomList[i].IsOpen && roomList[i].IsVisible && roomList[i].PlayerCount >= 1)
            {
                GameObject Room = Instantiate(RoomPrefab, Vector3.zero, Quaternion.identity, GameObject.Find("Content").transform);
                Room.GetComponent<Room>().Name.text = roomList[i].Name;
                AllRooms[i] = Room;
            }
            
        }
        
    }
}
