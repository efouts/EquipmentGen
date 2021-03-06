﻿using System;
using EquipmentGen.Common.Goods;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Goods
{
    [TestFixture]
    public class Level20GoodsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "Level20Goods"; }
        }

        [TestCase(EmptyContent, 1, 2)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }

        [TestCase(GoodsConstants.Gem, "4d10", 3, 38)]
        [TestCase(GoodsConstants.Art, "7d6", 39, 100)]
        public void Percentile(String good, String amount, Int32 lower, Int32 upper)
        {
            var content = String.Format("{0},{1}", good, amount);
            AssertPercentile(content, lower, upper);
        }
    }
}