﻿using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Armor.Minor
{
    [TestFixture]
    public class MinorShieldSpecialAbilitiesTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "MinorShieldSpecialAbilities"; }
        }

        [TestCase(SpecialAbilityConstants.ArrowCatching, 1, 20)]
        [TestCase(SpecialAbilityConstants.Bashing, 21, 40)]
        [TestCase(SpecialAbilityConstants.Blinding, 41, 50)]
        [TestCase(SpecialAbilityConstants.LightFortification, 51, 75)]
        [TestCase(SpecialAbilityConstants.ArrowDeflection, 76, 92)]
        [TestCase(SpecialAbilityConstants.Animated, 93, 97)]
        [TestCase(SpecialAbilityConstants.SpellResistance13, 98, 99)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }

        [TestCase("BonusSpecialAbility", 100)]
        public void Percentile(String content, Int32 roll)
        {
            AssertPercentile(content, roll);
        }
    }
}