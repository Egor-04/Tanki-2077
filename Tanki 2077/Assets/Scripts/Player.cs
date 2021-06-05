using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviourPun, IPunObservable
{ 
    public LocalPlayer LocalPlayer;
    public int PlayerHp;
    public bool IsDead;


    private void Awake()
    {
        if (!photonView.IsMine)
        {
            LocalPlayer.enabled = false;
            Destroy(LocalPlayer.camera.gameObject);
        }
    }

    private void Update()
    {
        if (photonView.IsMine)
        {
            if (PlayerHp <= 0)
            {
                Dead();
                PlayerHp = 100;
            }
        }
        
    }

    public void Dead()
    {
        if (photonView.IsMine)
        {
            if (IsDead == false)
            {
                PhotonNetwork.Destroy(gameObject);
                IsDead = true;
            }
        }
    }

    [PunRPC]
    public void TakeDamage(int damage)
    {
        if (photonView.IsMine)
        {
            PlayerHp -= damage;
        }
    }


    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(PlayerHp);
            stream.SendNext(LocalPlayer.Tower.rotation);
        }
        else
        {
            PlayerHp = (int)stream.ReceiveNext();
            LocalPlayer.Tower.rotation = (Quaternion)stream.ReceiveNext();
        }
    }
}
