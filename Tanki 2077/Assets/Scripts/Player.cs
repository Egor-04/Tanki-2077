using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _speedRotation;
    [SerializeField] private Transform _tower;
    
    private PhotonView _photonView;


    private void Start()
    {
        _photonView = GetComponent<PhotonView>();
    }

    private void Update()
    {
        if (_photonView.IsMine)
        {
            float vertical = Input.GetAxis("Vertical") * _speed * Time.deltaTime;
            transform.Translate(new Vector3(0f, vertical, 0f));

            float RotationZ = Input.GetAxis("Horizontal") * _speedRotation * Time.deltaTime;
            transform.Rotate(0f, 0f, -RotationZ);

            Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            _tower.rotation = Quaternion.Euler(0f, 0f, rotZ);

        }
    }

}
