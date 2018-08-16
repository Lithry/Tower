using UnityEngine;
using NUnit.Framework;

public class MeleeWeaponTest {
	public class AttackMethod{
		private MeleeWeapon target;

		[SetUp]
		public void BeforeEveryTest(){
			target = new GameObject().AddComponent<MeleeWeapon>();
		}

		[Test]
		public void _1_Attack_Must_Put_BoxCollider2D_Enabled_To_True(){
			target.Build(Vector2.one);
			target.Attack();
			Assert.IsTrue(target.areaOfEffect.enabled);
		}

		[Test]
		public void _2_BoxCollider2D_Enabled_Must_Change_To_False_After_Required_Time(){
			target.Build(Vector2.one);
			target.Attack();
			Assert.IsTrue(target.IsInvoking("ChangeEnabledToFalse"));
		}
	}
}
