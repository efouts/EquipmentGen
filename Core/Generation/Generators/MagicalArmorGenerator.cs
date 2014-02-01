﻿using System;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;

namespace EquipmentGen.Core.Generation.Generators
{
    public class MagicalArmorGenerator : IMagicalGearGenerator
    {
        private ITypeAndAmountPercentileResultProvider typeAndAmountPercentileProvider;
        private IPercentileResultProvider percentileResultProvider;
        private IGearTypesProvider gearTypesProvider;
        private IGearSpecialAbilitiesGenerator gearSpecialAbilitiesProvider;
        private ISpecialMaterialGenerator materialsProvider;
        private IMagicalItemTraitsGenerator magicItemTraitsGenerator;

        public MagicalArmorGenerator(ITypeAndAmountPercentileResultProvider typeAndAmountPercentileProvider,
            IPercentileResultProvider percentileResultProvider, IGearTypesProvider gearTypesProvider,
            IGearSpecialAbilitiesGenerator gearSpecialAbilitiesProvider, ISpecialMaterialGenerator materialsProvider,
            IMagicalItemTraitsGenerator magicItemTraitsGenerator)
        {
            this.typeAndAmountPercentileProvider = typeAndAmountPercentileProvider;
            this.percentileResultProvider = percentileResultProvider;
            this.gearTypesProvider = gearTypesProvider;
            this.gearSpecialAbilitiesProvider = gearSpecialAbilitiesProvider;
            this.materialsProvider = materialsProvider;
            this.magicItemTraitsGenerator = magicItemTraitsGenerator;
        }

        public Gear GenerateAtPower(String power)
        {
            if (power == ItemsConstants.Power.Mundane)
                throw new ArgumentException();

            var tableName = String.Format("{0}Armor", power);
            var result = typeAndAmountPercentileProvider.GetTypeAndAmountPercentileResult(tableName);
            var armor = new Gear();
            var abilities = 0;

            while (result.Type == "SpecialAbility")
            {
                abilities += result.Amount;
                result = typeAndAmountPercentileProvider.GetTypeAndAmountPercentileResult(tableName);
            }

            var specific = result.Type.StartsWith("Specific", StringComparison.InvariantCultureIgnoreCase);
            if (specific)
            {
                tableName = power + result.Type;
            }
            else
            {
                tableName = String.Format("{0}Type", result.Type);
                armor.MagicalBonus = result.Amount;
            }

            armor.Name = percentileResultProvider.GetPercentileResult(tableName);
            armor.Types = gearTypesProvider.GetGearTypesFor(armor.Name);

            if (!specific)
            {
                armor.Abilities = gearSpecialAbilitiesProvider.GenerateFor(armor.Types, power, armor.MagicalBonus, abilities);

                if (materialsProvider.HasSpecialMaterial())
                {
                    var specialMaterial = materialsProvider.GenerateSpecialMaterialFor(armor.Types);
                    if (!String.IsNullOrEmpty(specialMaterial))
                        armor.Traits.Add(specialMaterial);
                }
            }

            var traits = magicItemTraitsGenerator.GenerateFor(ItemsConstants.ItemTypes.Armor);
            armor.Traits.AddRange(traits);

            return armor;
        }
    }
}