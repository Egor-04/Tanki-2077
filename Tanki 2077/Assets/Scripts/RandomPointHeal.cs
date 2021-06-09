using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RandomPointHeal : MonoBehaviour
{
    [SerializeField] private Transform[] _healthPoint;
    [SerializeField] private GameObject _heal;
    [SerializeField] private float _startTimer;
    [SerializeField] private float _endTimer;

    private int _randomPoint;

    private void Start()
    {
        _randomPoint = Random.Range(0, _healthPoint.Length);
        Vector3 poz = _healthPoint[_randomPoint].position;
        poz.z = 0;
        PhotonNetwork.Instantiate(_heal.name, poz, _healthPoint[_randomPoint].rotation);
    }


    private void Update()
    {
        
        if (_endTimer <= 0)
        {
            _randomPoint = Random.Range(0, _healthPoint.Length);
            Vector3 poz = _healthPoint[_randomPoint].position;
            poz.z = 0;
            PhotonNetwork.Instantiate(_heal.name, poz, _healthPoint[_randomPoint].rotation);  
            _endTimer = _startTimer;
        }
        _endTimer -= Time.deltaTime;
        
    }
}
