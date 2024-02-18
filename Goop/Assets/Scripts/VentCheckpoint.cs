using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentCheckpoint : MonoBehaviour
{
    private GameMaster gameMaster;

    private void Start()
    {
        gameMaster = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            gameMaster.lastCheckPoint = transform.position;
        }
    }
}
