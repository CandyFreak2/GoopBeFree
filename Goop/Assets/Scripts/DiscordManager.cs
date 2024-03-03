using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscordManager : MonoBehaviour
{
    private Discord.Discord discord;
    void Start()
    {
        discord = new Discord.Discord(1213651179146313758, (ulong)Discord.CreateFlags.NoRequireDiscord);
    }

    void Update()
    {
        discord.RunCallbacks();
    }

    void OnDisable()
    {
        discord.Dispose();
    }

    public void ChangeActivity()
    {
        var manager = discord.GetActivityManager();
        var activity = new Discord.Activity
        {
            State = "Escaping Captivity",
            Assets =
            {
                LargeImage = "main_logo"
            }
        };
        manager.UpdateActivity(activity, (res) =>
        {
            Debug.Log("Updated");
        });
    }
}
