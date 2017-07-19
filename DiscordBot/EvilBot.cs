using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
namespace DiscordBot
{
	class EvilBot
	{

		DiscordClient discord;
		CommandService commands;
		string[] freshestMemes;
		public EvilBot()
		{
			discord = new DiscordClient(x =>
			{
				x.LogLevel = LogSeverity.Info;
				x.LogHandler = Log;
			});

			discord.UsingCommands(x =>
			{
				x.PrefixChar = '`';
				x.AllowMentionPrefix = true;
			});

			CommandService commands;
			commands = discord.GetService<CommandService>();



			//---------------------------------------Show me what you got---------------------------------

			freshestMemes = new string[]
				{
				"mem/test.jpg",
				"mem/GetInBich.jpg",
				"mem/rompers.jpg",
				"mem/dwk.jpg",
				"mem/abortion.jpg",
				"mem/prayer.jpg",
				"mem/sasuke_patrick.jpg"

				};
			commands.CreateCommand("show me what you got")
				.Do(async (e) =>
				{
					Random rand = new Random();
					int temp = rand.Next(0, freshestMemes.Length);
					await e.Channel.SendMessage("Here is meme #" + temp + "/" + freshestMemes.Length);
					await e.Channel.SendFile(freshestMemes[temp]);
				});

			//----------------------------------Text Commands------------------------------

			commands.CreateCommand("hello")
				.Do(async (e) =>
					{
						await e.Channel.SendMessage("Hi Bitch!");
					});

			commands.CreateCommand("help")
				.Do(async (e) =>
					{
						await e.Channel.SendMessage("Do I look like the kind of bot that gives help?");
					});
			commands.CreateCommand("help")
			   .Do(async (e) =>
			   {
				   await e.Channel.SendMessage("Do I look like the kind of bot that gives help?");
			   });

			discord.ExecuteAndWait(async () =>
			{
				await discord.Connect("MzE4NTk4NzE4MTYzMjU1Mjk4.DDISOw.s3-TBtxlDop7KUMx3N7O6s2rMAY", TokenType.Bot);
			});
		}

		/* private void RegisterMemeCommand()
		 {
			 commands.CreateCommand("show me what you got")
				 .Do(async (e) =>
				 {

					 await e.Channel.SendMessage("I got a lot of memes, most of em dank, but this one about the toilet seat is the only one I know how to post.");
					 await e.Channel.SendFile("mem/test.jpg");
				 });

		 }*/

		private void Log(object sender, LogMessageEventArgs e)
		{
			Console.WriteLine(e.Message);
		}
	}
}