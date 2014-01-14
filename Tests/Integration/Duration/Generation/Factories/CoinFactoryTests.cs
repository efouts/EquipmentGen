﻿using System;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Duration.Generation.Factories
{
    [TestFixture]
    public class CoinFactoryTests : DurationTest
    {
        [Inject]
        public ICoinFactory CoinFactory { get; set; }

        private Int32 level;

        [SetUp]
        public void Setup()
        {
            level = GetNewLevel();
            StartTest();
        }

        [TearDown]
        public void TearDown()
        {
            StopTest();
        }

        [Test]
        public void CoinFactoryDuration()
        {
            CoinFactory.CreateAtLevel(level);
            AssertDuration();
        }
    }
}