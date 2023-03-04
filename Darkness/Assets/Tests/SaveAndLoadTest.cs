using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class SaveAndLoadTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void CheckData()
    {
        int check = 10;
        SavedInfo script = new SavedInfo();

        int health = script.health;


        Assert.AreEqual(check, health);
    }
}