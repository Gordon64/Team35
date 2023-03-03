using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestSuite
{

    //GameObject inventoryPrefab = Inventory.Load<GameObject>("InventoryItem");
    
    // A Test behaves as an ordinary method
    [Test]
    public void TestSuiteSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    //Test that the hero will have gravity and be positioned correctly on screen
    [UnityTest]
    public IEnumerator TestHeroGravity()
    {
        var hero = new GameObject();
        hero.AddComponent<Rigidbody>();
        var startPos = hero.transform.position.y;
        yield return new WaitForFixedUpdate();
        Assert.AreNotEqual(startPos, hero.transform.position.y);

    }
}
 