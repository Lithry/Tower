using UnityEngine;
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

        [TearDown]
		public void AfterEveryTest(){
			GameObject[] ent = GameObject.FindGameObjectsWithTag("EntityFactory");
            foreach (GameObject factory in ent){
                Object.Destroy(factory);
            }
		}

    public class CreateMethod{
        [UnityTest]
        public IEnumerator _1_Entity_Factory_Return_Not_Null_GameObject() {
            EntityFactory entityFactory = new GameObject().AddComponent<EntityFactory>();
			entityFactory.Create(TypeOfEntity.Player);
            
			yield return null;

			GameObject target = GameObject.FindWithTag("Entity");
			Assert.IsNotNull(target);
        }

        [TearDown]
		public void AfterEveryTest(){
			GameObject[] factories = GameObject.FindGameObjectsWithTag("EntityFactory");
            foreach (GameObject factory in factories){
                Object.Destroy(factory);
            }
            GameObject[] entities = GameObject.FindGameObjectsWithTag("Entity");
            foreach (GameObject entity in entities){
                Object.Destroy(entity);
            }
		}
    }
}
