using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class EntityBuilderTest {

    [UnityTest]
    public IEnumerator _1_Can_Not_Be_More_Than_1_Entity_Builder() {
        EntityBuilder entityBuilder1 = new GameObject().AddComponent<EntityBuilder>();
        entityBuilder1.tag = "EntityBuilder";
        EntityBuilder entityBuilder2 = new GameObject().AddComponent<EntityBuilder>();
        entityBuilder2.tag = "EntityBuilder";

        yield return new WaitForSeconds(.5f);

        GameObject[] target = GameObject.FindGameObjectsWithTag("EntityBuilder");
        Assert.AreEqual(1, target.Length);
    }
}
