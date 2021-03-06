﻿using System;
using EquipmentGen.Common.Goods;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Goods
{
    [TestFixture]
    public class Level8GoodsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "Level8Goods"; }
        }

        [TestCase(EmptyContent, 1, 45)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }

        [TestCase(GoodsConstants.Gem, "1d6", 46, 85)]
        [TestCase(GoodsConstants.Art, "1d4", 86, 100)]
        public void Percentile(String good, String amount, Int32 lower, Int32 upper)
        {
            var content = String.Format("{0},{1}", good, amount);
            AssertPercentile(content, lower, upper);
        }
    }
}