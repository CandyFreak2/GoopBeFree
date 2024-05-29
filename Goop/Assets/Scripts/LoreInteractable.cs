using UnityEngine;


public class LoreInteractable : MonoBehaviour
{
    public bool isWithinRange;
    public GameObject keyIdentification, loreSprite;

    void Update()
    {
        if (isWithinRange)
        {
            keyIdentification.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E)) {
                loreSprite.SetActive(!loreSprite.activeSelf);
            }
        }
        else {
            keyIdentification.SetActive(false);
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
