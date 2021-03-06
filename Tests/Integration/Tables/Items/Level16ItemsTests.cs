﻿using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items
{
    [TestFixture]
    public class Level16ItemsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "Level16Items"; }
        }

        [TestCase(EmptyContent, 1, 40)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }

        [TestCase(PowerConstants.Minor, "1d10", 41, 46)]
        [TestCase(PowerConstants.Medium, "1d3", 47, 90)]
        [TestCase(PowerConstants.Major, "1", 91, 100)]
        public void Percentile(String power, String amount, Int32 lower, Int32 upper)
        {
            var content = String.Format("{0},{1}", power, amount);
            AssertPercentile(content, lower, upper);
        }
    }
}