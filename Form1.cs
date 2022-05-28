using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FE8PromotionRandomizer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using var fd = new OpenFileDialog();
            if (fd.ShowDialog(this) == DialogResult.OK)
                textBox1.Text = fd.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using var fd = new SaveFileDialog();
            if (fd.ShowDialog(this) == DialogResult.OK)
                textBox2.Text = fd.FileName;
        }

        private unsafe void button3_Click(object sender, EventArgs e)
        {
            byte[] data = File.ReadAllBytes(textBox1.Text);

            bool isValidClass(byte i)
            {
                if (i <= 0x04) return false; // Eirika & Ephraim
                if (i == 0x0E) return false; // Unused manakete
                if (i == 0x10) return false; // Unused female mercenary
                if (i == 0x12) return false; // Unused female hero (Echidna?)
                if (i == 0x20) return false; // Unused female wyvern rider (Milady?)
                if (i == 0x22) return false; // Unused female wyvern lord
                if (i == 0x2E) return false; // Unused female shaman (Sophia?)
                if (i == 0x30) return false; // Unused female druid
                if (i == 0x32) return false; // Unused female summoner
                if (i == 0x34) return false; // Gorgon egg
                if (i == 0x3B) return false; // Morva
                if (i == 0x3C) return false; // Myrrh
                if (i == 0x3D) return false; // Ross (tier 0)
                if (i == 0x3E) return false; // Ewan (tier 0) - hard-coded to remove anima rank on Shaman promotion
                if (i == 0x46) return false; // Nils
                if (i == 0x47) return false; // Amelia (tier 0)
                if (i == 0x4D) return false; // Tethys
                if (i == 0x4E) return false; // Soldier

                if (i == 0x4F) return false; // Lyon
                if (i == 0x50) return false; // Fleet (can only move on water)
                if (i == 0x51) return false; // Phantom

                if (i >= 0x52 && i <= 0x66) return false; // Monsters
                if (i >= 0x67 && i <= 0x6C) return false; // Ballistae
                if (i >= 0x6D && i <= 0x72) return false; // Civilians
                if (i >= 0x73 && i <= 0x7B) return false; // Story sprites and leftovers from Blazing Blade
                if (i >= 0x7C && i <= 0x7D) return false; // Monsters

                return true;
            }

            var human_classes = Enumerable.Range(0x01, 0x7F)
                .Select(x => (byte)x)
                .Where(x => isValidClass(x))
                .ToList();

            bool isPromoted(byte id)
            {
                fixed (byte* ptr = data)
                {
                    byte* classPtr = ptr + 0x807110 + id * sizeof(CharacterClass);
                    return (classPtr[41] & 1) != 0;
                }
            }

            var promoted = human_classes.Where(isPromoted).ToHashSet();
            var unpromoted = human_classes.Except(promoted);

            static IEnumerable<byte> extractIds(string str)
            {
                foreach (string x in str.Split(' '))
                    if (int.TryParse(x, System.Globalization.NumberStyles.HexNumber, null, out int i))
                        yield return (byte)i;
            }

            var male = extractIds("1 3 5 7 9 b d f 11 13 15 17 19 1b 1d 1f 21 23 25 27 29 2b 2d 2f 31 33 35 38 39 3b 3d 3e 3f 40 41 42 43 44 45 46 4e 4f 7e 7f").ToList();
            var female = extractIds("2 4 6 8 a c 14 16 18 1a 1c 1e 24 26 28 2a 2c 36 37 3a 3c 47 48 49 4a 4b 4c 4d").ToList();

            var gender_locked = extractIds("1 3 d f 11 1f 21 2d 2f 31 33 38 39 3d 3e 3f 40 41 42 43 44 45 4e 4f 7e 7f 2 4 37 3a 3c 47 48 49 4a 4b 4c 4d").ToList();

            var flyers = extractIds("1f 20 21 22 23 24 48 49 63 64");

            var rand = new Random();

            fixed (byte* ptr = data)
            {
                var used = new List<byte>();
                foreach (byte lowerTierId in unpromoted.OrderBy(x => rand.Next()))
                {
                    var lowerTierPtr = (CharacterClass*)(ptr + 0x807110 + lowerTierId * sizeof(CharacterClass));

                    var validGender = new HashSet<byte>();
                    if (male.Contains(lowerTierId))
                        foreach (byte b in male)
                            validGender.Add(b);
                    if (female.Contains(lowerTierId))
                        foreach (byte b in female)
                            validGender.Add(b);
                    if (!chkGenderLock.Checked)
                        foreach (byte b in gender_locked)
                            validGender.Add(b);

                    byte* promotions = ptr + 0x95DFA4 + 2 * lowerTierId;

                    var validPromos = new HashSet<byte>();
                    foreach (byte higherTierId in promoted)
                    {
                        if (male.Contains(higherTierId) || female.Contains(higherTierId))
                            if (!validGender.Contains(higherTierId))
                                continue;
                        if (!chkIncludeSummoner.Checked && higherTierId == 0x31) continue;
                        if (!chkIncludeSummoner.Checked && higherTierId == 0x32) continue;

                        CharacterClass* higherTierPtr = (CharacterClass*)(ptr + 0x807110 + higherTierId * sizeof(CharacterClass));
                        if (!higherTierPtr->IsValidPromotionFor(*lowerTierPtr, allowLoseRank: chkAllowLoseRank.Checked, magicLock: !chkNoMagicLock.Checked)) continue;

                        if (chkflyerExclusivity.Checked && !flyers.Contains(lowerTierId) && flyers.Contains(higherTierId)) continue;

                        validPromos.Add(higherTierId);
                    }

                    var oldPromos = new HashSet<byte> { promotions[0], promotions[1] };

                    var requiredPromos = Enumerable.Empty<byte>();

                    var shuffledPromos =
                        validPromos
                        .Except(requiredPromos)
                        .OrderBy(_ => 0)
                        .ThenBy(x => chkPreferUnused.Checked ? used.Where(n => n == x).Count() : 1)
                        .ThenBy(x => rand.Next());

                    var newPromos = requiredPromos.Concat(shuffledPromos).Take(2).ToList();

                    var unusedPromos = validPromos.Except(newPromos);

                    Console.Write(ClassNames.Names[lowerTierId]);

                    Console.Write(": ");

                    Console.Write(string.Join(" / ", newPromos.Select(x => ClassNames.Names[x])));

                    if (oldPromos.SetEquals(newPromos))
                        Console.Write(" (same)");

                    Console.WriteLine();

                    promotions[0] = newPromos[0];
                    promotions[1] = newPromos[1];

                    used.Add(newPromos[0]);
                    used.Add(newPromos[1]);
                }
            }

            File.WriteAllBytes(textBox2.Text, data);

            Close();
        }
    }
}