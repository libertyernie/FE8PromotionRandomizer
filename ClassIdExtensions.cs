using System;
using System.Collections.Generic;
using System.Linq;

namespace FE8PromotionRandomizer
{
    public static class ClassIdExtensions
    {
        public static readonly IReadOnlyList<ClassId> Tier0 = new[]
        {
            ClassId.JOURNEYMAN_1_M,
            ClassId.PUPIL_1_M,
            ClassId.RECRUIT_1_F,
        };

        public static readonly IReadOnlyList<ClassId> Avoid = new[]
        {
            ClassId.UNUSED_MANAKETE,
            ClassId.GORGON_EGG_34,
            ClassId.MANAKETE_MORVA_M,
            ClassId.UNUSED_BARD_M,
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

        public static readonly IReadOnlyList<ClassId> CharacterSpecific = new[]
        {
            ClassId.LORD_M,
            ClassId.LORD_F,
            ClassId.GREAT_LORD_M,
            ClassId.GREAT_LORD_F,
            ClassId.MANAKETE_MYRRH_F
        };

        public static IEnumerable<ClassId> Available
        {
            get
            {
                foreach (ClassId val in Enum.GetValues(typeof(ClassId)))
                {
                    if (Tier0.Contains(val)) continue;
                    if (Avoid.Contains(val)) continue;
                    if (CharacterSpecific.Contains(val)) continue;
                    yield return val;
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
