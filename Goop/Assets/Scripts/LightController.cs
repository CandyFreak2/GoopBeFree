using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightController : MonoBehaviour
{
    private Light2D _light;
    void Start()
    {
        _light = GetComponent<Light2D>();
        _light.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _light.enabled = true;

        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _light.enabled = false;

        }

    }
}
