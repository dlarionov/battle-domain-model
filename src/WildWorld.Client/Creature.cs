using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace WildWorld
{
	/// <summary>
	/// Базовый класс для всех существ
	/// </summary>
	public abstract class Creature
	{
		/// <summary>
		/// Здоровье
		/// </summary>
		public int HitPoints { get; set; }

		/// <summary>
		/// Урон
		/// </summary>
		public int Damage { get; set; }

		/// <summary>
		/// Живо ли существо
		/// </summary>
		public bool Alive { get { return HitPoints > 0; } }

		Action<Creature, Creature> _fightAbility;

		/// <summary>
		/// Существо
		/// </summary>
		/// <param name="hitPoints">Здоровье</param>
		/// <param name="damage">Урон</param>
		/// <param name="raceAbility">Рассовая способность (применяется в момент создания существа)
		/// Параметр - существо, к которому применяются рассовые способности</param>
		/// <param name="fightAbility"> Дополнительная способность (применяется при каждой атаке существа)
		/// Первый параметр - это ссылка текущее существо
		/// Второй параметр - это ссылка на цель, которую атакует текущее существо</param>
		public Creature(int hitPoints, int damage,
			Action<Creature> raceAbility = null,
			Action<Creature, Creature> fightAbility = null)
		{
			HitPoints = hitPoints;
			Damage = damage;

			if (raceAbility != null)
			{
				raceAbility(this);
			}

			_fightAbility = fightAbility;
		}

		/// <summary>
		/// Сразиться с существом
		/// </summary>
		/// <param name="target">цель</param>
		/// <returns>победитель</returns>
		public Creature Fight(Creature target)
		{
			target.HitPoints = target.HitPoints - this.Damage;
			Trace.WriteLine(string.Format("{0} нанес {1} {2} ед. урона.", this, target, this.Damage));

			if (this._fightAbility != null)
			{
				_fightAbility(this, target);
			}

			if (target.Alive)
			{
				// существа атакуют друг друга по очереди, пока кто-нибудь не умрет
				return target.Fight(this);
			}
			else
			{
				Trace.WriteLine(string.Format("В бою победил {0}", this));
				return this;
			}
		}

		/// <summary>
		/// Сразиться с группой существ
		/// </summary>
		/// <param name="creatures">коллекция существ</param>
		/// <returns>выйгран ли бой</returns>
		public bool Fight(IEnumerable<Creature> creatures)
		{
			foreach (var i in creatures)
			{
				// если хоть раз победителем вышло другое существо, бой проигран
				if (!ReferenceEquals(this, Fight(i)))
				{
					return false;
				}
			}

			return true;
		}
	}
}
