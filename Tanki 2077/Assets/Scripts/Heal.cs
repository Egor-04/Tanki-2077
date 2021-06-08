using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Heal : MonoBehaviourPunCallback
{
    [SerializeField] private int _heartiness;

    private void Start()
    {
        Destroy(gameObject, 15);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().ReplenishHealth(_heartiness);
            Destroy(gameObject);
        }       
    }
}
