﻿using System;
using D20Dice;
using EquipmentGen.Common.Coins;
using EquipmentGen.Generators.Interfaces;
using EquipmentGen.Selectors.Interfaces;
using EquipmentGen.Generators.Interfaces.Coins;

namespace EquipmentGen.Generators.Coins
{
    public class CoinGenerator : ICoinGenerator
    {
        private ITypeAndAmountPercentileResultProvider typeAndAmountPercentileResultProvider;
        private IDice dice;

        public CoinGenerator(ITypeAndAmountPercentileResultProvider typeAndAmountPercentileResultProvider, IDice dice)
        {
            this.typeAndAmountPercentileResultProvider = typeAndAmountPercentileResultProvider;
            this.dice = dice;
        }

        public Coin GenerateAtLevel(Int32 level)
        {
            var tableName = String.Format("Level{0}Coins", level);
            var roll = dice.Percentile();
            var result = typeAndAmountPercentileResultProvider.GetResultFrom(tableName, roll);

            var coin = new Coin();

            if (String.IsNullOrEmpty(result.Type))
                return coin;

            coin.Currency = result.Type;
            coin.Quantity = dice.Roll(result.AmountToRoll);

            return coin;
        }
    }
}