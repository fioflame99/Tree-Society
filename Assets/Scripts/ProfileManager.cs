using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

using Hashtable = ExitGames.Client.Photon.Hashtable;

public class ProfileManager : MonoBehaviour
{
    public TMP_InputField usernameInput;

    public void SaveProfile()
    {
        SetUsername();
    }

    public void SetUsername()
    {
        PhotonNetwork.NickName = usernameInput.text;
        PlayerPrefs.SetString("username", usernameInput.text);
    }

    public void SetAvatar1()
    {
        var hash = PhotonNetwork.LocalPlayer.CustomProperties;
        hash.Add("Avatar", "Avatar1");
        PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
        PlayerPrefs.SetString("avatar", "Avatar1");
        Debug.Log(PhotonNetwork.LocalPlayer.CustomProperties);
    }

    public void SetAvatar2()
    {
        var hash = PhotonNetwork.LocalPlayer.CustomProperties;
        hash.Add("Avatar", "Avatar2");
        PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
        PlayerPrefs.SetString("avatar", "Avatar2");
        Debug.Log(PhotonNetwork.LocalPlayer.CustomProperties);
    }
}
