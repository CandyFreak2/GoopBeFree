using UnityEngine;
using Discord;

public class DiscordController : MonoBehaviour
{
	public Discord.Discord discord;

	void Start()
	{
		discord = new Discord.Discord(1240474866772344942, (ulong)CreateFlags.Default);
		var activityManager = discord.GetActivityManager();
		var activity = new Activity
        {
			State = "Still Testing",
			Details = "Bigger Test"
		};
		activityManager.UpdateActivity(activity, (res) =>
		{
			if (res == Result.Ok) { Debug.Log("Status Set"); }
			else { Debug.LogError("Status Failed"); }
		});
	}

	void Update()
	{
		discord.RunCallbacks();
	}
}