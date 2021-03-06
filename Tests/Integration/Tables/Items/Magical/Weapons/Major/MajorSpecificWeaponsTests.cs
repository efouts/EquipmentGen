﻿using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Weapons.Major
{
    [TestFixture]
    public class MajorSpecificWeaponsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "MajorSpecificWeapons"; }
        }

        [TestCase(WeaponConstants.AssassinsDagger, 2, 1, 4)]
        [TestCase(WeaponConstants.ShiftersSorrow, 1, 5, 7)]
        [TestCase(WeaponConstants.TridentOfFishCommand, 1, 8, 9)]
        [TestCase(WeaponConstants.FlameTongue, 1, 10, 13)]
        [TestCase(WeaponConstants.LuckBlade0, 2, 14, 17)]
        [TestCase(WeaponConstants.SwordOfSubtlety, 1, 18, 24)]
        [TestCase(WeaponConstants.SwordOfThePlanes, 1, 25, 31)]
        [TestCase(WeaponConstants.NineLivesStealer, 2, 32, 37)]
        [TestCase(WeaponConstants.SwordOfLifeStealing, 2, 38, 42)]
        [TestCase(WeaponConstants.Oathbow, 2, 43, 46)]
        [TestCase(WeaponConstants.MaceOfTerror, 2, 47, 51)]
        [TestCase(WeaponConstants.LifeDrinker, 1, 52, 57)]
        [TestCase(WeaponConstants.SylvanScimitar, 3, 58, 62)]
        [TestCase(WeaponConstants.RapierOfPuncturing, 2, 63, 67)]
        [TestCase(WeaponConstants.SunBlade, 2, 68, 73)]
        [TestCase(WeaponConstants.FrostBrand, 3, 74, 79)]
        [TestCase(WeaponConstants.DwarvenThrower, 2, 80, 84)]
        [TestCase(WeaponConstants.LuckBlade1, 2, 85, 91)]
        [TestCase(WeaponConstants.MaceOfSmiting, 3, 92, 95)]
        [TestCase(WeaponConstants.LuckBlade2, 2, 96, 97)]
        [TestCase(WeaponConstants.HolyAvenger, 2, 98, 99)]
        public void Percentile(String weapon, Int32 bonus, Int32 lower, Int32 upper)
        {
            var content = String.Format("{0},{1}", weapon, bonus);
            AssertPercentile(content, lower, upper);
        }

        [TestCase(WeaponConstants.LuckBlade3, 2, 100)]
        public void Percentile(String weapon, Int32 bonus, Int32 roll)
        {
            var content = String.Format("{0},{1}", weapon, bonus);
            AssertPercentile(content, roll);
        }
    }
}