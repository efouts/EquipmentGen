﻿using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Generation.Generators
{
    [TestFixture]
    public class PowerArmorGeneratorTests : StressTest
    {
        [Inject]
        public IPowerGearGeneratorFactory PowerGearGeneratorFactory { get; set; }

        private IPowerGearGenerator powerArmorGenerator;

        [SetUp]
        public void Setup()
        {
            powerArmorGenerator = PowerGearGeneratorFactory.CreateWith(ItemsConstants.ItemTypes.Armor);
            StartTest();
        }

        [TearDown]
        public void TearDown()
        {
            StopTest();
        }

        [Test]
        public void PowerArmorGeneratorReturnsArmor()
        {
            while (TestShouldKeepRunning())
            {
                var power = GetNewPower();
                var armor = powerArmorGenerator.GenerateAtPower(power);

                Assert.That(armor, Is.Not.Null);
                Assert.That(armor.Name, Is.Not.Empty);
                Assert.That(armor.MagicalBonus, Is.Not.Negative);
                Assert.That(armor.Abilities, Is.Not.Null);
                Assert.That(armor.Traits, Is.Not.Null);
            }

            AssertIterations();
        }
    }
}