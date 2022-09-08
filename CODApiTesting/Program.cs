// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json.Linq;
using RestSharp;
using CODApiTesting;
using System.Linq;

internal class Program
{
    static async Task Main(string[] args)
    {

		/*This is getting Cod results using HTTPClient*/



		Console.WriteLine("What is your gamertag in Warzone?");
		string gamertag = Console.ReadLine();

		Console.WriteLine("What platform do you play on?" +
            " psn for playstation, steam for Steam, " +
            "battle for BattleNet, xbl for XBox,");
		string platform = Console.ReadLine();

		var uri = $"https://call-of-duty-modern-warfare.p.rapidapi.com/warzone/{gamertag}/{platform}";

		var client = new HttpClient();
		var request = new HttpRequestMessage
		{
			Method = HttpMethod.Get,
			RequestUri = new Uri(uri),
			Headers =
			{
				{ "X-RapidAPI-Key", "613e1be4fcmshc7128b510340304p134544jsn7e3018cf4f57" },
				{ "X-RapidAPI-Host", "call-of-duty-modern-warfare.p.rapidapi.com" },
			},
		};

		using (var response = await client.SendAsync(request))
		{
			//response.EnsureSuccessStatusCode();
			var body = await response.Content.ReadAsStringAsync();
			
			var entries = JObject.Parse(body)["br_all"].ToString();

			//These next two lines get me the amount of wins the chosen player has and prints it
			var win = JObject.Parse(entries).GetValue("wins");
			Console.WriteLine($"You have {win} wins");

			var kills = JObject.Parse(entries).GetValue("kills");
			Console.WriteLine($"You have {kills} kills");

			var kdRatio = JObject.Parse(entries).GetValue("kdRatio");
			Console.WriteLine($"You have a {kdRatio} kd ratio");

			var downs = JObject.Parse(entries).GetValue("downs");
			Console.WriteLine($"You've downed {downs} enemies");

			var topTwentyFive = JObject.Parse(entries).GetValue("topTwentyFive");
			Console.WriteLine($"You've been in the top twenty five {topTwentyFive} times");

			var topTen = JObject.Parse(entries).GetValue("topTen");
			Console.WriteLine($"You've gotten into the top ten {topTen} times");

			var contracts = JObject.Parse(entries).GetValue("contracts");
			Console.WriteLine($"You've completed {contracts} contracts");

			var revives = JObject.Parse(entries).GetValue("revives");
			Console.WriteLine($"You've revived {revives} friendlies");

			var topFive = JObject.Parse(entries).GetValue("topFive");
			Console.WriteLine($"You've gotten into the top five {topFive} times");

			var score = JObject.Parse(entries).GetValue("score");
			Console.WriteLine($"Your total score is {score}");

			var timePlayed = JObject.Parse(entries).GetValue("timePlayed");
			Console.WriteLine($"You've played for {timePlayed} minutes");

			var gamesPlayed = JObject.Parse(entries).GetValue("gamesPlayed");
			Console.WriteLine($"You've played {gamesPlayed} games");

			var scorePerMinute = JObject.Parse(entries).GetValue("scorePerMinute");
			Console.WriteLine($"Your average score per minute is {scorePerMinute}");

			var deaths = JObject.Parse(entries).GetValue("deaths");
			Console.WriteLine($"You've died {deaths} times");
		}
	}
}