﻿using EquipmentGen.Generators.Interfaces.Goods;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Coins
{
    [TestFixture]
    public class GoodsGeneratorTests : StressTests
    {
        [Inject]
        public IGoodsGenerator GoodsGenerator { get; set; }

        [SetUp]
        public void Setup()
        {
            StartTest();
        }

        [TearDown]
        public void TearDown()
        {
            StopTest();
        }

        [Test]
        public void StressedGoodsGenerator()
        {
            while (TestShouldKeepRunning())
            {
                var level = GetNewLevel();
                var goods = GoodsGenerator.GenerateAtLevel(level);

                Assert.That(goods, Is.Not.Null);

                foreach (var good in goods)
                {
                    Assert.That(good.Description, Is.Not.Empty);
                    Assert.That(good.ValueInGold, Is.GreaterThanOrEqualTo(0));
                }
            }

            AssertIterations();
        }
    }
}