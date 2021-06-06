using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviourPunCallback
{
    [SerializeField] private float _speed;
    [SerializeField] private float _flightTime;

    public int Damage;

    public Player Player;

    private void Update()
    {
        if (_flightTime <= 0)
            Destroy(gameObject);

        _flightTime -= Time.deltaTime;
        transform.Translate(Vector3.right * _speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            collision.gameObject.GetComponent<Player>().TakeDamage(Damage);
        }
    }
}




