using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace FE8PromotionRandomizer
{
    [Flags]
    public enum Ability2 : byte
    {
        Promoted = 1,
        Lord = 32
    }

    [Flags]
    public enum Ability4 : byte
    {
        Summoning = 8
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 0x6)]
    public struct PromotionGains
    {
        public byte hp, pow, skl, spd, def, res;

        public bool Any() => new[] { hp, pow, skl, spd, def, res }.Any(x => x != 0);
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x54)]
    public struct CharacterClass
    {
        [FieldOffset(34)]
        public PromotionGains promotionGains;

        [FieldOffset(41)]
        public Ability2 ability2;
        [FieldOffset(43)]
        public Ability4 ability4;

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

        [FieldOffset(56)]
        public int movementCost;

        public bool Flyer => movementCost == 0x880BB96;

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
