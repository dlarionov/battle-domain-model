using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WildWorld.Tests
{
	[TestClass]
	public class Scenarios
	{
		/// <summary>
		/// Гоблин съел овцу.
		/// </summary>
		[TestMethod]
		public void Test1()
		{
			var troll = new Troll();
			var sheep = new Sheep();

			var result = troll.TryEat(sheep);

			Assert.IsTrue(result);
			Assert.IsTrue(troll.Alive);
			Assert.IsFalse(sheep.Alive);
		}

		/// <summary>
		/// Два гоблина подрались из-за овцы. Победитель съел овцу.
		/// </summary>
		[TestMethod]
		public void Test2()
		{
			var orc = new Troll(Race.Orc);
			var human = new Troll(Race.Human);
			var sheep = new Sheep();

			var winner = (Agressor)orc.Fight(human);
			var result = winner.TryEat(sheep);

			Assert.IsTrue(result);
			Assert.IsTrue(orc.Alive || human.Alive);
			Assert.IsFalse(orc.Alive && human.Alive);
		}

		/// <summary>
		/// Огр попытался съесть группу гоблинов, но не смог.
		/// </summary>
		[TestMethod]
		public void Test3()
		{
			var ogre = new Ogre(Race.Orc);
			var troll = new Troll(Race.Human);
			var gangOfTrolls = new Troll[]
			{ 
				new Troll(),
				new Troll(),
				new Troll(),
				troll
			};

			var result = ogre.TryEat(gangOfTrolls);

			Assert.IsFalse(result);
			Assert.IsFalse(ogre.Alive);
			Assert.IsTrue(troll.Alive);
		}

		/// <summary>
		/// Группа огров успешно съели группу гоблинов.
		/// </summary>
		[TestMethod]
		public void Test4()
		{
			var ogre = new Ogre();
			var troll = new Troll();
			var eating = new Eating(
				new Ogre[]
				{ 
					new Ogre(),
					ogre
				},
				new Troll[]
				{ 
					new Troll(),
					new Troll(),
					troll
				});

			var result = eating.Start();

			Assert.IsTrue(result);
			Assert.IsTrue(ogre.Alive);
			Assert.IsFalse(troll.Alive);
		}

		/// <summary>
		/// Два огра попытались съесть гоблина с волшебным мечом, но не смогли.
		/// </summary>
		[TestMethod]
		public void Test5()
		{
			var ogre = new Ogre(Race.Human);
			var troll = new Troll(Race.Orc, Weapon.MagicSword);
			var eating = new Eating(
				new Ogre[]
				{ 
					new Ogre(Race.Human),
					ogre
				},
				new Troll[] 
				{ 
					troll
				});

			var result = eating.Start();

			Assert.IsFalse(result);
			Assert.IsFalse(ogre.Alive);
			Assert.IsTrue(troll.Alive);
		}

		/// <summary>
		/// Стадо овец и группа гоблинов дерётся с двумя ограми и побеждает.
		/// </summary>
		[TestMethod]
		public void Test6()
		{
			var ogre = new Ogre(Race.Orc);
			var troll = new Troll();
			var battle = new Battle(
				new Creature[]
				{ 
					new Sheep(),
					new Sheep(),
					new Troll(),
					new Troll(),
					new Sheep(),
					troll
				},
				new Ogre[]
				{ 
					new Ogre(Race.Human),
					ogre
				});

			var result = battle.Start();

			Assert.IsTrue(result);
			Assert.IsFalse(ogre.Alive);
			Assert.IsTrue(troll.Alive);
		}
	}
}
