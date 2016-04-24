using System.Collections.Generic;
using System.Linq;

namespace WildWorld
{
	/// <summary>
	/// Механика сражения группа на группу
	/// </summary>
	public class Battle
	{
		IEnumerable<Creature> _agressors;
		IEnumerable<Creature> _defenders;

		public Battle(IEnumerable<Creature> agressors, IEnumerable<Creature> defenders)
		{
			_agressors = agressors;
			_defenders = defenders;
		}

		public bool Start()
		{
			return _agressors.Select((с) =>
			{
				return с.Fight(_defenders.Where(t => t.Alive));
			}).Reverse().Take(1).First();
		}
	}
}
