using UnityEngine;
using NUnit.Framework;

public class WeaponTest {

	public class AttackMethod{
		private Weapon target;

		[SetUp]
		public void BeforeEveryTest(){
			target = new GameObject().AddComponent<Weapon>();
		}

		[Test]
		public void _1_Attack_Return_True_If_Exit_After_Attacking(){
			target.Build();
			Assert.IsTrue(target.Attack());
		}

		[Test]
		public void _2_Attack_Return_False_If_Exit_In_Failure(){
			target.Build(10.0f);
			Assert.IsFalse(target.Attack());
		}

		[Test]
		public void _3_Time_Of_Attack_Corresponds_With_Last_Attack(){
			target.Build();
			float beforeAttack = target.timeOfShot;
			target.Attack();
			Assert.Greater(target.timeOfShot, beforeAttack);
		}
	}
}
