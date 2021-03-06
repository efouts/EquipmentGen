﻿using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Armor.Medium
{
    [TestFixture]
    public class MediumArmorSpecialAbilitiesTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "MediumArmorSpecialAbilities"; }
        }

        [TestCase(SpecialAbilityConstants.Glamered, 1, 5)]
        [TestCase(SpecialAbilityConstants.LightFortification, 6, 8)]
        [TestCase(SpecialAbilityConstants.Slick, 9, 11)]
        [TestCase(SpecialAbilityConstants.Shadow, 12, 14)]
        [TestCase(SpecialAbilityConstants.SilentMoves, 15, 17)]
        [TestCase(SpecialAbilityConstants.SpellResistance13, 18, 19)]
        [TestCase(SpecialAbilityConstants.ImprovedSlick, 20, 29)]
        [TestCase(SpecialAbilityConstants.ImprovedShadow, 30, 39)]
        [TestCase(SpecialAbilityConstants.ImprovedSilentMoves, 40, 49)]
        [TestCase(SpecialAbilityConstants.AcidResistance, 50, 54)]
        [TestCase(SpecialAbilityConstants.ColdResistance, 55, 59)]
        [TestCase(SpecialAbilityConstants.ElectricityResistance, 60, 64)]
        [TestCase(SpecialAbilityConstants.FireResistance, 65, 69)]
        [TestCase(SpecialAbilityConstants.SonicResistance, 70, 74)]
        [TestCase(SpecialAbilityConstants.GhostTouchArmor, 75, 79)]
        [TestCase(SpecialAbilityConstants.ModerateFortification, 85, 89)]
        [TestCase(SpecialAbilityConstants.SpellResistance15, 90, 94)]
        [TestCase(SpecialAbilityConstants.Wild, 95, 99)]
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