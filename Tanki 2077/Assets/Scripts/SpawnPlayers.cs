using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject Player;
    public float MinX, MinY, MaxX, MaxY;

    private void Start()
    {
        Vector2 RandomPosition = new Vector2 (Random.Range(MinX, MaxY), Random.Range(MinY, MaxX));
        PhotonNetwork.Instantiate(Player.name, RandomPosition, Quaternion.identity); 
    }

}
