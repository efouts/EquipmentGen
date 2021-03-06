﻿using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Armor.Medium
{
    [TestFixture]
    public class MediumShieldSpecialAbilitiesTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "MediumShieldSpecialAbilities"; }
        }

        [TestCase(SpecialAbilityConstants.ArrowCatching, 1, 10)]
        [TestCase(SpecialAbilityConstants.Bashing, 11, 20)]
        [TestCase(SpecialAbilityConstants.Blinding, 21, 25)]
        [TestCase(SpecialAbilityConstants.LightFortification, 26, 40)]
        [TestCase(SpecialAbilityConstants.ArrowDeflection, 41, 50)]
        [TestCase(SpecialAbilityConstants.Animated, 51, 57)]
        [TestCase(SpecialAbilityConstants.SpellResistance13, 58, 59)]
        [TestCase(SpecialAbilityConstants.AcidResistance, 60, 63)]
        [TestCase(SpecialAbilityConstants.ColdResistance, 64, 67)]
        [TestCase(SpecialAbilityConstants.ElectricityResistance, 68, 71)]
        [TestCase(SpecialAbilityConstants.FireResistance, 72, 75)]
        [TestCase(SpecialAbilityConstants.SonicResistance, 76, 79)]
        [TestCase(SpecialAbilityConstants.GhostTouchArmor, 80, 85)]
        [TestCase(SpecialAbilityConstants.ModerateFortification, 86, 95)]
        [TestCase(SpecialAbilityConstants.SpellResistance15, 96, 98)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }

        [TestCase(SpecialAbilityConstants.Wild, 99)]
        [TestCase("BonusSpecialAbility", 100)]
        public void Percentile(String content, Int32 roll)
        {
            AssertPercentile(content, roll);
        }
    }
}