﻿using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Potions
{
    [TestFixture]
    public class ProtectionAlignmentsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "ProtectionAlignments"; }
        }

        [TestCase("Chaos", 1, 25)]
        [TestCase("Law", 26, 50)]
        [TestCase("Good", 51, 75)]
        [TestCase("Evil", 76, 100)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }
    }
}