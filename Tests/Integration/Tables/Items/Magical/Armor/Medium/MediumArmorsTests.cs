﻿using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Armor.Medium
{
    [TestFixture]
    public class MediumArmorsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "MediumArmors"; }
        }

        [TestCase(AttributeConstants.Shield, 1, 1, 5)]
        [TestCase(ItemTypeConstants.Armor, 1, 6, 10)]
        [TestCase(AttributeConstants.Shield, 2, 11, 20)]
        [TestCase(ItemTypeConstants.Armor, 2, 21, 30)]
        [TestCase(AttributeConstants.Shield, 3, 31, 40)]
        [TestCase(ItemTypeConstants.Armor, 3, 41, 50)]
        [TestCase(AttributeConstants.Shield, 4, 51, 55)]
        [TestCase(ItemTypeConstants.Armor, 4, 56, 57)]
        [TestCase("SpecificArmors", 0, 58, 60)]
        [TestCase("SpecificShields", 0, 61, 63)]
        [TestCase("SpecialAbility", 1, 64, 100)]
        public void Percentile(String type, Int32 bonus, Int32 lower, Int32 upper)
        {
            var content = String.Format("{0},{1}", type, bonus);
            AssertPercentile(content, lower, upper);
        }
    }
}