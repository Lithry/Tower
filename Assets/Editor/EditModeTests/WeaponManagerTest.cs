using UnityEngine;
using NUnit.Framework;

public class WeaponManagerTest {

	public class AttackMethod{
		private WeaponManager target;
		private Weapon weapon;

		[SetUp]
		public void BeforeEveryTest(){
			target = new GameObject().AddComponent<WeaponManager>();
			weapon = new GameObject().AddComponent<Weapon>();
		}

		[Test]
		public void _1_Attack_Return_True_If_Exit_After_Attacking(){
			weapon.Build();
			target.Build(weapon, TypeOfWeapon.Fist);
			Assert.IsTrue(target.Attack());
		}

		[Test]
		public void _2_Attack_Return_False_If_Exit_In_Failure(){
			weapon.Build(10.0f);
			target.Build(weapon, TypeOfWeapon.Fist);
			Assert.IsFalse(target.Attack());
		}
	}
}
