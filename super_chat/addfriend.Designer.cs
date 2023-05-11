namespace super_chat
{
    partial class addfriend
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.actbox = new System.Windows.Forms.TextBox();
            this.namebox = new System.Windows.Forms.TextBox();
            this.sexbox = new System.Windows.Forms.TextBox();
            this.sigbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12.10084F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(173, 400);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 50);
            this.button1.TabIndex = 0;
            this.button1.Text = "添加好友";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12.10084F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(61, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "账      号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 12.10084F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(61, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 27);
            this.label2.TabIndex = 2;
            this.label2.Text = "昵      称";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 12.10084F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(61, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 27);
            this.label3.TabIndex = 3;
            this.label3.Text = "性      别";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 12.10084F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(57, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 27);
            this.label4.TabIndex = 4;
            this.label4.Text = "个性签名";
            // 
            // actbox
            // 
            this.actbox.Location = new System.Drawing.Point(173, 44);
            this.actbox.Name = "actbox";
            this.actbox.Size = new System.Drawing.Size(225, 27);
            this.actbox.TabIndex = 5;
            // 
            // namebox
            // 
            this.namebox.Location = new System.Drawing.Point(173, 84);
            this.namebox.Name = "namebox";
            this.namebox.Size = new System.Drawing.Size(225, 27);
            this.namebox.TabIndex = 6;
            // 
            // sexbox
            // 
            this.sexbox.Location = new System.Drawing.Point(173, 127);
            this.sexbox.Name = "sexbox";
            this.sexbox.Size = new System.Drawing.Size(225, 27);
            this.sexbox.TabIndex = 7;
            // 
            // sigbox
            // 
            this.sigbox.Location = new System.Drawing.Point(173, 173);
            this.sigbox.Multiline = true;
            this.sigbox.Name = "sigbox";
            this.sigbox.Size = new System.Drawing.Size(225, 187);
            this.sigbox.TabIndex = 8;
            // 
            // addfriend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 476);
            this.Controls.Add(this.sigbox);
            this.Controls.Add(this.sexbox);
            this.Controls.Add(this.namebox);
            this.Controls.Add(this.actbox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "addfriend";
            this.Text = "寻找好友";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox actbox;
        private TextBox namebox;
        private TextBox sexbox;
        private TextBox sigbox;
    }
}