using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEditor;

public class PlayerTest {

	public class AttackMethod{

		private Player player;
		private EntityFactory entityFactory;
		private EntityBuilder entityBuilder;
		private WeaponFactory weaponFactory;
		private WeaponBuilder weaponBuilder;
		


		[SetUp]
		public void BeforeEveryTest(){
			entityFactory = new GameObject().AddComponent<EntityFactory>();
			entityBuilder = new GameObject().AddComponent<EntityBuilder>();
			weaponFactory = new GameObject().AddComponent<WeaponFactory>();
			weaponBuilder = new GameObject().AddComponent<WeaponBuilder>();
		}

		[UnityTest]
		public IEnumerator _1_Attack_Return_True_If_Exit_After_Attacking(){
			player = entityBuilder.Build(TypeOfEntity.Player, TypeOfWeapon.Empty).GetComponent<Player>();
			yield return new WaitForSeconds(0.5f);

			bool target = player.Attack();

			Assert.IsTrue(target);
		}

		[UnityTest]
		public IEnumerator _2_Attack_Return_False_If_Exit_In_Failure(){
			player = entityBuilder.Build(TypeOfEntity.Player, TypeOfWeapon._1000sReloadToTest).GetComponent<Player>();
			yield return null;

			bool target = player.Attack();

			Assert.IsFalse(target);
		}

		[TearDown]
		public void AfterEveryTest(){
			if (player != null) Object.Destroy(player.gameObject);
			if (entityFactory != null)	Object.Destroy(entityFactory.gameObject);
			if (entityBuilder != null)	Object.Destroy(entityBuilder.gameObject);
			if (weaponFactory != null)	Object.Destroy(weaponFactory.gameObject);
			if (weaponBuilder != null)	Object.Destroy(weaponBuilder.gameObject);
		}
	}
}
