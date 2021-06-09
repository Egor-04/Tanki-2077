using Photon.Realtime;
using UnityEngine.UI;
using UnityEngine;
using Photon.Pun;
using System.Collections.Generic;

public class RoomButton : MonoBehaviourPunCallbacks
{
    [Header("Room Info")]
    public Text RoomName;
    public Text PlayerCount;
    public Text MaxPlayers;
    public Toggle IsOpen;
    public Toggle IsVisible;

    public void EnterInThisRoom()
    {
        PhotonNetwork.JoinRoom(RoomName.text);
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        for (int i = 0; i < roomList.Count; i++)
        {
            if (roomList[i].Name == RoomName.text)
            {
                if (roomList[i].PlayerCount == 0)
                {
                    Destroy(gameObject);
                }
            }
        }
    }

    public void SetRoomInfo(RoomInfo roomInfo)
    {
        RoomName.text = roomInfo.Name;
        PlayerCount.text = roomInfo.PlayerCount.ToString();
        MaxPlayers.text = roomInfo.MaxPlayers.ToString();
        IsOpen.isOn = roomInfo.IsOpen;
        IsVisible.isOn = roomInfo.IsVisible;
    }
}
