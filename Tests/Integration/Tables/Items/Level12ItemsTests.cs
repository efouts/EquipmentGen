﻿using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items
{
    [TestFixture]
    public class Level12ItemsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "Level12Items"; }
        }

        [TestCase(EmptyContent, 1, 27)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }

        [TestCase(PowerConstants.Minor, "1d6", 28, 82)]
        [TestCase(PowerConstants.Medium, "1", 83, 97)]
        [TestCase(PowerConstants.Major, "1", 98, 100)]
        public void Percentile(String power, String amount, Int32 lower, Int32 upper)
        {
            var content = String.Format("{0},{1}", power, amount);
            AssertPercentile(content, lower, upper);
        }
    }
}