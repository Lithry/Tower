using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class EntityBuilderTest {

    [UnityTest]
    public IEnumerator _1_(){
        
        var entityBuilder = new GameObject();
        var entityBuilderNotCreated = new GameObject();
        yield return new WaitForSeconds(1);
        Assert.IsNull(entityBuilderNotCreated);
    }

    public class BuildMethod
	{
    }
}