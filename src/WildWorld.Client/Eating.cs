using System.Collections.Generic;
using System.Linq;

namespace WildWorld
{
	/// <summary>
	/// Механика поедания группой существ, другой группы существ
	/// </summary>
	public class Eating
	{
		IEnumerable<Agressor> _agressors;
		IEnumerable<Creature> _defenders;

		public Eating(IEnumerable<Agressor> agressors, IEnumerable<Creature> defenders)
		{
			_agressors = agressors;
			_defenders = defenders;
		}

		public bool Start()
		{
			return _agressors.Select((s) =>
			{
				return s.TryEat(_defenders.Where(t => t.Alive));
			}).Reverse().Take(1).First();
		}
	}
}
