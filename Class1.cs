using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using TerrariaApi.Server;
using TShockAPI;

namespace bosschecklist
{
	[ApiVersion(2, 1)]

	public class bosschecklist : TerrariaPlugin
	{
		public override string Name
		{
			get { return "Bosscheck list"; }
		}

		public override string Author
		{
			get { return "Updated by comdar"; }
		}

		public override string Description
		{
			get { return "Check if bosses are killed or not."; }
		}

		public string HelpText { get; private set; }

		public bosschecklist(Main game)
			: base(game)
		{
			Order = +4;
		}

		public override void Initialize()
		{
			Commands.ChatCommands.Add(new Command("bosscheck", bosscheck, "bosscheck"));
		}

		public void bosscheck(CommandArgs args)
		{
			var killed = "([c/FF0000:Killed.])";
			var alive = "([c/00FF00:Not killed.])";
			StringBuilder sb = new StringBuilder();
			sb.Append("Eye of Cthulu " + (NPC.downedBoss1 ? killed : alive));
			sb.Append(", King Slime " + (NPC.downedSlimeKing ? killed : alive));
			if (WorldGen.crimson)
			{
				sb.Append(", Brain of Cthulu " + (NPC.downedBoss2 ? killed : alive));
			}
			else
			{
				sb.Append(", Eater of World " + (NPC.downedBoss2 ? killed : alive));
			}
			sb.Append(", Skeletron " + (NPC.downedBoss3 ? killed : alive));
			sb.Append(", Wall of Flesh " + (Main.hardMode ? killed : alive));
			sb.Append(", Deerclops " + (NPC.downedDeerclops ? killed : alive));
			sb.Append(", Queen Slime " + (NPC.downedQueenSlime ? killed : alive));
			sb.Append(", The Destroyer " + (NPC.downedMechBoss1 ? killed : alive));
			sb.Append(", The Twins " + (NPC.downedMechBoss2 ? killed : alive));
			sb.Append(", Skeletron Prime " + (NPC.downedMechBoss3 ? killed : alive));
			sb.Append(", Duke of Fishron " + (NPC.downedFishron ? killed : alive));
			sb.Append(", Golem " + (NPC.downedGolemBoss ? killed : alive));
			sb.Append(", Plantera " + (NPC.downedPlantBoss ? killed : alive));
			sb.Append(", Empress of Light " + (NPC.downedEmpressOfLight ? killed : alive));
			sb.Append(", Lunatic Cultist " + (NPC.downedAncientCultist ? killed : alive));
			sb.Append(", Moon Lord " + (NPC.downedMoonlord ? killed : alive));
			args.Player.SendInfoMessage(sb.ToString());
		}
	}
}
