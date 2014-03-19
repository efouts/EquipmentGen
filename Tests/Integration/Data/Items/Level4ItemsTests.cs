﻿using System;
using EquipmentGen.Common.Items;
using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items
{
    [TestFixture, PercentileTable("Level4Items")]
    public class Level4ItemsTests : PercentileTests
    {
        [Test]
        public void Level4ItemsEmptyPercentile()
        {
            AssertEmpty(1, 42);
        }

        [Test]
        public void Level4ItemsMundanePercentile()
        {
            var content = String.Format("{0},1d4", PowerConstants.Mundane);
            AssertContent(content, 43, 62);
        }

        [Test]
        public void Level4ItemsMinorPercentile()
        {
            var content = String.Format("{0},1", PowerConstants.Minor);
            AssertContent(content, 63, 100);
        }
    }
}