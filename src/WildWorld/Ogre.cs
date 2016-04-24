using System;

namespace WildWorld
{
	/// <summary>
	/// Огр
	/// </summary>
	public class Ogre : Agressor
	{
		public Ogre(Action<Creature> raceAbility = null, Action<Creature, Creature> fightAbility = null)
			: base(4, 1, raceAbility, fightAbility) { }

		protected override bool CanEat(Creature target)
		{
			return target is Troll || target is Sheep;
		}
	}
}
