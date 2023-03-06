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

    [UnityTest]
    public IEnumerator TestTurnSystem()
    {
        GameObject player = new GameObject();
        player.AddComponent<UnitStats>();
        player.tag = "PlayerUnit";
        GameObject enemy = new GameObject();
        enemy.AddComponent<UnitStats>();
        enemy.tag = "EnemyUnit";

        GameObject turnsystem = new GameObject();
        turnsystem.AddComponent<TurnSystem>();
        TurnSystem turnComp = turnsystem.GetComponent<TurnSystem>();
        yield return 0;

        List<UnitStats> expectedTurnOrder = new List<UnitStats> { enemy.GetComponent<UnitStats>(), player.GetComponent<UnitStats>() };
        List<UnitStats> actualTurnOrder = turnComp.unitsStats;

        Assert.AreEqual(expectedTurnOrder.Count, actualTurnOrder.Count);

        for(int i = 0; i < expectedTurnOrder.Count; i++)
        {
            Assert.AreEqual(expectedTurnOrder[i], actualTurnOrder[i]);
        }
    }
}
