using System;

namespace WildWorld
{
	/// <summary>
	/// Умение
	/// </summary>
	public static class Skill
	{
		/// <summary>
		/// Выживание
		/// </summary>
		/// <param name="creature"></param>
		public static void Surival(Creature creature)
		{
			creature.HitPoints = creature.HitPoints + 1;
		}

		/// <summary>
		/// Драка
		/// </summary>
		/// <param name="creature"></param>
		public static void Combat(Creature creature)
		{
			creature.Damage = creature.Damage + 1;
		}
	}
}
