using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalPlayer : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _speedRotation;
    [SerializeField] private float _cooldown;
    [SerializeField] private float _cooldownEnd;

    [SerializeField] private Transform _shotPoint;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Text _coordinatesText;
    [SerializeField] private Text _healText;
    [SerializeField] private Text _cooldownTimerText;

    public int PlayerHp;

    public Transform Tower;
    public Camera camera;


    private PhotonView _photonView;


    private void Start()
    {
        _photonView = GetComponent<PhotonView>();
        transform.GetChild(0).transform.SetParent(null);
    }

    private void Update()
    {
        if (_photonView.IsMine)
        {
            _cooldownTimerText.text = string.Format("{0:0}", _cooldownEnd) + "Sec";
            _healText.text = PlayerHp + " hp";
            _coordinatesText.text = string.Format("{0:0}", transform.position.x)  + " / " + string.Format("{0:0}", transform.position.y); 
            
            float vertical = Input.GetAxis("Vertical") * _speed * Time.deltaTime;
            transform.Translate(new Vector3(0f, vertical, 0f));

            float RotationZ = Input.GetAxis("Horizontal") * _speedRotation * Time.deltaTime;
            transform.Rotate(0f, 0f, -RotationZ);

            Vector3 difference = camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            difference.Normalize();
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            Tower.rotation = Quaternion.Euler(0f, 0f, rotZ);

            if (_cooldownEnd <= 0)
            {
                if (Input.GetKey(KeyCode.Mouse0))
                {
                    PhotonNetwork.Instantiate(_bullet.name, _shotPoint.position, _shotPoint.rotation);
                    _cooldownEnd = _cooldown;
                }
            }
            _cooldownEnd -= Time.deltaTime;
            

            if (PlayerHp > 100)
            {
                PlayerHp = 100;
            }

        }
    }



}
