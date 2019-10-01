using System;

namespace Enums
{
    public enum DieType
    {
        D4,
        D6,
        D8,
        D10,
        D12,
        D20,
    }

    public static class DieTypeExtensions
    {
        public static int ToInt(this DieType dieType)
        {
            switch (dieType)
            {
                case DieType.D4:
                    return 4;
                case DieType.D6:
                    return 6;
                case DieType.D8:
                    return 8;
                case DieType.D10:
                    return 10;
                case DieType.D12:
                    return 12;
                case DieType.D20:
                    return 20;
                default:
                    throw new ArgumentOutOfRangeException(nameof(dieType), dieType, null);
            }
        }
    }
}