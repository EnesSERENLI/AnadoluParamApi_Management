using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnadoluParamApi.Base.Types
{
    public enum UnitTypeEnum //Sales types of products will be determined. Will be grams, pieces or liters
    {
        [Description(UnitType.Solid)]
        Solid = 1,

        [Description(UnitType.Liquid)]
        Liquid = 2,

        [Description(UnitType.powder)]
        Powder = 3
    }

    public class UnitType
    {
        public const string Solid = "piece";
        public const string Liquid = "liter";
        public const string powder = "gram";
    }
}
