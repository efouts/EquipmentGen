﻿using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Common.Items
{
    [TestFixture]
    public class WeaponConstantsTests
    {
        [TestCase(WeaponConstants.Dagger, "Dagger")]
        [TestCase(WeaponConstants.Greataxe, "Greataxe")]
        [TestCase(WeaponConstants.Greatsword, "Greatsword")]
        [TestCase(WeaponConstants.Kama, "Kama")]
        [TestCase(WeaponConstants.Longsword, "Longsword")]
        [TestCase(WeaponConstants.LightMace, "Light mace")]
        [TestCase(WeaponConstants.HeavyMace, "Heavy mace")]
        [TestCase(WeaponConstants.Nunchaku, "Nunchaku")]
        [TestCase(WeaponConstants.Quarterstaff, "Quarterstaff")]
        [TestCase(WeaponConstants.Rapier, "Rapier")]
        [TestCase(WeaponConstants.Scimitar, "Scimitar")]
        [TestCase(WeaponConstants.Shortspear, "Shortspear")]
        [TestCase(WeaponConstants.Siangham, "Siangham")]
        [TestCase(WeaponConstants.BastardSword, "Bastard sword")]
        [TestCase(WeaponConstants.ShortSword, "Short sword")]
        [TestCase(WeaponConstants.DwarvenWaraxe, "Dwarven waraxe")]
        [TestCase(WeaponConstants.OrcDoubleAxe, "Orc double axe")]
        [TestCase(WeaponConstants.Battleaxe, "Battleaxe")]
        [TestCase(WeaponConstants.SpikedChain, "Spiked chain")]
        [TestCase(WeaponConstants.Club, "Club")]
        [TestCase(WeaponConstants.HandCrossbow, "Hand crossbow")]
        [TestCase(WeaponConstants.RepeatingCrossbow, "Repeating crossbow")]
        [TestCase(WeaponConstants.PunchingDagger, "Punching dagger")]
        [TestCase(WeaponConstants.Falchion, "Falchion")]
        [TestCase(WeaponConstants.DireFlail, "Dire flail")]
        [TestCase(WeaponConstants.HeavyFlail, "Heavy flail")]
        [TestCase(WeaponConstants.LightFlail, "Light flail")]
        [TestCase(WeaponConstants.Gauntlet, "Gauntlet")]
        [TestCase(WeaponConstants.SpikedGauntlet, "Spiked gauntlet")]
        [TestCase(WeaponConstants.Glaive, "Glaive")]
        [TestCase(WeaponConstants.Greatclub, "Greatclub")]
        [TestCase(WeaponConstants.Guisarme, "Guisarme")]
        [TestCase(WeaponConstants.Halberd, "Halberd")]
        [TestCase(WeaponConstants.Halfspear, "Halfspear")]
        [TestCase(WeaponConstants.GnomeHookedHammer, "Gnome hooked hammer")]
        [TestCase(WeaponConstants.LightHammer, "Light hammer")]
        [TestCase(WeaponConstants.Handaxe, "Handaxe")]
        [TestCase(WeaponConstants.Kukri, "Kukri")]
        [TestCase(WeaponConstants.Lance, "Lance")]
        [TestCase(WeaponConstants.Longspear, "Longspear")]
        [TestCase(WeaponConstants.Morningstar, "Morningstar")]
        [TestCase(WeaponConstants.Net, "Net")]
        [TestCase(WeaponConstants.HeavyPick, "Heavy pick")]
        [TestCase(WeaponConstants.LightPick, "Light pick")]
        [TestCase(WeaponConstants.Ranseur, "Ranseur")]
        [TestCase(WeaponConstants.Sap, "Sap")]
        [TestCase(WeaponConstants.Scythe, "Scythe")]
        [TestCase(WeaponConstants.Shuriken, "Shuriken")]
        [TestCase(WeaponConstants.Sickle, "Sickle")]
        [TestCase(WeaponConstants.TwoBladedSword, "Two-bladed sword")]
        [TestCase(WeaponConstants.Trident, "Trident")]
        [TestCase(WeaponConstants.DwarvenUrgrosh, "Dwarven urgrosh")]
        [TestCase(WeaponConstants.Warhammer, "Warhammer")]
        [TestCase(WeaponConstants.Whip, "Whip")]
        [TestCase(WeaponConstants.Arrow, "Arrow")]
        [TestCase(WeaponConstants.CrossbowBolt, "Crossbow bolt")]
        [TestCase(WeaponConstants.SlingBullet, "Sling bullet")]
        [TestCase(WeaponConstants.ThrowingAxe, "Throwing axe")]
        [TestCase(WeaponConstants.HeavyCrossbow, "Heavy crossbow")]
        [TestCase(WeaponConstants.LightCrossbow, "Light crossbow")]
        [TestCase(WeaponConstants.Dart, "Dart")]
        [TestCase(WeaponConstants.Javelin, "Javelin")]
        [TestCase(WeaponConstants.Shortbow, "Shortbow")]
        [TestCase(WeaponConstants.CompositePlus0Shortbow, "Composite (+0) shortbow")]
        [TestCase(WeaponConstants.CompositePlus1Shortbow, "Composite (+1) shortbow")]
        [TestCase(WeaponConstants.CompositePlus2Shortbow, "Composite (+2) shortbow")]
        [TestCase(WeaponConstants.Sling, "Sling")]
        [TestCase(WeaponConstants.Longbow, "Longbow")]
        [TestCase(WeaponConstants.CompositePlus0Longbow, "Composite (+0) longbow")]
        [TestCase(WeaponConstants.CompositePlus1Longbow, "Composite (+1) longbow")]
        [TestCase(WeaponConstants.CompositePlus2Longbow, "Composite (+2) longbow")]
        [TestCase(WeaponConstants.CompositePlus3Longbow, "Composite (+3) longbow")]
        [TestCase(WeaponConstants.CompositePlus4Longbow, "Composite (+4) longbow")]
        public void WeaponConstantIsCorrect(String constant, String value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }
    }
}