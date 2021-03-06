﻿using System;
using System.Collections.Generic;
using System.Linq;
using D20Dice;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using EquipmentGen.Selectors.Interfaces;

namespace EquipmentGen.Generators.Items.Magical
{
    public class RingGenerator : IMagicalItemGenerator
    {
        private IPercentileSelector percentileSelector;
        private IAttributesSelector attributesSelector;
        private IMagicalItemTraitsGenerator traitsGenerator;
        private ISpellGenerator spellGenerator;
        private IChargesGenerator chargesGenerator;
        private IDice dice;
        private ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector;

        public RingGenerator(IPercentileSelector percentileSelector, IAttributesSelector attributesSelector,
            IMagicalItemTraitsGenerator traitsGenerator, ISpellGenerator spellGenerator, IChargesGenerator chargesGenerator,
            IDice dice, ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector)
        {
            this.percentileSelector = percentileSelector;
            this.attributesSelector = attributesSelector;
            this.traitsGenerator = traitsGenerator;
            this.spellGenerator = spellGenerator;
            this.chargesGenerator = chargesGenerator;
            this.dice = dice;
            this.typeAndAmountPercentileSelector = typeAndAmountPercentileSelector;
        }

        public Item GenerateAtPower(String power)
        {
            var roll = dice.Percentile();
            var tableName = String.Format("{0}Rings", power);
            var result = typeAndAmountPercentileSelector.SelectFrom(tableName, roll);

            var ring = new Item();
            ring.Name = String.Format("Ring of {0}", result.Type);
            ring.Magic.Bonus = Convert.ToInt32(result.Amount);
            ring.IsMagical = true;
            ring.Attributes = attributesSelector.SelectFrom("RingAttributes", result.Type);
            ring.ItemType = ItemTypeConstants.Ring;

            var traits = traitsGenerator.GenerateFor(ItemTypeConstants.Ring);
            ring.Traits.AddRange(traits);

            if (ring.Attributes.Contains(AttributeConstants.Charged))
                ring.Magic.Charges = chargesGenerator.GenerateFor(ItemTypeConstants.Ring, result.Type);

            if (result.Type.Contains("Counterspells"))
            {
                var level = spellGenerator.GenerateLevel(power);
                if (level <= 6)
                {
                    var type = spellGenerator.GenerateType();
                    var spell = spellGenerator.Generate(type, level);
                    ring.Contents.Add(spell);
                }
            }
            else if (result.Type.Contains("Minor spell storing"))
            {
                var spells = GenerateSpells(power, 3);
                ring.Contents.AddRange(spells);
            }
            else if (result.Type.Contains("Major spell storing"))
            {
                var spells = GenerateSpells(power, 10);
                ring.Contents.AddRange(spells);
            }
            else if (result.Type.Contains("Spell storing"))
            {
                var spells = GenerateSpells(power, 5);
                ring.Contents.AddRange(spells);
            }
            else if (result.Type.Contains("ENERGY"))
            {
                roll = dice.Percentile();
                var element = percentileSelector.SelectFrom("Elements", roll);
                ring.Name = ring.Name.Replace("ENERGY", element);
            }

            return ring;
        }

        private IEnumerable<String> GenerateSpells(String power, Int32 levelCap)
        {
            var level = spellGenerator.GenerateLevel(power);
            var levelSum = level;
            var spells = new List<String>();

            while (levelSum <= levelCap)
            {
                var type = spellGenerator.GenerateType();
                var spell = spellGenerator.Generate(type, level);
                var formattedSpell = String.Format("{0} ({1}, {2})", spell, type, level);
                spells.Add(formattedSpell);

                level = spellGenerator.GenerateLevel(power);
                levelSum += level;
            }

            return spells;
        }
    }
}