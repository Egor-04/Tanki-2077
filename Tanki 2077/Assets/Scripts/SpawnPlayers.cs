using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayers : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoint;

    public GameObject Player;

    private int _randomPoint;

    private void Start()
    {

        _randomPoint = Random.Range(0, _spawnPoint.Length);
        PhotonNetwork.Instantiate(Player.name, _spawnPoint[_randomPoint].position, Quaternion.identity);
        
    }

}
