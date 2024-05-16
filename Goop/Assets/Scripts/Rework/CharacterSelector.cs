using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelector : MonoBehaviour
{
    public GameObject[] characters;
    private int currentCharacterIndex = 0;

    public void NextOption() => ChangeCharacter(1);

    public void PreviousCharacter() => ChangeCharacter(-1);

    private void ChangeCharacter(int arrowDirection)
    {
        characters[currentCharacterIndex].SetActive(false);
        currentCharacterIndex = (currentCharacterIndex + arrowDirection + characters.Length) % characters.Length;
        characters[currentCharacterIndex].SetActive(true);
    }

    public void StartGame()
    {
        PlayerPrefs.SetInt("GoopCharacter", currentCharacterIndex);
        SceneManager.LoadScene(7, LoadSceneMode.Single);
    }
}
