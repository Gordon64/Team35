using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class InputTests
{
    [Test]
    public void HorizontalMovement()
    {
        Assert.AreEqual(expected: 0.0f, actual: Input.GetAxis("Horizontal"));
    }

    [Test]
    public void Jump()
    {
        Assert.AreEqual(expected: false, actual: Input.GetKeyDown("space"));
    }
}
