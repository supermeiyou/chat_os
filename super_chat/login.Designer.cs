namespace super_chat
{
    partial class login
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
            this.actbox = new System.Windows.Forms.TextBox();
            this.pwdbox = new System.Windows.Forms.TextBox();
            this.mailbox = new System.Windows.Forms.TextBox();
            this.confirm = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.rpwdbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 26.01681F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(190, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 57);
            this.label1.TabIndex = 0;
            this.label1.Text = "注册";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.91597F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(73, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = " 用 户 名：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.91597F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(76, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 31);
            this.label3.TabIndex = 2;
            this.label3.Text = "密      码：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.91597F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(76, 284);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 31);
            this.label4.TabIndex = 3;
            this.label4.Text = "邮      箱：";
            // 
            // actbox
            // 
            this.actbox.Location = new System.Drawing.Point(193, 119);
            this.actbox.Name = "actbox";
            this.actbox.Size = new System.Drawing.Size(207, 27);
            this.actbox.TabIndex = 4;
            // 
            // pwdbox
            // 
            this.pwdbox.Location = new System.Drawing.Point(193, 177);
            this.pwdbox.Name = "pwdbox";
            this.pwdbox.PasswordChar = '*';
            this.pwdbox.Size = new System.Drawing.Size(207, 27);
            this.pwdbox.TabIndex = 5;
            // 
            // mailbox
            // 
            this.mailbox.Location = new System.Drawing.Point(193, 288);
            this.mailbox.Name = "mailbox";
            this.mailbox.Size = new System.Drawing.Size(207, 27);
            this.mailbox.TabIndex = 6;
            // 
            // confirm
            // 
            this.confirm.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.91597F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.confirm.Location = new System.Drawing.Point(186, 367);
            this.confirm.Name = "confirm";
            this.confirm.Size = new System.Drawing.Size(117, 56);
            this.confirm.TabIndex = 7;
            this.confirm.Text = "确认";
            this.confirm.UseVisualStyleBackColor = true;
            this.confirm.Click += new System.EventHandler(this.confirm_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.91597F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(73, 226);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 31);
            this.label5.TabIndex = 8;
            this.label5.Text = "确认密码：";
            // 
            // rpwdbox
            // 
            this.rpwdbox.Location = new System.Drawing.Point(193, 230);
            this.rpwdbox.Name = "rpwdbox";
            this.rpwdbox.PasswordChar = '*';
            this.rpwdbox.Size = new System.Drawing.Size(207, 27);
            this.rpwdbox.TabIndex = 9;
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 451);
            this.Controls.Add(this.rpwdbox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.confirm);
            this.Controls.Add(this.mailbox);
            this.Controls.Add(this.pwdbox);
            this.Controls.Add(this.actbox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "注册";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox actbox;
        private TextBox pwdbox;
        private TextBox mailbox;
        private Button confirm;
        private Label label5;
        private TextBox rpwdbox;
    }
}