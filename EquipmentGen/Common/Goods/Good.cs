﻿using System;

namespace EquipmentGen.Common.Goods
{
    public class Good
    {
        public String Description { get; set; }
        public Int32 ValueInGold { get; set; }

        public Good()
        {
            Description = String.Empty;
        }
    }
}