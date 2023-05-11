namespace super_chat
{
    partial class signup
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.idbox = new System.Windows.Forms.TextBox();
            this.pwdbox = new System.Windows.Forms.TextBox();
            this.vfbox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.forget = new System.Windows.Forms.Label();
            this.login = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 26.01681F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(143, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 57);
            this.label1.TabIndex = 0;
            this.label1.Text = "欢迎使用";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.91597F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(65, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "用户名：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.91597F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(65, 205);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 31);
            this.label3.TabIndex = 2;
            this.label3.Text = "密   码：";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.91597F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(65, 273);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 31);
            this.label4.TabIndex = 3;
            this.label4.Text = "验证码：";
            // 
            // idbox
            // 
            this.idbox.Location = new System.Drawing.Point(176, 140);
            this.idbox.Name = "idbox";
            this.idbox.Size = new System.Drawing.Size(217, 27);
            this.idbox.TabIndex = 4;
            // 
            // pwdbox
            // 
            this.pwdbox.Location = new System.Drawing.Point(176, 210);
            this.pwdbox.Name = "pwdbox";
            this.pwdbox.PasswordChar = '*';
            this.pwdbox.Size = new System.Drawing.Size(217, 27);
            this.pwdbox.TabIndex = 5;
            // 
            // vfbox
            // 
            this.vfbox.Location = new System.Drawing.Point(176, 278);
            this.vfbox.Name = "vfbox";
            this.vfbox.Size = new System.Drawing.Size(106, 27);
            this.vfbox.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12.10084F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(176, 334);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 50);
            this.button1.TabIndex = 7;
            this.button1.Text = "登录";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // forget
            // 
            this.forget.AutoSize = true;
            this.forget.Font = new System.Drawing.Font("Arial", 10.28571F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.forget.ForeColor = System.Drawing.SystemColors.Highlight;
            this.forget.Location = new System.Drawing.Point(56, 407);
            this.forget.Name = "forget";
            this.forget.Size = new System.Drawing.Size(104, 19);
            this.forget.TabIndex = 8;
            this.forget.Text = "重置密码？";
            this.forget.Click += new System.EventHandler(this.forget_Click);
            // 
            // login
            // 
            this.login.AutoSize = true;
            this.login.Font = new System.Drawing.Font("Arial Narrow", 10.28571F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.login.ForeColor = System.Drawing.SystemColors.Highlight;
            this.login.Location = new System.Drawing.Point(299, 405);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(105, 22);
            this.login.TabIndex = 9;
            this.login.Text = "新用户注册";
            this.login.Click += new System.EventHandler(this.login_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(288, 273);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(105, 32);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // signup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 456);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.login);
            this.Controls.Add(this.forget);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.vfbox);
            this.Controls.Add(this.pwdbox);
            this.Controls.Add(this.idbox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "signup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "signup";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.signup_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox idbox;
        private TextBox pwdbox;
        private TextBox vfbox;
        private Button button1;
        private Label forget;
        private Label login;
        private PictureBox pictureBox1;
    }
}