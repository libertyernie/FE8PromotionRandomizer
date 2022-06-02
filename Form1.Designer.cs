using System.Windows.Forms;

namespace FE8PromotionRandomizer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.chkGenderLock = new System.Windows.Forms.CheckBox();
            this.chkflyerExclusivity = new System.Windows.Forms.CheckBox();
            this.chkAllowLoseRank = new System.Windows.Forms.CheckBox();
            this.chkNoMagicLock = new System.Windows.Forms.CheckBox();
            this.chkPreferUnused = new System.Windows.Forms.CheckBox();
            this.chkIncludeSummoner = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.chkBindingBladePromotedClasses = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ROM image";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(138, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(403, 20);
            this.textBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(547, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 20);
            this.button1.TabIndex = 2;
            this.button1.Text = "Browse...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Class information offset";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Promo information offset";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Hexadecimal = true;
            this.numericUpDown1.Location = new System.Drawing.Point(138, 38);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            16777216,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 7;
            this.numericUpDown1.Value = new decimal(new int[] {
            8417552,
            0,
            0,
            0});
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Hexadecimal = true;
            this.numericUpDown2.Location = new System.Drawing.Point(138, 64);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            16777216,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown2.TabIndex = 8;
            this.numericUpDown2.Value = new decimal(new int[] {
            9822116,
            0,
            0,
            0});
            // 
            // chkGenderLock
            // 
            this.chkGenderLock.AutoSize = true;
            this.chkGenderLock.Checked = true;
            this.chkGenderLock.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkGenderLock.Location = new System.Drawing.Point(15, 90);
            this.chkGenderLock.Name = "chkGenderLock";
            this.chkGenderLock.Size = new System.Drawing.Size(437, 17);
            this.chkGenderLock.TabIndex = 9;
            this.chkGenderLock.Text = "Only choose classes that have a variant with the same gender as the unpromoted cl" +
    "ass";
            this.chkGenderLock.UseVisualStyleBackColor = true;
            // 
            // chkflyerExclusivity
            // 
            this.chkflyerExclusivity.AutoSize = true;
            this.chkflyerExclusivity.Location = new System.Drawing.Point(15, 113);
            this.chkflyerExclusivity.Name = "chkflyerExclusivity";
            this.chkflyerExclusivity.Size = new System.Drawing.Size(223, 17);
            this.chkflyerExclusivity.TabIndex = 10;
            this.chkflyerExclusivity.Text = "Make sure only flyers can get flyer promos";
            this.chkflyerExclusivity.UseVisualStyleBackColor = true;
            // 
            // chkAllowLoseRank
            // 
            this.chkAllowLoseRank.AutoSize = true;
            this.chkAllowLoseRank.Location = new System.Drawing.Point(15, 136);
            this.chkAllowLoseRank.Name = "chkAllowLoseRank";
            this.chkAllowLoseRank.Size = new System.Drawing.Size(239, 17);
            this.chkAllowLoseRank.TabIndex = 11;
            this.chkAllowLoseRank.Text = "Allow units to lose weapon rank on promotion";
            this.chkAllowLoseRank.UseVisualStyleBackColor = true;
            // 
            // chkNoMagicLock
            // 
            this.chkNoMagicLock.AutoSize = true;
            this.chkNoMagicLock.Location = new System.Drawing.Point(15, 159);
            this.chkNoMagicLock.Name = "chkNoMagicLock";
            this.chkNoMagicLock.Size = new System.Drawing.Size(564, 17);
            this.chkNoMagicLock.TabIndex = 12;
            this.chkNoMagicLock.Text = "Treat all tome rank as the same (since animations are shared among them) when dec" +
    "iding if a promotion is possible";
            this.chkNoMagicLock.UseVisualStyleBackColor = true;
            // 
            // chkPreferUnused
            // 
            this.chkPreferUnused.AutoSize = true;
            this.chkPreferUnused.Location = new System.Drawing.Point(15, 182);
            this.chkPreferUnused.Name = "chkPreferUnused";
            this.chkPreferUnused.Size = new System.Drawing.Size(373, 17);
            this.chkPreferUnused.TabIndex = 13;
            this.chkPreferUnused.Text = "When randomly assigning classes, prefer ones that haven\'t yet been used";
            this.chkPreferUnused.UseVisualStyleBackColor = true;
            // 
            // chkIncludeSummoner
            // 
            this.chkIncludeSummoner.AutoSize = true;
            this.chkIncludeSummoner.Location = new System.Drawing.Point(15, 205);
            this.chkIncludeSummoner.Name = "chkIncludeSummoner";
            this.chkIncludeSummoner.Size = new System.Drawing.Size(417, 17);
            this.chkIncludeSummoner.TabIndex = 14;
            this.chkIncludeSummoner.Text = "Allow the Summoner class on units besides Knoll and Ewan (may not work properly)";
            this.chkIncludeSummoner.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(547, 300);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 20);
            this.button2.TabIndex = 17;
            this.button2.Text = "Browse...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(73, 300);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(468, 20);
            this.textBox2.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 303);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Output file";
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button3.Location = new System.Drawing.Point(262, 326);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(110, 23);
            this.button3.TabIndex = 18;
            this.button3.Text = "Generate";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // chkBindingBladePromotedClasses
            // 
            this.chkBindingBladePromotedClasses.AutoSize = true;
            this.chkBindingBladePromotedClasses.Location = new System.Drawing.Point(15, 228);
            this.chkBindingBladePromotedClasses.Name = "chkBindingBladePromotedClasses";
            this.chkBindingBladePromotedClasses.Size = new System.Drawing.Size(531, 17);
            this.chkBindingBladePromotedClasses.TabIndex = 19;
            this.chkBindingBladePromotedClasses.Text = "Allow unused female classes (e.g. Hero, Wyvern Lord, Druid) by copying promo gain" +
    "s from male equivalents";
            this.chkBindingBladePromotedClasses.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 361);
            this.Controls.Add(this.chkBindingBladePromotedClasses);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkIncludeSummoner);
            this.Controls.Add(this.chkPreferUnused);
            this.Controls.Add(this.chkNoMagicLock);
            this.Controls.Add(this.chkAllowLoseRank);
            this.Controls.Add(this.chkflyerExclusivity);
            this.Controls.Add(this.chkGenderLock);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Button button1;
        private Label label2;
        private Label label3;
        private NumericUpDown numericUpDown1;
        private NumericUpDown numericUpDown2;
        private CheckBox chkGenderLock;
        private CheckBox chkflyerExclusivity;
        private CheckBox chkAllowLoseRank;
        private CheckBox chkNoMagicLock;
        private CheckBox chkPreferUnused;
        private CheckBox chkIncludeSummoner;
        private Button button2;
        private TextBox textBox2;
        private Label label4;
        private Button button3;
        private CheckBox chkBindingBladePromotedClasses;
    }
}