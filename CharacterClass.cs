using System.Runtime.InteropServices;

namespace FE8PromotionRandomizer
{
    [StructLayout(LayoutKind.Explicit, Size = 0x54)]
    public struct CharacterClass
    {
        [FieldOffset(44)]
        public byte swords;
        [FieldOffset(45)]
        public byte lances;
        [FieldOffset(46)]
        public byte axes;
        [FieldOffset(47)]
        public byte bows;
        [FieldOffset(48)]
        public byte staves;
        [FieldOffset(49)]
        public byte anima;
        [FieldOffset(50)]
        public byte light;
        [FieldOffset(51)]
        public byte dark;

        public int TomeExp => anima + light + dark;

        public bool IsValidPromotionFor(CharacterClass lowerTierClass, bool allowLoseRank, bool magicLock)
        {
            bool isInvalid(int l, int h) =>
                allowLoseRank
                ? l != 0 && h == 0
                : l > h;
            if (isInvalid(lowerTierClass.swords, swords)) return false;
            if (isInvalid(lowerTierClass.lances, lances)) return false;
            if (isInvalid(lowerTierClass.axes, axes)) return false;
            if (isInvalid(lowerTierClass.bows, bows)) return false;
            if (isInvalid(lowerTierClass.staves, staves)) return false;
            if (magicLock)
            {
                if (isInvalid(lowerTierClass.anima, anima)) return false;
                if (isInvalid(lowerTierClass.light, light)) return false;
                if (isInvalid(lowerTierClass.dark, dark)) return false;
            }
            else
            {
                if (isInvalid(lowerTierClass.TomeExp, TomeExp)) return false;
            }
            return true;
        }
    }
}
