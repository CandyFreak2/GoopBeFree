using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LoreInteractable : MonoBehaviour
{
    public bool isWithinRange;

    void Update()
    {
        if (isWithinRange)
        {
            // figure out what happens
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isWithinRange = true;
            Debug.Log("Player Within Range");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isWithinRange = false;
            Debug.Log("Player Is Not Within Range");
        }
    }
}
