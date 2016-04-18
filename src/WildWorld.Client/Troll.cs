using System;

namespace WildWorld
{
	/// <summary>
	/// Гоблин
	/// </summary>
	public class Troll : Agressor
	{
		public Troll(Action<Creature> raceAbility = null, Action<Creature, Creature> fightAbility = null)
			: base(3, 1, raceAbility, fightAbility) { }

		protected override bool CanEat(Creature target)
		{
			return target is Troll || target is Sheep;
		}
	}
}
