﻿using D20Dice;
using EquipmentGen.Core.Generation.Factories;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Factories
{
    [TestFixture]
    public class TreasureFactoryTests
    {
        private Mock<IDice> mockDice;
        private ITreasureFactory factory;

        [SetUp]
        public void Setup()
        {
            mockDice = new Mock<IDice>();
            factory = new TreasureFactory(mockDice.Object);
        }

        [Test]
        public void TreasureFactoryReturnsTreasure()
        {
            var treasure = factory.CreateWith(1);
            Assert.That(treasure, Is.Not.Null);
        }

        [Test]
        public void CoinIsSet()
        {
            var treasure = factory.CreateWith(1);
            Assert.That(treasure.Coin, Is.Not.Null);
        }

        [Test]
        public void GoodsAreSet()
        {
            var treasure = factory.CreateWith(1);
            Assert.That(treasure.Goods, Is.Not.Null);
        }

        [Test]
        public void ItemsAreSet()
        {
            var treasure = factory.CreateWith(1);
            Assert.That(treasure.Items, Is.Not.Null);
        }
    }
}