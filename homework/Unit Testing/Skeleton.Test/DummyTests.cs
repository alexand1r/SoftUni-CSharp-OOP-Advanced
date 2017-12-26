using System;
using NUnit.Framework;

[TestFixture]
class DummyTests
{
    private const int DummyHealth = 20;
    private const int DummyXP = 10;
    private Dummy dummy;

    [SetUp]
    public void TestInit()
    {
        this.dummy = new Dummy(DummyHealth, DummyXP);
    }

    [Test]
    public void DummyLosesHealthAfterAttack()
    {
        // Act
        dummy.TakeAttack(5);

        // Assert
        Assert.AreEqual(15, dummy.Health, "Dummy doesn't take damage when attacked.");
    }

    [Test]
    public void DummyThrowsExceptionWhenIsDead()
    {
        dummy.TakeAttack(20);

        var ex = Assert.Throws<InvalidOperationException>
            (() => dummy.TakeAttack(20));
        Assert.That(ex.Message, Is.EqualTo("Dummy is dead."));
    }

    [Test]
    public void DeadDummyCanGiveXP()
    {
        dummy.TakeAttack(20);

        Assert.AreEqual(10, dummy.GiveExperience(), "Dead dummy doesn't give XP.");
    }

    [Test]
    public void AliveDummyCanNotGiveXP()
    {
        var ex = Assert.Throws<InvalidOperationException>
            (() => dummy.GiveExperience());

        Assert.That(ex.Message, Is.EqualTo("Target is not dead."));
    }
}