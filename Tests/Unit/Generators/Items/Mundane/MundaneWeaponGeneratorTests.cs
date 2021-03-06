﻿using System;
using System.Collections.Generic;
using D20Dice;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Mundane;
using EquipmentGen.Generators.Items.Mundane;
using EquipmentGen.Selectors.Interfaces;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generators.Items.Mundane
{
    [TestFixture]
    public class MundaneWeaponGeneratorTests
    {
        private IMundaneItemGenerator mundaneWeaponGenerator;
        private Mock<IPercentileSelector> mockPercentileSelector;
        private Mock<IMundaneItemGenerator> mockAmmunitionGenerator;
        private Mock<ISpecialMaterialGenerator> mockMaterialsSelector;
        private Mock<IAttributesSelector> mockAttributesSelector;
        private Mock<IDice> mockDice;

        [SetUp]
        public void Setup()
        {
            mockDice = new Mock<IDice>();
            mockDice.SetupSequence(d => d.Percentile(1)).Returns(92).Returns(66);

            mockPercentileSelector = new Mock<IPercentileSelector>();
            mockPercentileSelector.Setup(p => p.SelectFrom("MundaneWeapons", 92)).Returns("weapon type");
            mockPercentileSelector.Setup(p => p.SelectFrom("weapon typeWeapons", 66)).Returns("weapon name");

            mockAmmunitionGenerator = new Mock<IMundaneItemGenerator>();
            mockMaterialsSelector = new Mock<ISpecialMaterialGenerator>();
            mockAttributesSelector = new Mock<IAttributesSelector>();

            mundaneWeaponGenerator = new MundaneWeaponGenerator(mockPercentileSelector.Object, mockAmmunitionGenerator.Object,
                mockMaterialsSelector.Object, mockAttributesSelector.Object, mockDice.Object);
        }

        [Test]
        public void GenerateWeapon()
        {
            var weapon = mundaneWeaponGenerator.Generate();
            Assert.That(weapon, Is.Not.Null);
        }

        [Test]
        public void GenerateMasterworkWeapon()
        {
            var weapon = mundaneWeaponGenerator.Generate();
            Assert.That(weapon.Traits, Contains.Item(TraitConstants.Masterwork));
        }

        [Test]
        public void GetWeaponTypeFromPercentileSelector()
        {
            mundaneWeaponGenerator.Generate();
            mockPercentileSelector.Verify(p => p.SelectFrom("MundaneWeapons", 92), Times.Once);
        }

        [Test]
        public void GetNameFromType()
        {
            var weapon = mundaneWeaponGenerator.Generate();
            Assert.That(weapon.Name, Is.EqualTo("weapon name"));
        }

        [Test]
        public void GetAmmunition()
        {
            var ammo = new Item();
            mockAmmunitionGenerator.Setup(p => p.Generate()).Returns(ammo);
            mockPercentileSelector.Setup(p => p.SelectFrom("weapon typeWeapons", 66)).Returns("Ammunition");

            var weapon = mundaneWeaponGenerator.Generate();
            Assert.That(weapon, Is.EqualTo(ammo));
        }

        [Test]
        public void GetAttributesFromSelector()
        {
            var attributes = new[] { "type 1", "type 2" };
            mockAttributesSelector.Setup(p => p.SelectFrom("WeaponAttributes", "weapon name")).Returns(attributes);

            var armor = mundaneWeaponGenerator.Generate();
            Assert.That(armor.Attributes, Is.EqualTo(attributes));
        }

        [Test]
        public void DoNotGetSpecialMaterialIfWeaponDoesNotHaveSpecialMaterial()
        {
            mockMaterialsSelector.Setup(p => p.HasSpecialMaterial(It.IsAny<String>(), It.IsAny<IEnumerable<String>>())).Returns(false);
            mockMaterialsSelector.Setup(p => p.GenerateFor(It.IsAny<String>(), It.IsAny<IEnumerable<String>>())).Returns("special material");

            var armor = mundaneWeaponGenerator.Generate();
            Assert.That(armor.Traits, Is.Not.Contains("special material"));
        }

        [Test]
        public void GetSpecialMaterialFromMaterialSelector()
        {
            mockMaterialsSelector.Setup(p => p.HasSpecialMaterial(It.IsAny<String>(), It.IsAny<IEnumerable<String>>())).Returns(true);
            mockMaterialsSelector.Setup(p => p.GenerateFor(It.IsAny<String>(), It.IsAny<IEnumerable<String>>())).Returns("special material");

            var weapon = mundaneWeaponGenerator.Generate();
            Assert.That(weapon.Traits, Contains.Item("special material"));
        }

        [Test]
        public void DoubleWeaponsCanHaveMultipleSpecialMaterials()
        {
            var attributes = new[] { AttributeConstants.DoubleWeapon };
            mockAttributesSelector.Setup(p => p.SelectFrom("WeaponAttributes", "weapon name")).Returns(attributes);

            mockMaterialsSelector.Setup(p => p.HasSpecialMaterial(ItemTypeConstants.Weapon, attributes)).Returns(true);
            mockMaterialsSelector.SetupSequence(p => p.GenerateFor(ItemTypeConstants.Weapon, attributes)).Returns("special material 1").Returns("special material 2");

            var weapon = mundaneWeaponGenerator.Generate();
            Assert.That(weapon.Traits, Contains.Item("special material 1"));
            Assert.That(weapon.Traits, Contains.Item("special material 2"));
        }

        [Test]
        public void CannotAddDuplicateSpecialMaterials()
        {
            var attributes = new[] { AttributeConstants.DoubleWeapon };
            mockAttributesSelector.Setup(p => p.SelectFrom("WeaponAttributes", "weapon name")).Returns(attributes);

            mockMaterialsSelector.Setup(p => p.HasSpecialMaterial(ItemTypeConstants.Weapon, attributes)).Returns(true);
            mockMaterialsSelector.Setup(p => p.GenerateFor(ItemTypeConstants.Weapon, attributes)).Returns("special material");

            var weapon = mundaneWeaponGenerator.Generate();
            Assert.That(weapon.Traits, Is.Unique);
        }

        [Test]
        public void IfSecondHeadDoesNotHaveSpecialMaterial_WholeWeaponOneSpecialMaterial()
        {
            var attributes = new[] { AttributeConstants.DoubleWeapon };
            mockAttributesSelector.Setup(p => p.SelectFrom("WeaponAttributes", "weapon name")).Returns(attributes);

            mockMaterialsSelector.SetupSequence(p => p.HasSpecialMaterial(ItemTypeConstants.Weapon, attributes)).Returns(true).Returns(false);
            mockMaterialsSelector.SetupSequence(p => p.GenerateFor(ItemTypeConstants.Weapon, attributes)).Returns("special material 1").Returns("special material 2");

            var weapon = mundaneWeaponGenerator.Generate();
            Assert.That(weapon.Traits, Contains.Item("special material 1"));
            Assert.That(weapon.Traits, Is.Not.Contains("special material 2"));
        }

        [Test]
        public void NonDoubleWeaponsCannotHaveMultipleSpecialMaterials()
        {
            var attributes = new[] { "not double weapon" };
            mockAttributesSelector.Setup(p => p.SelectFrom("WeaponAttributes", "weapon name")).Returns(attributes);

            mockMaterialsSelector.Setup(p => p.HasSpecialMaterial(ItemTypeConstants.Weapon, attributes)).Returns(true);
            mockMaterialsSelector.SetupSequence(p => p.GenerateFor(ItemTypeConstants.Weapon, attributes)).Returns("special material 1").Returns("special material 2");

            var weapon = mundaneWeaponGenerator.Generate();
            Assert.That(weapon.Traits, Contains.Item("special material 1"));
            Assert.That(weapon.Traits, Is.Not.Contains("special material 2"));
        }
    }
}