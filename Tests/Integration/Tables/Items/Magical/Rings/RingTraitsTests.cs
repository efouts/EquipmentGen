﻿using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Rings
{
    [TestFixture]
    public class RingTraitsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "RingTraits"; }
        }

        [TestCase(TraitConstants.Markings, 1, 30)]
        [TestCase(EmptyContent, 31, 100)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }
    }
}