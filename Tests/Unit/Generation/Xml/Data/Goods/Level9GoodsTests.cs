﻿using System;
using EquipmentGen.Core.Data.Goods;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Goods
{
    [TestFixture]
    public class Level9GoodsTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "Level9Goods";
        }

        [Test]
        public void Level9EmptyPercentile()
        {
            AssertEmpty(1, 40);
        }

        [Test]
        public void Level9GemPercentile()
        {
            var content = String.Format("{0},1d8", GoodsConstants.Gem);
            AssertContent(content, 41, 80);
        }

        [Test]
        public void Level9ArtPercentile()
        {
            var content = String.Format("{0},1d4", GoodsConstants.Art);
            AssertContent(content, 81, 100);
        }
    }
}