﻿using System;
using EquipmentGen.Common.Coins;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Coins
{
    [TestFixture]
    public class Level3CoinsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "Level3Coins"; }
        }

        [TestCase(EmptyContent, 1, 11)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }

        [TestCase(CoinConstants.Copper, "2d10*1000", 12, 21)]
        [TestCase(CoinConstants.Silver, "4d8*100", 22, 41)]
        [TestCase(CoinConstants.Gold, "1d4*100", 42, 95)]
        [TestCase(CoinConstants.Platinum, "1d10*10", 96, 100)]
        public void Percentile(String coin, String amount, Int32 lower, Int32 upper)
        {
            var result = String.Format("{0},{1}", coin, amount);
            AssertPercentile(result, lower, upper);
        }
    }
}