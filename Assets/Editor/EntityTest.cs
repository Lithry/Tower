using UnityEngine;
using NUnit.Framework;

public class EntityTest
{
	public class SetHealthAndMaxHealthMethod
	{
		private Entity target;

		[SetUp]
		public void BeforeEveryTest(){
			target = new GameObject().AddComponent<Entity>();
		}

		[Test]
		public void _1_Can_Not_Recive_0_Health(){
			Assert.Throws<System.ArgumentOutOfRangeException>(() => target.SetHealthAndMaxHealth(0));
		}
		
		[Test]
		public void _2_Can_Not_Recive_Negative_Health(){
			Assert.Throws<System.ArgumentOutOfRangeException>(() => target.SetHealthAndMaxHealth(-1));
		}

		[Test]
		public void _3_Max_Health_Can_Not_Be_Smaller_Than_Health(){
			target.SetHealthAndMaxHealth(2, 1);

			Assert.AreEqual(2, target.maxHealth);
		}
	}

    public class DamageMethod
    {
		private Entity target;

		[SetUp]
		public void BeforeEveryTest(){
			target = new GameObject().AddComponent<Entity>();
		}

        [Test]
        public void _1_Can_Not_Recive_Null_Damage()
        {
            target.SetHealthAndMaxHealth(1);
			Assert.Throws<System.ArgumentOutOfRangeException>(() => target.ReciveDamage(0));
        }

		[Test]
		public void _2_Recive_Posible_Damage()
		{
			target.SetHealthAndMaxHealth(2);
            target.ReciveDamage(1);

            Assert.AreEqual(1, target.health);
		}

		[Test]
        public void _3_Can_Not_Recive_Overkill_Damage()
        {
            target.SetHealthAndMaxHealth(1);
            target.ReciveDamage(2);

            Assert.AreEqual(0, target.health);
        }

		[Test]
        public void _4_Can_Not_Recive_Negative_Damage()
        {
            target.SetHealthAndMaxHealth(1);
			Assert.Throws<System.ArgumentOutOfRangeException>(() => target.ReciveDamage(-1));
        }
    }

	public class HealMethod
    {
		private Entity target;

		[SetUp]
		public void BeforeEveryTest(){
			target = new GameObject().AddComponent<Entity>();
		}

		[Test]
        public void _1_Can_Not_Recive_Null_Heal()
        {
            target.SetHealthAndMaxHealth(1);
			Assert.Throws<System.ArgumentOutOfRangeException>(() => target.Heal(0));
        }

		[Test]
		public void _2_Recive_Posible_Heal()
		{
			target.SetHealthAndMaxHealth(1, 2);
            target.Heal(1);

            Assert.AreEqual(2, target.health);
		}

		[Test]
		public void _3_Can_Not_Recive_More_Health_than_Max_Health()
		{
			target.SetHealthAndMaxHealth(1, 2);
            target.Heal(2);

            Assert.AreEqual(2, target.health);
		}

		[Test]
        public void _4_Can_Not_Recive_Negative_Heal()
        {
            target.SetHealthAndMaxHealth(1);
			Assert.Throws<System.ArgumentOutOfRangeException>(() => target.Heal(-1));
        }
    }
}
