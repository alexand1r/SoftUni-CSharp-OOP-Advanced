using System;
using Moq;
using NUnit.Framework;
using Skeleton;

[TestFixture]
class HeroTests
{
    private const string HeroName = "Pesho";

    [Test]
    public void HeroGainsExperienceAfterAttackIfTargetDies()
    {
        Mock<ITarget> fakeTarget = new Mock<ITarget>();
        fakeTarget.Setup(p => p.Health).Returns(0);
        fakeTarget.Setup(p => p.GiveExperience()).Returns(20);
        fakeTarget.Setup(p => p.IsDead()).Returns(true);
        Mock<IWeapon> fakeWeapon = new Mock<IWeapon>();
        Hero hero = new Hero("Pesho", fakeWeapon.Object);
        hero.attack(fakeTarget.Object);
        Assert.AreEqual(20, hero.Experience);

        //ITarget fakeTarget = new FakeTarget();
        //IWeapon fakeWeapon = new FakeWeapon();
        //Hero hero = new Hero(HeroName, fakeWeapon);
        //hero.attack(fakeTarget);

        //// Assert…
        //Assert.AreEqual(20, hero.Experience, "Hero dosn't get XP when killing.");
    }
}

