using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPos : MonoBehaviour
{
    private GameMaster gameMaster;
    private HealthSystem healthSystem;

    void Start()
    {
        if (gameMaster != null)
        {
            gameMaster = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
            transform.position = gameMaster.lastCheckPoint;

            healthSystem = GetComponent<HealthSystem>();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}