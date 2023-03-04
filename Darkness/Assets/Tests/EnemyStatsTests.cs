using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class EnemyStatsTests
{
    [UnityTest]
    public IEnumerator CheckMaxHealth()
    {
        var gameObject = new GameObject();
        var gameObjectPlaceholder = new GameObject();

        var enemy = gameObject.AddComponent<EnemyStats>();
        var player = gameObjectPlaceholder.tag = "Player";

        enemy.maxHealth = 10;

        yield return new WaitForFixedUpdate();

        Assert.AreEqual(expected: 10, actual: enemy.maxHealth);
    }
    
    [UnityTest]
    public IEnumerator CheckHealth()
    {
        var gameObject = new GameObject();
        var gameObjectPlaceholder = new GameObject();

        var enemy = gameObject.AddComponent<EnemyStats>();
        var player = gameObjectPlaceholder.tag = "Player";

        enemy.maxHealth = 10;
        enemy.health = 5;

        yield return new WaitForFixedUpdate();

        Assert.AreEqual(expected: 10, actual: enemy.health);
    }
    
    [UnityTest]
    public IEnumerator CheckDamage()
    {
        var gameObject = new GameObject();
        var gameObjectPlaceholder = new GameObject();

        var enemy = gameObject.AddComponent<EnemyStats>();
        var player = gameObjectPlaceholder.tag = "Player";

        enemy.maxHealth = 10;
        enemy.health = 5;
        enemy.damage = 3;

        yield return new WaitForFixedUpdate();

        Assert.AreEqual(expected: 3, actual: enemy.damage);
    }
}
