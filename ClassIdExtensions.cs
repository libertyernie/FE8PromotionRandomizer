using System;
using System.Collections.Generic;
using System.Linq;

namespace FE8PromotionRandomizer
{
    public static class ClassIdExtensions
    {
        public static readonly IReadOnlyList<ClassId> Unused = new[]
        {
            ClassId.UNUSED_MANAKETE,
            ClassId.UNUSED_MERCENARY_F,
            ClassId.UNUSED_HERO_F,
            ClassId.UNUSED_WYVERN_RIDER_F,
            ClassId.UNUSED_WYVERN_LORD_F,
            ClassId.UNUSED_SHAMAN_F,
            ClassId.UNUSED_DRUID_F,
            ClassId.UNUSED_SUMMONER_F,
            ClassId.GORGON_EGG_34,
            ClassId.MANAKETE_MORVA_M,
            ClassId.JOURNEYMAN_1_M,
            ClassId.PUPIL_1_M,
            ClassId.UNUSED_BARD_M,
            ClassId.RECRUIT_1_F,
            ClassId.NECROMANCER_M,
            ClassId.FLEET,
            ClassId.PHANTOM,
            ClassId.GORGON_EGG_62,
            ClassId.DRACO_ZOMBIE,
            ClassId.DEMON_KING_M,
            ClassId.BALLISTA_67,
            ClassId.BALLISTA_68,
            ClassId.BALLISTA_69,
            ClassId.BALLISTA_6A,
            ClassId.BALLISTA_6B,
            ClassId.BALLISTA_6C,
            ClassId.CIVILIAN_6D_M,
            ClassId.CIVILIAN_6E_F,
            ClassId.CIVILIAN_6F_M,
            ClassId.CIVILIAN_70_F,
            ClassId.CIVILIAN_71_M,
            ClassId.CIVILIAN_72_F,
            ClassId.PRINCE_73_M,
            ClassId.QUEEN_74_F,
            ClassId.PRINCE_75_M,
            ClassId.QUEEN_76_F,
            ClassId.LIGHT_RUNE,
            ClassId.UNCONCIOUS_BARD_M,
            ClassId.CONVOY,
            ClassId.PONTIFEX_M,
            ClassId.UNCONCIOUS_PRINCE_M,
            ClassId.CYCLOPS_7C_M,
            ClassId.ELDER_BAEL_7D
        };

        public static IEnumerable<ClassId> Used
        {
            get
            {
                foreach (ClassId val in Enum.GetValues(typeof(ClassId)))
                {
                    if (!Unused.Contains(val)) yield return val;
                }
            }
        }

        public static IEnumerable<ClassId> Male
        {
            get
            {
                foreach (ClassId val in Enum.GetValues(typeof(ClassId)))
                {
                    if ($"{val}".EndsWith("_M")) yield return val;
                }
            }
        }

        public static IEnumerable<ClassId> Female
        {
            get
            {
                foreach (ClassId val in Enum.GetValues(typeof(ClassId)))
                {
                    if ($"{val}".EndsWith("_F")) yield return val;
                }
            }
        }

        public static IEnumerable<ClassId> NotGenderLocked
        {
            get
            {
                foreach (ClassId f in Female)
                {
                    foreach (ClassId m in Male)
                    {
                        if ($"{f}".Replace("_F", "") == $"{m}".Replace("_M", ""))
                        {
                            yield return f;
                            yield return m;
                        }
                    }
                }
            }
        }

        public static IEnumerable<ClassId> GenderLocked =>
            Enumerable.Empty<ClassId>()
            .Concat(Male)
            .Concat(Female)
            .Except(NotGenderLocked);

        public static IEnumerable<ClassId> Monsters
        {
            get
            {
                yield return ClassId.GORGON_EGG_34;
                for (ClassId i = ClassId.REVENANT; i <= ClassId.DRACO_ZOMBIE; i++) yield return i;
                yield return ClassId.CYCLOPS_7C_M;
                yield return ClassId.ELDER_BAEL_7D;
            }
        }
    }
}
