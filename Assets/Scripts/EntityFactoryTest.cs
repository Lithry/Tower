﻿using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEditor;


public class EntityFactoryTest {

	[UnityTest]
    public IEnumerator _1_Can_Not_Be_More_Than_1_Entity_Factory() {
        EntityFactory entityFactory1 = new GameObject().AddComponent<EntityFactory>();
        entityFactory1.tag = "EntityFactory";
        EntityFactory entityFactory2 = new GameObject().AddComponent<EntityFactory>();
        entityFactory2.tag = "EntityFactory";

        yield return null;

        GameObject[] target = GameObject.FindGameObjectsWithTag("EntityFactory");
        Assert.AreEqual(1, target.Length);
    }

    public class CreateMethod{
        [UnityTest]
        public IEnumerator _1_Entity_Factory_Return_Not_Null_GameObject() {
            EntityFactory entityFactory = new GameObject().AddComponent<EntityFactory>();
            var prefab = Resources.Load("Entity/Entity");
			entityFactory.SetPrefab(prefab);
			entityFactory.Create(TypeOfEntity.Player);
            
			yield return null;

			GameObject target = GameObject.FindWithTag("Entity");
			Assert.IsNotNull(target);
        }
    }
}
