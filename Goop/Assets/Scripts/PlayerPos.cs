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
        // Assign gameMaster before accessing it
        if (GameObject.FindGameObjectWithTag("GM").TryGetComponent(out gameMaster))
        {
            // Move the player to the last checkpoint position
            transform.position = gameMaster.lastCheckPoint;

            // Assign the HealthSystem component
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
