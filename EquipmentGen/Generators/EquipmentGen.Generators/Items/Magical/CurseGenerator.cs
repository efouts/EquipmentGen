﻿using System;
using D20Dice;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using EquipmentGen.Selectors.Interfaces;

namespace EquipmentGen.Generators.Items.Magical
{
    public class CurseGenerator : ICurseGenerator
    {
        private IDice dice;
        private IPercentileSelector percentileSelector;
        private IBooleanPercentileSelector booleanPercentileSelector;

        public CurseGenerator(IDice dice, IPercentileSelector percentileSelector, IBooleanPercentileSelector booleanPercentileSelector)
        {
            this.dice = dice;
            this.percentileSelector = percentileSelector;
            this.booleanPercentileSelector = booleanPercentileSelector;
        }

        public Boolean HasCurse(Boolean isMagical)
        {
            if (!isMagical)
                return false;

            var roll = dice.Percentile();
            return booleanPercentileSelector.SelectFrom("IsItemCursed", roll);
        }

        public String GenerateCurse()
        {
            var roll = dice.Percentile();
            var curse = percentileSelector.SelectFrom("Curses", roll);

            if (curse == "Intermittent Functioning")
                return String.Format("{0} (Dependent: {1})", curse, GetIntermittentFunctioning());

            if (curse == "Drawback")
                return GetDrawback();

            return curse;
        }

        private String GetIntermittentFunctioning()
        {
            var roll = dice.d3();

            if (roll == 1)
                return "Unreliable";

            if (roll == 3)
                return "Uncontrolled";

            roll = dice.Percentile();
            var situation = percentileSelector.SelectFrom("CursedDependentSituations", roll);

            if (situation.Contains("DESIGNATEDFOE"))
                situation = GetSituationWithDesignatedFoe(situation);

            if (situation.Contains("ALIGNMENT"))
                situation = GetSituationWithAlignment(situation);

            if (situation.Contains("GENDER"))
                situation = GetSituationWithGender(situation);

            return situation;
        }

        private String GetSituationWithDesignatedFoe(String situation)
        {
            var roll = dice.Percentile();
            var foe = percentileSelector.SelectFrom("DesignatedFoes", roll);
            return situation.Replace("DESIGNATEDFOE", foe);
        }

        private String GetSituationWithAlignment(String situation)
        {
            var roll = dice.Percentile();
            var alignment = percentileSelector.SelectFrom("ProtectionAlignments", roll);
            return situation.Replace("ALIGNMENT", alignment);
        }

        private String GetSituationWithGender(String situation)
        {
            var roll = dice.d2();

            if (roll == 1)
                return situation.Replace("GENDER", "male");

            return situation.Replace("GENDER", "female");
        }

        private String GetDrawback()
        {
            var roll = dice.Percentile();
            var drawback = percentileSelector.SelectFrom("CurseDrawbacks", roll);

            if (drawback.Contains("HEIGHT"))
                return GetDrawbackWithHeight(drawback);

            return drawback;
        }

        private String GetDrawbackWithHeight(String drawback)
        {
            var roll = dice.Percentile();
            var change = percentileSelector.SelectFrom("CurseHeightChanges", roll);
            return drawback.Replace("HEIGHT", change);
        }

        public Item GenerateSpecificCursedItem()
        {
            var roll = dice.Percentile();

            var specificCursedItem = new Item();
            specificCursedItem.ItemType = ItemTypeConstants.SpecificCursedItem;
            specificCursedItem.Name = percentileSelector.SelectFrom("SpecificCursedItems", roll);
            specificCursedItem.Magic.Curse = "This is a specific cursed item";
            specificCursedItem.Attributes = new[] { AttributeConstants.Specific };

            return specificCursedItem;
        }
    }
}