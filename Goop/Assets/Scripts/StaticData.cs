using UnityEngine;
using UnityEngine.SceneManagement;

public class StaticData : MonoBehaviour
{
    public static float[] timeValuesToKeep;

    void Start()
    {
        timeValuesToKeep = new float[SceneManager.sceneCountInBuildSettings];
    }
}
