using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviourPun, IPunObservable
{
    public LocalPlayer LocalPlayer;

    private void Awake()
    {
        if (!photonView.IsMine)
        {
            LocalPlayer.enabled = false;
            Destroy(LocalPlayer.camera.gameObject);
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(LocalPlayer.Tower.rotation);
        }
        else
        {
            LocalPlayer.Tower.rotation = (Quaternion)stream.ReceiveNext();
        }
    }
}
