using System;
using System.Collections.Generic;
using NUnit.Framework;

public class HeroRepositoryTests
{
    [Test]
    public void TestConstructor()
    {
        HeroRepository repository = new HeroRepository();
        Assert.IsNotNull(repository);
    }
    [Test]
    public void TestCollection()
    {
        HeroRepository repository = new HeroRepository();
        CollectionAssert.AreEqual(repository.Heroes, new List<Hero>());
    }
    [Test]
    public void TestCreateWithNullHero()
    {
        HeroRepository repository = new HeroRepository();
        Assert.Throws<ArgumentNullException>(() =>
        {
            repository.Create(null);
        });
    }
    [Test]
    public void TestCreateWithAlreadyCreatedHero()
    {
        HeroRepository repository = new HeroRepository();
        repository.Create(new Hero("Name",100));
        Assert.Throws<InvalidOperationException>(() =>
        {
            repository.Create(new Hero("Name",45));
        });
    }
    [Test]
    public void TestCreate()
    {
        HeroRepository repository = new HeroRepository();
        var hero = new Hero("Name", 100);
        string result = repository.Create(hero);
        Assert.AreEqual(result, $"Successfully added hero Name with level 100");
        CollectionAssert.AreEqual(repository.Heroes,new List<Hero>() { hero });
    }
    [TestCase(null)]
    [TestCase("")]
    [TestCase(" ")]
    public void TestRemoveWithNullOrWhitespaceName(string name)
    {
        HeroRepository repository = new HeroRepository();
        Assert.Throws<ArgumentNullException>(() =>
        {
            repository.Remove(name);
        });
    }
    [Test]
    public void TestRemoveWithNonExistingHero()
    {
        HeroRepository repository = new HeroRepository();
        bool result = repository.Remove("Name");
        Assert.IsFalse(result);
    }
    [Test]
    public void TestRemoveWithExistingHero()
    {
        HeroRepository repository = new HeroRepository();
        repository.Create(new Hero("Name", 100));
        bool result = repository.Remove("Name");
        Assert.IsTrue(result);
        Assert.AreEqual(repository.Heroes.Count, 0);
    }
    [Test]
    public void TestHeroWithTheHigestLevel()
    {
        HeroRepository repository = new HeroRepository();
        var heroWithTheHighestLevel = new Hero("Vladko", 1000);
        repository.Create(new Hero("Name", 100));
        repository.Create(heroWithTheHighestLevel);
        repository.Create(new Hero("Acheto", 500));
        var hero =  repository.GetHeroWithHighestLevel();
        Assert.AreEqual(hero, heroWithTheHighestLevel);
    }
    [Test]
    public void GetHeroWithExistingHero()
    {
        HeroRepository repository = new HeroRepository();
        var heroThatShoulBeGotten = new Hero("Name", 100);
        repository.Create(heroThatShoulBeGotten);
        var hero = repository.GetHero("Name");
        Assert.AreEqual(hero, heroThatShoulBeGotten);
    }
    [Test]
    public void GetHeroWithNonExistingHero()
    {
        HeroRepository repository = new HeroRepository();
        var hero = repository.GetHero("Name");
        Assert.IsNull(hero);
    }

}