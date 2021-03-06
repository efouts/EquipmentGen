﻿using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Items.Magical
{
    [TestFixture]
    public class WondrousItemGeneratorTests : StressTests
    {
        [Inject, Named(ItemTypeConstants.WondrousItem)]
        public IMagicalItemGenerator WondrousItemGenerator { get; set; }

        [Test]
        public void StressedWondrousItemGenerator()
        {
            StressGenerator();
        }

        protected override void MakeAssertions()
        {
            var power = GetNewPower(false);
            var item = WondrousItemGenerator.GenerateAtPower(power);

            if (item.ItemType == ItemTypeConstants.SpecificCursedItem)
                return;

            Assert.That(item.Name, Is.Not.Empty);
            Assert.That(item.Traits, Is.Not.Null);
            Assert.That(item.Attributes, Is.Not.Null);
            Assert.That(item.Quantity, Is.EqualTo(1));
            Assert.That(item.IsMagical, Is.True);
            Assert.That(item.Contents, Is.Not.Null);
            Assert.That(item.ItemType, Is.EqualTo(ItemTypeConstants.WondrousItem));
        }
    }
}