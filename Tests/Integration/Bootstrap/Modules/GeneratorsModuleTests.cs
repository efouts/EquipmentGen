﻿using D20Dice;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Decorators;
using EquipmentGen.Generators.Interfaces;
using EquipmentGen.Generators.Interfaces.Coins;
using EquipmentGen.Generators.Interfaces.Goods;
using EquipmentGen.Generators.Interfaces.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using EquipmentGen.Generators.Interfaces.Items.Mundane;
using EquipmentGen.Generators.Items.Mundane;
using EquipmentGen.Generators.RuntimeFactories.Interfaces;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Bootstrap.Modules
{
    [TestFixture]
    public class GeneratorsModuleTests : BootstrapTests
    {
        [Test]
        public void CoinGeneratorNotConstructedAsSingleton()
        {
            AssertNotSingleton<ICoinGenerator>();
        }

        [Test]
        public void DiceConstructedAsSingleton()
        {
            AssertSingleton<IDice>();
        }

        [Test]
        public void GoodsGeneratorNotConstructedAsSingleton()
        {
            AssertNotSingleton<IGoodsGenerator>();
        }

        [Test]
        public void TreasureGeneratorNotConstructedAsSingleton()
        {
            AssertNotSingleton<ITreasureGenerator>();
        }

        [Test]
        public void ItemsGeneratorNotConstructedAsSingleton()
        {
            AssertNotSingleton<IItemsGenerator>();
        }

        [Test]
        public void MundaneItemGeneratorNamedAlchemicalItemIsAlchemicalItemGenerator()
        {
            var generator = GetNewInstanceOf<IMundaneItemGenerator>(ItemTypeConstants.AlchemicalItem);
            Assert.That(generator, Is.InstanceOf<AlchemicalItemGenerator>());
        }

        [Test]
        public void AlchemicalItemGeneratorIsNotConstructedAsSingleton()
        {
            AssertNotSingleton<IMundaneItemGenerator>(ItemTypeConstants.AlchemicalItem);
        }

        [Test]
        public void MundaneItemGeneratorNamedToolIsToolGenerator()
        {
            var generator = GetNewInstanceOf<IMundaneItemGenerator>(ItemTypeConstants.Tool);
            Assert.That(generator, Is.InstanceOf<ToolGenerator>());
        }

        [Test]
        public void ToolGeneratorIsNotConstructedAsSingleton()
        {
            AssertNotSingleton<IMundaneItemGenerator>(ItemTypeConstants.Tool);
        }

        [Test]
        public void MundaneGearGeneratorFactoryNotConstructedAsSingleton()
        {
            AssertNotSingleton<IMundaneItemGeneratorFactory>();
        }

        [Test]
        public void MagicalItemGeneratorFactoryNotConstructedAsSingleton()
        {
            AssertNotSingleton<IMagicalItemGeneratorFactory>();
        }

        [Test]
        public void SpecialMaterialGeneratorNotConstructedAsSingleton()
        {
            AssertNotSingleton<ISpecialMaterialGenerator>();
        }

        [Test]
        public void SpecialAbilitiesGeneratorNotConstructedAsSingleton()
        {
            AssertNotSingleton<ISpecialAbilitiesGenerator>();
        }

        [Test]
        public void CurseGeneratorNotConstructedAsSingleton()
        {
            AssertNotSingleton<ICurseGenerator>();
        }

        [Test]
        public void MagicalItemTraitsGeneratorNotConstructedAsSingleton()
        {
            AssertNotSingleton<IMagicalItemTraitsGenerator>();
        }

        [Test]
        public void SpellGeneratorNotConstructedAsSingleton()
        {
            AssertNotSingleton<ISpellGenerator>();
        }

        [Test]
        public void IntelligenceGeneratorNotConstructedAsSingleton()
        {
            AssertNotSingleton<IIntelligenceGenerator>();
        }

        [Test]
        public void ChargesGeneratorNotConstructedAsSingleton()
        {
            AssertNotSingleton<IChargesGenerator>();
        }

        [Test]
        public void SpecificGearGeneratorNotConstructedAsSingleton()
        {
            AssertNotSingleton<ISpecificGearGenerator>();
        }

        [Test]
        public void MagicalArmorGeneratorIsNotConstructedAsSingleton()
        {
            AssertNotSingleton<IMagicalItemGenerator>(ItemTypeConstants.Armor);
        }

        [Test]
        public void MagicalArmorGeneratorIsDecorated()
        {
            var generator = GetNewInstanceOf<IMagicalItemGenerator>(ItemTypeConstants.Armor);
            Assert.That(generator, Is.InstanceOf<MagicalItemGeneratorMundaneProxy>());
        }

        [Test]
        public void MagicalWeaponGeneratorIsNotConstructedAsSingleton()
        {
            AssertNotSingleton<IMagicalItemGenerator>(ItemTypeConstants.Weapon);
        }

        [Test]
        public void MagicalWeaponGeneratorIsDecorated()
        {
            var generator = GetNewInstanceOf<IMagicalItemGenerator>(ItemTypeConstants.Weapon);
            Assert.That(generator, Is.InstanceOf<MagicalItemGeneratorMundaneProxy>());
        }

        [Test]
        public void PotionGeneratorIsNotConstructedAsSingleton()
        {
            AssertNotSingleton<IMagicalItemGenerator>(ItemTypeConstants.Potion);
        }

        [Test]
        public void PotionGeneratorIsDecorated()
        {
            var generator = GetNewInstanceOf<IMagicalItemGenerator>(ItemTypeConstants.Potion);
            Assert.That(generator, Is.InstanceOf<MagicalItemGeneratorMundaneProxy>());
        }

        [Test]
        public void RingGeneratorIsNotConstructedAsSingleton()
        {
            AssertNotSingleton<IMagicalItemGenerator>(ItemTypeConstants.Ring);
        }

        [Test]
        public void RingGeneratorIsDecorated()
        {
            var generator = GetNewInstanceOf<IMagicalItemGenerator>(ItemTypeConstants.Ring);
            Assert.That(generator, Is.InstanceOf<MagicalItemGeneratorMundaneProxy>());
        }

        [Test]
        public void RodGeneratorIsNotConstructedAsSingleton()
        {
            AssertNotSingleton<IMagicalItemGenerator>(ItemTypeConstants.Rod);
        }

        [Test]
        public void RodGeneratorIsDecorated()
        {
            var generator = GetNewInstanceOf<IMagicalItemGenerator>(ItemTypeConstants.Rod);
            Assert.That(generator, Is.InstanceOf<MagicalItemGeneratorMundaneProxy>());
        }

        [Test]
        public void ScrollGeneratorIsNotConstructedAsSingleton()
        {
            AssertNotSingleton<IMagicalItemGenerator>(ItemTypeConstants.Scroll);
        }

        [Test]
        public void ScrollGeneratorIsDecorated()
        {
            var generator = GetNewInstanceOf<IMagicalItemGenerator>(ItemTypeConstants.Scroll);
            Assert.That(generator, Is.InstanceOf<MagicalItemGeneratorMundaneProxy>());
        }

        [Test]
        public void StaffGeneratorIsNotConstructedAsSingleton()
        {
            AssertNotSingleton<IMagicalItemGenerator>(ItemTypeConstants.Staff);
        }

        [Test]
        public void StaffGeneratorIsDecorated()
        {
            var generator = GetNewInstanceOf<IMagicalItemGenerator>(ItemTypeConstants.Staff);
            Assert.That(generator, Is.InstanceOf<MagicalItemGeneratorMundaneProxy>());
        }

        [Test]
        public void WandGeneratorIsNotConstructedAsSingleton()
        {
            AssertNotSingleton<IMagicalItemGenerator>(ItemTypeConstants.Wand);
        }

        [Test]
        public void WandGeneratorIsDecorated()
        {
            var generator = GetNewInstanceOf<IMagicalItemGenerator>(ItemTypeConstants.Wand);
            Assert.That(generator, Is.InstanceOf<MagicalItemGeneratorMundaneProxy>());
        }

        [Test]
        public void WondrousItemGeneratorIsNotConstructedAsSingleton()
        {
            AssertNotSingleton<IMagicalItemGenerator>(ItemTypeConstants.WondrousItem);
        }

        [Test]
        public void WondrousItemGeneratorIsDecorated()
        {
            var generator = GetNewInstanceOf<IMagicalItemGenerator>(ItemTypeConstants.WondrousItem);
            Assert.That(generator, Is.InstanceOf<MagicalItemGeneratorMundaneProxy>());
        }

        [Test]
        public void MundaneItemGeneratorNamedArmorIsMundaneArmorGenerator()
        {
            var generator = GetNewInstanceOf<IMundaneItemGenerator>(ItemTypeConstants.Armor);
            Assert.That(generator, Is.InstanceOf<MundaneArmorGenerator>());
        }

        [Test]
        public void MundaneArmorGeneratorIsNotConstructedAsSingleton()
        {
            AssertNotSingleton<IMundaneItemGenerator>(ItemTypeConstants.Armor);
        }

        [Test]
        public void MundaneItemGeneratorNamedWeaponIsMundaneWeaponGenerator()
        {
            var generator = GetNewInstanceOf<IMundaneItemGenerator>(ItemTypeConstants.Weapon);
            Assert.That(generator, Is.InstanceOf<MundaneWeaponGenerator>());
        }

        [Test]
        public void MundaneWeaponGeneratorIsNotConstructedAsSingleton()
        {
            AssertNotSingleton<IMundaneItemGenerator>(ItemTypeConstants.Weapon);
        }
    }
}