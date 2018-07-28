using UnityEngine;
using NUnit.Framework;

public class PlayerTest {

	public class AttackMethod{

		private Player player;
		private WeaponManager weaponManager;
		private Weapon weapon;

		[SetUp]
		public void BeforeEveryTest(){
			player = new GameObject().AddComponent<Player>();
			weaponManager = new GameObject().AddComponent<WeaponManager>();
			weapon = new GameObject().AddComponent<Weapon>();
		}

		[Test]
		public void _1_Attack_Return_True_If_Exit_After_Attacking(){
			weapon.Build();
			weaponManager.Build(weapon);
			player.SetWeaponManager(weaponManager);
			bool target = player.Attack();

			Assert.IsTrue(target);
		}

		[Test]
		public void _2_Attack_Return_False_If_Exit_In_Failure(){
			weapon.Build(10.0f);
			weaponManager.Build(weapon);
			player.SetWeaponManager(weaponManager);
			bool target = player.Attack();

			Assert.IsFalse(target);
		}
	}
}
