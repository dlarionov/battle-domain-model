using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace WildWorld
{
	/// <summary>
	/// Существо, которое может есть других сществ
	/// </summary>
	public abstract class Agressor : Creature
	{
		public Agressor(int hitPoints, int damage, Action<Creature> raceAbility = null, Action<Creature, Creature> fightAbility = null)
			: base(hitPoints, damage, raceAbility, fightAbility) { }

		/// <summary>
		/// Можно ли есть существо
		/// </summary>
		/// <param name="target"></param>
		/// <returns></returns>
		abstract protected bool CanEat(Creature target);

		/// <summary>
		/// Съесть существо
		/// </summary>
		/// <param name="target">кого съесть</param>
		/// <returns>успешно ли съедено</returns>
		public bool TryEat(Creature target)
		{
			if (CanEat(target))
			{
				Trace.WriteLine(string.Format("{0} хочет съесть {1}", this, target));

				// проверяем, кто победил в сражении
				var result = ReferenceEquals(this, this.Fight(target));

				if (result)
				{
					Trace.WriteLine(string.Format("{0} cъел {1}", this, target));
				}
				else
				{
					Trace.WriteLine(string.Format("У {0} не вышло съесть {1}", this, target));
				}

				return result;
			}
			else
			{
				Trace.WriteLine(string.Format("{0} не может есть {1}", this, target));
				return false;
			}
		}

		/// <summary>
		/// Съесть последовательно группу существ
		/// </summary>
		/// <param name="creatures">коллекция существ</param>
		/// <returns>успешно ли съели всю группу</returns>
		public bool TryEat(IEnumerable<Creature> creatures)
		{
			Trace.WriteLine(string.Format("{0} хочет съесть группу существ", this));

			foreach (var i in creatures)
			{
				if (!TryEat(i))
				{
					return false;
				}
			}

			Trace.WriteLine(string.Format("{0} съел группу существ", this));
			return true;
		}
	}
}
