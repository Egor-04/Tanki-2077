using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviourPunCallbacks, IPunObservable
{
    public GameObject Canvas;
    public LocalPlayer LocalPlayer;
    public GameObject Spawner;
    public bool IsDead;


    private void Awake()
    {
        Spawner = GameObject.FindGameObjectWithTag("Respawn");

        if (!photonView.IsMine)
        {
            LocalPlayer.enabled = false;
            Destroy(Canvas);
            Destroy(LocalPlayer.camera.gameObject);
        }
    }

    private void Update()
    {
        if (photonView.IsMine)
        {
            if (LocalPlayer.PlayerHp <= 0)
            {
                Dead();
                LocalPlayer.PlayerHp = 100;
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
                Spawner.GetComponent<SpawnPlayers>().Spawn();
            }
        }
    }

    public override void OnLeftRoom()
    {
        SceneManager.LoadScene(0);
    }


    [PunRPC]
    public void TakeDamage(int damage)
    {
        if (photonView.IsMine)
            LocalPlayer.PlayerHp -= damage;
    }

    [PunRPC]
    public void ReplenishHealth(int heartiness)
    {
        if (photonView.IsMine)
            LocalPlayer.PlayerHp += heartiness;
    }


    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(LocalPlayer.PlayerHp);
            stream.SendNext(LocalPlayer.Tower.rotation);
        }
        else
        {
            LocalPlayer.PlayerHp = (int)stream.ReceiveNext();
            LocalPlayer.Tower.rotation = (Quaternion)stream.ReceiveNext();
        }
    }
}
