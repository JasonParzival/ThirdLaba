namespace ThirdLaba
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
            comboBox1 = new ComboBox();
            textFirst = new TextBox();
            textSecond = new TextBox();
            textThird = new TextBox();
            comboBoxFirst = new ComboBox();
            comboBoxSecond = new ComboBox();
            comboBoxThird = new ComboBox();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "+", "-", "*", "/" });
            comboBox1.Location = new Point(245, 36);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 0;
            comboBox1.SelectedIndexChanged += onValueChanged;
            // 
            // textFirst
            // 
            textFirst.Location = new Point(12, 12);
            textFirst.Name = "textFirst";
            textFirst.Size = new Size(125, 27);
            textFirst.TabIndex = 1;
            textFirst.TextChanged += onValueChanged;
            // 
            // textSecond
            // 
            textSecond.Location = new Point(12, 66);
            textSecond.Name = "textSecond";
            textSecond.Size = new Size(125, 27);
            textSecond.TabIndex = 2;
            textSecond.TextChanged += onValueChanged;
            // 
            // textThird
            // 
            textThird.Location = new Point(12, 122);
            textThird.Name = "textThird";
            textThird.Size = new Size(339, 27);
            textThird.TabIndex = 3;
            // 
            // comboBoxFirst
            // 
            comboBoxFirst.FormattingEnabled = true;
            comboBoxFirst.Location = new Point(161, 11);
            comboBoxFirst.Name = "comboBoxFirst";
            comboBoxFirst.Size = new Size(58, 28);
            comboBoxFirst.TabIndex = 4;
            comboBoxFirst.SelectedIndexChanged += onValueChanged;
            // 
            // comboBoxSecond
            // 
            comboBoxSecond.FormattingEnabled = true;
            comboBoxSecond.Location = new Point(161, 65);
            comboBoxSecond.Name = "comboBoxSecond";
            comboBoxSecond.Size = new Size(58, 28);
            comboBoxSecond.TabIndex = 5;
            comboBoxSecond.SelectedIndexChanged += onValueChanged;
            // 
            // comboBoxThird
            // 
            comboBoxThird.FormattingEnabled = true;
            comboBoxThird.Location = new Point(377, 121);
            comboBoxThird.Name = "comboBoxThird";
            comboBoxThird.Size = new Size(58, 28);
            comboBoxThird.TabIndex = 6;
            comboBoxThird.SelectedIndexChanged += onValueChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(447, 176);
            Controls.Add(comboBoxThird);
            Controls.Add(comboBoxSecond);
            Controls.Add(comboBoxFirst);
            Controls.Add(textThird);
            Controls.Add(textSecond);
            Controls.Add(textFirst);
            Controls.Add(comboBox1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox1;
        private TextBox textFirst;
        private TextBox textSecond;
        private TextBox textThird;
        private ComboBox comboBoxFirst;
        private ComboBox comboBoxSecond;
        private ComboBox comboBoxThird;
    }
}
