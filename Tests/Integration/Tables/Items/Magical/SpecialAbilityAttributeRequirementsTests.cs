﻿using System;
using System.Linq;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical
{
    [TestFixture]
    public class SpecialAbilityAttributeRequirementsTests : AttributesTests
    {
        protected override String tableName
        {
            get { return "SpecialAbilityAttributeRequirements"; }
        }

        [TestCase(SpecialAbilityConstants.Glamered)]
        [TestCase(SpecialAbilityConstants.Fortification)]
        [TestCase(SpecialAbilityConstants.Slick)]
        [TestCase(SpecialAbilityConstants.Shadow)]
        [TestCase(SpecialAbilityConstants.SilentMoves)]
        [TestCase(SpecialAbilityConstants.SpellResistance)]
        [TestCase(SpecialAbilityConstants.AcidResistance)]
        [TestCase(SpecialAbilityConstants.ColdResistance)]
        [TestCase(SpecialAbilityConstants.ElectricityResistance)]
        [TestCase(SpecialAbilityConstants.FireResistance)]
        [TestCase(SpecialAbilityConstants.SonicResistance)]
        [TestCase(SpecialAbilityConstants.GhostTouch)]
        [TestCase(SpecialAbilityConstants.Invulnerability)]
        [TestCase(SpecialAbilityConstants.Wild)]
        [TestCase(SpecialAbilityConstants.Etherealness)]
        [TestCase(SpecialAbilityConstants.UndeadControlling)]
        [TestCase(SpecialAbilityConstants.ArrowCatching, AttributeConstants.Shield)]
        [TestCase(SpecialAbilityConstants.Bashing, AttributeConstants.Shield,
                                                   AttributeConstants.NotTower)]
        [TestCase(SpecialAbilityConstants.Blinding, AttributeConstants.Shield)]
        [TestCase(SpecialAbilityConstants.ArrowDeflection, AttributeConstants.Shield)]
        [TestCase(SpecialAbilityConstants.Animated, AttributeConstants.Shield)]
        [TestCase(SpecialAbilityConstants.Reflecting, AttributeConstants.Shield)]
        [TestCase(SpecialAbilityConstants.Bane)]
        [TestCase(SpecialAbilityConstants.Distance, AttributeConstants.Ranged)]
        [TestCase(SpecialAbilityConstants.Disruption, AttributeConstants.Melee,
                                                      AttributeConstants.Bludgeoning)]
        [TestCase(SpecialAbilityConstants.Flaming)]
        [TestCase(SpecialAbilityConstants.Frost)]
        [TestCase(SpecialAbilityConstants.Merciful)]
        [TestCase(SpecialAbilityConstants.Returning, AttributeConstants.Ranged,
                                                     AttributeConstants.Thrown)]
        [TestCase(SpecialAbilityConstants.Shock)]
        [TestCase(SpecialAbilityConstants.Seeking, AttributeConstants.Ranged)]
        [TestCase(SpecialAbilityConstants.Thundering)]
        [TestCase(SpecialAbilityConstants.Anarchic)]
        [TestCase(SpecialAbilityConstants.Axiomatic)]
        [TestCase(SpecialAbilityConstants.Holy)]
        [TestCase(SpecialAbilityConstants.Unholy)]
        [TestCase(SpecialAbilityConstants.Speed)]
        [TestCase(SpecialAbilityConstants.BrilliantEnergy)]
        [TestCase(SpecialAbilityConstants.Keen, AttributeConstants.Melee,
                                                AttributeConstants.NotBludgeoning)]
        [TestCase(SpecialAbilityConstants.KiFocus, AttributeConstants.Melee)]
        [TestCase(SpecialAbilityConstants.MightyCleaving, AttributeConstants.Melee)]
        [TestCase(SpecialAbilityConstants.SpellStoring, AttributeConstants.Melee)]
        [TestCase(SpecialAbilityConstants.Throwing, AttributeConstants.Melee)]
        [TestCase(SpecialAbilityConstants.Vicious, AttributeConstants.Melee)]
        [TestCase(SpecialAbilityConstants.Defending, AttributeConstants.Melee)]
        [TestCase(SpecialAbilityConstants.Wounding, AttributeConstants.Melee)]
        [TestCase(SpecialAbilityConstants.Dancing, AttributeConstants.Melee)]
        [TestCase(SpecialAbilityConstants.Vorpal, AttributeConstants.Melee,
                                                  AttributeConstants.NotBludgeoning,
                                                  AttributeConstants.Slashing)]
        public void Attributes(String name, params String[] attributes)
        {
            if (attributes.Any())
                AssertAttributes(name, attributes);
            else
                AssertEmpty(name);
        }
    }
}