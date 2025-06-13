namespace ZX_s_PC_Checker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new Label();
            label2 = new Label();
            checkBox1 = new CheckBox();
            label3 = new Label();
            label4 = new Label();
            button1 = new Button();
            textBox1 = new TextBox();
            button3 = new Button();
            label5 = new Label();
            button2 = new Button();
            label6 = new Label();
            button4 = new Button();
            button5 = new Button();
            label7 = new Label();
            button6 = new Button();
            button7 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(279, 5);
            label1.Name = "label1";
            label1.Size = new Size(183, 30);
            label1.TabIndex = 0;
            label1.Text = "ZX's PC CHECKER";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(280, 37);
            label2.Name = "label2";
            label2.Size = new Size(187, 21);
            label2.TabIndex = 1;
            label2.Text = "Made by xi3_x on Discord";
            label2.Click += label2_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Checked = true;
            checkBox1.CheckState = CheckState.Checked;
            checkBox1.Location = new Point(10, 318);
            checkBox1.Margin = new Padding(3, 2, 3, 2);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(670, 19);
            checkBox1.TabIndex = 3;
            checkBox1.Text = "I allow access to 3rd party applications on my pc and I allow a PC Checker to access, edit, modify, and view files on my PC.";
            checkBox1.TextAlign = ContentAlignment.MiddleCenter;
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(468, 17);
            label3.Name = "label3";
            label3.Size = new Size(29, 15);
            label3.TabIndex = 4;
            label3.Text = "V1.2";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(718, 7);
            label4.Name = "label4";
            label4.Size = new Size(19, 21);
            label4.TabIndex = 5;
            label4.Text = "X";
            label4.Click += label4_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.Black;
            button1.ForeColor = Color.Transparent;
            button1.Location = new Point(246, 262);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(132, 36);
            button1.TabIndex = 6;
            button1.Text = "Manual PC Check";
            button1.UseVisualStyleBackColor = false;
            button1.Visible = false;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.Black;
            textBox1.ForeColor = SystemColors.Info;
            textBox1.Location = new Point(313, 90);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(119, 23);
            textBox1.TabIndex = 8;
            // 
            // button3
            // 
            button3.BackColor = Color.Black;
            button3.ForeColor = Color.Transparent;
            button3.Location = new Point(313, 115);
            button3.Margin = new Padding(3, 2, 3, 2);
            button3.Name = "button3";
            button3.Size = new Size(118, 26);
            button3.TabIndex = 9;
            button3.Text = "Verify";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click_1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label5.Location = new Point(313, 67);
            label5.Name = "label5";
            label5.Size = new Size(98, 21);
            label5.TabIndex = 10;
            label5.Text = "Access code:";
            // 
            // button2
            // 
            button2.BackColor = Color.Black;
            button2.ForeColor = Color.Transparent;
            button2.Location = new Point(383, 262);
            button2.Margin = new Padding(3, 2, 3, 2);
            button2.Name = "button2";
            button2.Size = new Size(140, 36);
            button2.TabIndex = 11;
            button2.Text = "Automatic PC Check";
            button2.UseVisualStyleBackColor = false;
            button2.Visible = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(13, 7);
            label6.Name = "label6";
            label6.Size = new Size(100, 15);
            label6.TabIndex = 12;
            label6.Text = "Logged in as User";
            label6.Visible = false;
            // 
            // button4
            // 
            button4.BackColor = Color.Black;
            button4.ForeColor = Color.White;
            button4.Location = new Point(246, 222);
            button4.Margin = new Padding(3, 2, 3, 2);
            button4.Name = "button4";
            button4.Size = new Size(132, 36);
            button4.TabIndex = 13;
            button4.Text = "Advanced PC Check";
            button4.UseVisualStyleBackColor = false;
            button4.Visible = false;
            // 
            // button5
            // 
            button5.BackColor = Color.Black;
            button5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button5.ForeColor = Color.White;
            button5.Location = new Point(384, 222);
            button5.Name = "button5";
            button5.Size = new Size(139, 36);
            button5.TabIndex = 14;
            button5.Text = "Coming Soon";
            button5.UseVisualStyleBackColor = false;
            button5.Visible = false;
            button5.Click += button5_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = SystemColors.ControlDarkDark;
            label7.Location = new Point(280, 301);
            label7.Name = "label7";
            label7.Size = new Size(189, 15);
            label7.TabIndex = 15;
            label7.Text = "Continue with guest check instead";
            label7.Click += label7_Click;
            // 
            // button6
            // 
            button6.BackColor = Color.Black;
            button6.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button6.Location = new Point(246, 182);
            button6.Name = "button6";
            button6.Size = new Size(132, 35);
            button6.TabIndex = 16;
            button6.Text = "Anticheat (Coming Soon)";
            button6.UseVisualStyleBackColor = false;
            button6.Visible = false;
            // 
            // button7
            // 
            button7.BackColor = Color.Black;
            button7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button7.Location = new Point(384, 182);
            button7.Name = "button7";
            button7.Size = new Size(140, 35);
            button7.TabIndex = 17;
            button7.Text = "Coming Soon";
            button7.UseVisualStyleBackColor = false;
            button7.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(745, 345);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(label7);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(label6);
            Controls.Add(button2);
            Controls.Add(label5);
            Controls.Add(button3);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(checkBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            ForeColor = SystemColors.ButtonHighlight;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "\\";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private CheckBox checkBox1;
        private Label label3;
        private Label label4;
        private Button button1;
        private TextBox textBox1;
        private Button button3;
        private Label label5;
        private Button button2;
        private Label label6;
        private Button button4;
        private Button button5;
        private Label label7;
        private Button button6;
        private Button button7;
    }
}
