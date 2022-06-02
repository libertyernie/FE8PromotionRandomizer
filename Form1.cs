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
            (sender as Control)!.Enabled = false;

            byte[] data = File.ReadAllBytes(textBox1.Text);

            var human_classes = ClassIdExtensions.Available;

            CharacterClass extractClassInformation(ClassId id)
            {
                fixed (byte* ptr = data)
                {
                    CharacterClass* classPtr = (CharacterClass*)(ptr + (int)numericUpDown1.Value + (byte)id * sizeof(CharacterClass));
                    return *classPtr;
                }
            }

            var promoted = human_classes
                .Where(x => extractClassInformation(x).ability2.HasFlag(Ability2.Promoted))
                .ToHashSet();
            var unpromoted = human_classes.Except(promoted);

            var male = ClassIdExtensions.Male.ToList();
            var female = ClassIdExtensions.Female.ToList();

            var gender_locked = ClassIdExtensions.GenderLocked.ToList();

            var flyers = human_classes
                .Where(x => extractClassInformation(x).Flyer)
                .ToHashSet();

            var rand = new Random();

            using var sw = new StringWriter();

            fixed (byte* ptr = data)
            {
                if (chkBindingBladePromotedClasses.Checked)
                {
                    foreach (var (a, b) in ClassIdExtensions.Pairs)
                    {
                        CharacterClass* ca = (CharacterClass*)(ptr + (int)numericUpDown1.Value + (byte)a * sizeof(CharacterClass));
                        CharacterClass* cb = (CharacterClass*)(ptr + (int)numericUpDown1.Value + (byte)b * sizeof(CharacterClass));

                        if (ca->promotionGains.Any())
                            if (!cb->promotionGains.Any())
                                cb->promotionGains = ca->promotionGains;
                        if (cb->promotionGains.Any())
                            if (!ca->promotionGains.Any())
                                ca->promotionGains = cb->promotionGains;
                    }
                }

                var used = new List<ClassId>();
                foreach (ClassId lowerTierId in unpromoted.OrderBy(x => rand.Next()))
                {
                    var lowerTierPtr = (CharacterClass*)(ptr + (int)numericUpDown1.Value + (byte)lowerTierId * sizeof(CharacterClass));

                    var validGender = new HashSet<ClassId>();
                    if (male.Contains(lowerTierId))
                        foreach (ClassId b in male)
                            validGender.Add(b);
                    if (female.Contains(lowerTierId))
                        foreach (ClassId b in female)
                            validGender.Add(b);
                    if (!chkGenderLock.Checked)
                        foreach (ClassId b in gender_locked)
                            validGender.Add(b);

                    byte* promotions = ptr + (int)numericUpDown2.Value + 2 * (byte)lowerTierId;

                    var oldPromos = new HashSet<ClassId> { (ClassId)promotions[0], (ClassId)promotions[1] };
                    if (oldPromos.Any(x => x == 0))
                        continue;

                    var validPromos = new HashSet<ClassId>(oldPromos);
                    foreach (ClassId higherTierId in promoted)
                    {
                        if (male.Contains(higherTierId) || female.Contains(higherTierId))
                            if (!validGender.Contains(higherTierId))
                                continue;

                        CharacterClass* higherTierPtr = (CharacterClass*)(ptr + (int)numericUpDown1.Value + (byte)higherTierId * sizeof(CharacterClass));
                        if (!chkIncludeSummoner.Checked && higherTierPtr->ability4.HasFlag(Ability4.Summoning)) continue;
                        if (!higherTierPtr->IsValidPromotionFor(*lowerTierPtr, allowLoseRank: chkAllowLoseRank.Checked, magicLock: !chkNoMagicLock.Checked)) continue;

                        if (chkflyerExclusivity.Checked && !flyers.Contains(lowerTierId) && flyers.Contains(higherTierId)) continue;

                        if (!higherTierPtr->promotionGains.Any()) continue;

                        validPromos.Add(higherTierId);
                    }

                    var requiredPromos = Enumerable.Empty<ClassId>();

                    var shuffledPromos =
                        validPromos
                        .Except(requiredPromos)
                        .OrderBy(_ => 0)
                        .ThenBy(x => chkPreferUnused.Checked ? used.Where(n => n == x).Count() : 1)
                        .ThenBy(x => rand.Next());

                    var newPromos = requiredPromos.Concat(shuffledPromos).Take(2).ToList();

                    var unusedPromos = validPromos.Except(newPromos);

                    sw.Write(lowerTierId);

                    sw.Write(": ");

                    sw.Write(string.Join(" / ", newPromos.Select(x => x)));

                    if (oldPromos.SetEquals(newPromos))
                        sw.Write(" (same)");

                    sw.WriteLine();

                    promotions[0] = (byte)newPromos[0];
                    promotions[1] = (byte)newPromos[1];

                    used.Add(newPromos[0]);
                    used.Add(newPromos[1]);
                }
            }

            Console.WriteLine(sw);

            File.WriteAllBytes(textBox2.Text, data);

            MessageBox.Show(this, sw.ToString());

            (sender as Control)!.Enabled = true;
        }
    }
}