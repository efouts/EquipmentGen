﻿using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.WondrousItems
{
    [TestFixture]
    public class MinorWondrousItemsTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "MinorWondrousItems";
        }

        [TestCase("Quaal's feather token, anchor", 1)]
        [TestCase("Universal solvent", 2)]
        [TestCase("Elixer of love", 3)]
        [TestCase("Unguent of timelessness", 4)]
        [TestCase("Quaal's feather token, fan", 5)]
        [TestCase("Dust of tracelessness", 6)]
        [TestCase("Elixer of hiding", 7)]
        [TestCase("Elixer of sneaking", 8)]
        [TestCase("Elixer of swimming", 9)]
        [TestCase("Elixer of vision", 10)]
        [TestCase("Silversheen", 11)]
        [TestCase("Quaal's feather token, bird", 12)]
        [TestCase("Quaal's feather token, tree", 13)]
        [TestCase("Quaal's feather token, swan boat", 14)]
        [TestCase("Elixer of truth", 15)]
        [TestCase("Quaal's feather token, whip", 16)]
        [TestCase("Dust of dryness", 17)]
        [TestCase("Gray bag of tricks", 18)]
        [TestCase("Hand of the mage", 19)]
        [TestCase("Bracers of armor +1", 20)]
        [TestCase("Cloak of resistance +1", 21)]
        [TestCase("1st-level spell pearl of power", 22)]
        [TestCase("Phylactery of faithfulness", 23)]
        [TestCase("Salve of slipperiness", 24)]
        [TestCase("Elixer of fire breath", 25)]
        [TestCase("Pipes of the sewers", 26)]
        [TestCase("Dust of illusion", 27)]
        [TestCase("Goggles of minute seeing", 28)]
        [TestCase("Brooch of shielding", 29)]
        [TestCase("Necklace of fireballs type I", 30)]
        [TestCase("Dust of appearance", 31)]
        [TestCase("Hat of disguise", 32)]
        [TestCase("Pipes of sounding", 33)]
        [TestCase("Quiver of Ehlonna", 34)]
        [TestCase("Amulet of natural armor +1", 35)]
        [TestCase("Heward's handy haversack", 36)]
        [TestCase("Horn of fog", 37)]
        [TestCase("Elemental gem", 38)]
        [TestCase("Robe of bones", 39)]
        [TestCase("Sovereign glue", 40)]
        [TestCase("Bag of holding type I", 41)]
        [TestCase("Boots of elvenkind", 42)]
        [TestCase("Boots of the winterlands", 43)]
        [TestCase("Candle of truth", 44)]
        [TestCase("Cloak of elvenkind", 45)]
        [TestCase("Eyes of the eagle", 46)]
        [TestCase("Golembane scarab", 47)]
        [TestCase("Necklace of fireballs type II", 48)]
        [TestCase("Stone of alarm", 49)]
        [TestCase("Rust bag of tricks", 50)]
        [TestCase("Bead of force", 51)]
        [TestCase("Chime of opening", 52)]
        [TestCase("Horseshoes of speed", 53)]
        [TestCase("Bead of force", 51)]
        [TestCase("Chime of opening", 52)]
        [TestCase("Horseshoes of speed", 53)]
        [TestCase("Rope of climbing", 54)]
        [TestCase("Dust of disappearance", 55)]
        [TestCase("Lens of detection", 56)]
        [TestCase("Druid's vestments", 57)]
        [TestCase("Silver raven figurine of wondrous power", 58)]
        [TestCase("Amulet of health +2", 59)]
        [TestCase("Bracers of armor +2", 60)]
        [TestCase("Cloak of charisma +2", 61)]
        [TestCase("Cloak of resistance +2", 62)]
        [TestCase("Gauntlets of ogre power", 63)]
        [TestCase("Gloves of arrow snaring", 64)]
        [TestCase("Gloves of dexterity +2", 65)]
        [TestCase("Headband of intellect +2", 66)]
        [TestCase("Clear spindle ioun stone", 67)]
        [TestCase("Keoghtom's ointment", 68)]
        [TestCase("Nolzur's marvelous pigments", 69)]
        [TestCase("2nd-level spell pearl of power", 70)]
        [TestCase("Periapt of wisdom +2", 71)]
        [TestCase("Stone salve", 72)]
        [TestCase("Necklace of fireballs type III", 73)]
        [TestCase("Circlet of persuasion", 74)]
        [TestCase("Slippers of spider climbing", 75)]
        [TestCase("Incense of meditation", 76)]
        [TestCase("Bag of holding type II", 77)]
        [TestCase("Lesser bracers of archery", 78)]
        [TestCase("Dusty rose prism ioun stone", 79)]
        [TestCase("Helm of comprehend languages and read magic", 80)]
        [TestCase("Vest of escape", 81)]
        [TestCase("Eversmoking bottle", 82)]
        [TestCase("Murlynd's spoon", 83)]
        [TestCase("Necklace of fireballs type IV", 84)]
        [TestCase("Boots of striding and springing", 85)]
        [TestCase("Wind fan", 86)]
        [TestCase("Amulet of mighty fists +1", 87)]
        [TestCase("Horseshoes of a zephyr", 88)]
        [TestCase("Pipes of haunting", 89)]
        [TestCase("Necklace of fireballs type V", 90)]
        [TestCase("Gloves of swimming and climbing", 91)]
        [TestCase("Tan bag of tricks", 92)]
        [TestCase("Minor circlet of blasting", 93)]
        [TestCase("Horn of goodness/evil", 94)]
        [TestCase("Robe of useful items", 95)]
        [TestCase("Folding boat", 96)]
        [TestCase("Cloak of the manta ray", 97)]
        [TestCase("Bottle of air", 98)]
        [TestCase("Bag of holding type III", 99)]
        [TestCase("Periapt of health", 100)]
        public void Percentile(String content, Int32 roll)
        {
            AssertPercentile(content, roll);
        }
    }
}