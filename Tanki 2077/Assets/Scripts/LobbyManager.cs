using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using System;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private InputField _enterRoomName;
    [SerializeField] private InputField _enterMaxPlayerCount;
    [SerializeField] private Toggle _isOpen;
    [SerializeField] private Toggle _isVisible;

    private void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.NickName = "Player" + UnityEngine.Random.Range(1000, 9999);
        Debug.Log(PhotonNetwork.NickName);
        PhotonNetwork.GameVersion = Application.version;
        PhotonNetwork.ConnectUsingSettings();

    }

    public void ActivatePanel(GameObject panel)
    {
        if (!panel.activeSelf)
        {
            panel.SetActive(true);
        }
        else
        {
            panel.SetActive(false);
        }
    }

    public void CreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = Convert.ToByte(_enterMaxPlayerCount.text);
        roomOptions.IsOpen = _isOpen.isOn;
        roomOptions.IsVisible = _isVisible.isOn;
        PhotonNetwork.CreateRoom(_enterRoomName.text, roomOptions);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinedRoom()
    { 
        PhotonNetwork.LoadLevel("Game");
        Debug.Log("Joined the room");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
