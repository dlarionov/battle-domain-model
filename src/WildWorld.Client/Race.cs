using System;

namespace WildWorld
{
	/// <summary>
	/// Рассовая способность
	/// </summary>
	public static class Race
	{
		/// <summary>
		/// Орки толстые
		/// </summary>
		/// <param name="creature"></param>
		public static void Orc(Creature creature)
		{
			creature.HitPoints = creature.HitPoints + 1;
		}

		/// <summary>
		/// Люди наносят больший урон
		/// </summary>
		/// <param name="creature"></param>
		public static void Human(Creature creature)
		{
			creature.Damage = creature.Damage + 1;
		}
	}
}
