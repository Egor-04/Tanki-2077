using System.Collections.Generic;
using Photon.Realtime;
using UnityEngine;
using Photon.Pun;

public class RoomList: MonoBehaviourPunCallbacks
{
    [Header("Room List")]
    [SerializeField] private Transform _content;
    [SerializeField] private RoomButton _roomButtonScript;

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        for (int i = 0; i < roomList.Count; i++)
        {
            if (roomList[i].PlayerCount > 0)
            {
                RoomButton roomButton = Instantiate(_roomButtonScript, _content);

                if (roomButton != null)
                {
                    roomButton.SetRoomInfo(roomList[i]);
                }
            }
        }
    }
}
