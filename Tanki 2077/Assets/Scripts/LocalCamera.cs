using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalCamera : MonoBehaviour
{
    [SerializeField] private float _speed;
    public LocalPlayer LocalPlayer;
    private Vector3 _playerVector3;

    private void LateUpdate()
    {
        if (LocalPlayer == null)
        {
            LocalPlayer = GetComponent<LocalPlayer>();
            if (LocalPlayer == null) { Destroy(gameObject); return; }
        }

        _playerVector3 = LocalPlayer.transform.position;
        _playerVector3.z = -5;
        transform.position = Vector3.Lerp(transform.position, _playerVector3, _speed * Time.deltaTime);
    }


}
