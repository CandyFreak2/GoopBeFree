using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinState : MonoBehaviour
{ 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!collision.TryGetComponent<GoopMovement>(out _))
            {
                Debug.LogError("Player Script is Null");
            }
        }
    }
}
