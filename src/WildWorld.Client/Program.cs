using System;
using System.Collections.Generic;
using System.Linq;

namespace WildWorld
{
	class Program
	{
		static void Main(string[] args)
		{
			// + Есть огры, гоблины и овцы. 
			// + Огры могут есть только гоблинов и овец. 
			// + Гоблины могут есть только друг друга и овец. 
			// + Все могут драться. 
			// + Огры и гоблины могут пользоваться оружием. 
			// + Если кто-то пытается съесть кого-то ... происходит драка.
			// + На исход драки влияет раса участников, 
			// + их количество 
			// + и оружие. 

			Test1();
			Test2();
			Test3();
			Test4();
			Test5();
			Test6();

			Console.ReadLine();
		}

		// 1) Гоблин съел овцу
		static void Test1()
		{
			new Troll().Eat(new Sheep());
		}

		// 2) Два гоблина подрались из-за овцы. Победитель съел овцу
		static void Test2()
		{
			(new Troll(Race.Orc).Fight(new Troll(Race.Human)) as Agressor).Eat(new Sheep());
		}

		// 3) Огр попытался съесть группу гоблинов, но не смог
		static void Test3()
		{
			new Ogre().Eat(
				new Troll[]
				{ 
					new Troll(), 
					new Troll(), 
					new Troll(),
					new Troll(), 
					new Troll()
				});
		}

		// 4) Группа огров успешно съели группу гоблинов.
		static void Test4()
		{
			var eating = new Eating(
				new Ogre[]
				{ 
					new Ogre(), 
					new Ogre()
				},
				new Troll[]
				{ 
					new Troll(), 
					new Troll(), 
					new Troll()
				});

			var result = eating.Start();
			if (result)
			{
				Console.WriteLine("Группа огров успешно съела группу гоблинов.");
			}
			else
			{
				Console.WriteLine("Группе огров не удалось съесть группу гоблинов.");
			}
		}

		// 5) Два огра попытались съесть гоблина с волшебным мечом, но не смогли
		static void Test5()
		{
			var eating = new Eating(
				new Ogre[]
				{ 
					new Ogre(Race.Human), 
					new Ogre(Race.Human)
				},
				new Troll[]
				{ 
					// троль с волшебным мечом
					new Troll(Race.Orc, (s, t) =>
					{
						s.HitPoints = s.HitPoints + 1; // волшебный меч прибавляет 1 ед. здоровья
						t.HitPoints = t.HitPoints - 4; // и наносит 4 ед. урона
						Console.WriteLine(string.Format("{0} нанес {1} {2} ед. урона волшебным мечом и восполнил {3} ед. здоровья.", s, t, 4, 1));
					})
				});

			var result = eating.Start();
			if (result)
			{
				Console.WriteLine("Группа огров успешно съела гоблина с волшебным мечом.");
			}
			else
			{
				Console.WriteLine("Группе огров не удалось съесть гоблина с волшебным мечом.");
			}
		}

		// 6) Стадо овец и группа гоблинов дерётся с двумя ограми и побеждает
		static void Test6()
		{
			var battle = new Battle(
				new Creature[]
				{ 
					new Sheep(),
					new Sheep(),
					new Sheep(),
					new Troll(),
					new Troll()
				},
				new Ogre[]
				{ 
					new Ogre(Race.Human), 
					new Ogre(Race.Orc)
				});

			var result = battle.Start();

			if (result)
			{
				Console.WriteLine("Стадо овец и группа гоблинов победили огров.");
			}
			else
			{
				Console.WriteLine("Стадо овец и группа гоблинов проиграли ограм.");
			}
		}
	}
}
