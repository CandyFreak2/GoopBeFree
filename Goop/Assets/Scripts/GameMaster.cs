using UnityEngine;

public class GameMaster : MonoBehaviour
{
    private static GameMaster instance;
    public Transform player;
    public Vector2 lastCheckPoint = Vector2.zero;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            DontDestroyOnLoad(instance);
        }

        if (player != null)
        {
            lastCheckPoint = player.position;
        }
        else
        {
            Debug.LogError("Player Transformation Not Assigned");
        }
    }
}
