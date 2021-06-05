using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalPlayer : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _speedRotation;
    
    public Transform Tower;
    public Camera camera;
    
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

            Vector3 difference = camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            difference.Normalize();
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            Tower.rotation = Quaternion.Euler(0f, 0f, rotZ);

        }
    }

}
