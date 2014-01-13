﻿using System;
using EquipmentGen.Core.Data.Coins;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Coins
{
    [TestFixture]
    public class Level18CoinTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "Level18Coins";
        }

        [Test]
        public void Level18EmptyPercentile()
        {
            AssertEmpty(1, 2);
        }

        [Test]
        public void Level18GoldPercentile()
        {
            var result = String.Format("{0},3d6*1000", CoinConstants.Gold);
            AssertContent(result, 3, 65);
        }

        [Test]
        public void Level18PlatinumPercentile()
        {
            var result = String.Format("{0},5d4*100", CoinConstants.Platinum);
            AssertContent(result, 66, 100);
        }
    }
}