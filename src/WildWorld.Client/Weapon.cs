using System;
using System.Diagnostics;

namespace WildWorld
{
	/// <summary>
	/// Боевые способности
	/// </summary>
	public static class Weapon
	{
		/// <summary>
		/// Магический меч - хилит и дамажит
		/// </summary>
		public static Action<Creature, Creature> MagicSword
		{
			get
			{
				return (s, t) =>
				{
					s.HitPoints = s.HitPoints + 1;
					t.HitPoints = t.HitPoints - 4;
					Trace.WriteLine(string.Format("{0} нанес {1} {2} ед. урона волшебным мечом и восполнил {3} ед. здоровья.", s, t, 4, 1));
				};
			}
		}
	}
}