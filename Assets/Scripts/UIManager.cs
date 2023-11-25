using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject Rooms;
    public GameObject Profile;
    // Start is called before the first frame update
    void Start()
    {
        Rooms.SetActive(false);
        Profile.SetActive(false);
    }

    public void OpenRoomsPanel()
    {
        Rooms.SetActive(true);
    }

    public void CloseRoomsPanel()
    {
        Rooms.SetActive(false);
    }

    public void OpenProfilePanel()
    {
        Profile.SetActive(true);
    }

    public void CloseProfilePanel()
    {
        Profile.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
