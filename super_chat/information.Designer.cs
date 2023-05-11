namespace super_chat
{
    partial class information
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
            this.name = new System.Windows.Forms.Label();
            this.account = new System.Windows.Forms.Label();
            this.sex = new System.Windows.Forms.Label();
            this.birth = new System.Windows.Forms.Label();
            this.constellation = new System.Windows.Forms.Label();
            this.signature = new System.Windows.Forms.Label();
            this.actbox = new System.Windows.Forms.TextBox();
            this.namebox = new System.Windows.Forms.TextBox();
            this.conbox = new System.Windows.Forms.TextBox();
            this.sigbox = new System.Windows.Forms.TextBox();
            this.editbtn = new System.Windows.Forms.Button();
            this.reservebtn = new System.Windows.Forms.Button();
            this.man = new System.Windows.Forms.RadioButton();
            this.woman = new System.Windows.Forms.RadioButton();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.mailbox = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.addbtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Font = new System.Drawing.Font("Microsoft YaHei UI", 12.10084F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.name.Location = new System.Drawing.Point(219, 38);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(94, 27);
            this.name.TabIndex = 0;
            this.name.Text = "昵       称";
            // 
            // account
            // 
            this.account.AutoSize = true;
            this.account.Font = new System.Drawing.Font("Microsoft YaHei UI", 12.10084F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.account.Location = new System.Drawing.Point(219, 97);
            this.account.Name = "account";
            this.account.Size = new System.Drawing.Size(94, 27);
            this.account.TabIndex = 1;
            this.account.Text = "账       号";
            // 
            // sex
            // 
            this.sex.AutoSize = true;
            this.sex.Font = new System.Drawing.Font("Microsoft YaHei UI", 12.10084F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sex.Location = new System.Drawing.Point(219, 151);
            this.sex.Name = "sex";
            this.sex.Size = new System.Drawing.Size(88, 27);
            this.sex.TabIndex = 2;
            this.sex.Text = "性      别";
            // 
            // birth
            // 
            this.birth.AutoSize = true;
            this.birth.Font = new System.Drawing.Font("Microsoft YaHei UI", 12.10084F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.birth.Location = new System.Drawing.Point(46, 250);
            this.birth.Name = "birth";
            this.birth.Size = new System.Drawing.Size(94, 27);
            this.birth.TabIndex = 3;
            this.birth.Text = "生       日";
            // 
            // constellation
            // 
            this.constellation.AutoSize = true;
            this.constellation.Font = new System.Drawing.Font("Microsoft YaHei UI", 12.10084F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.constellation.Location = new System.Drawing.Point(47, 300);
            this.constellation.Name = "constellation";
            this.constellation.Size = new System.Drawing.Size(94, 27);
            this.constellation.TabIndex = 4;
            this.constellation.Text = "星       座";
            // 
            // signature
            // 
            this.signature.AutoSize = true;
            this.signature.Font = new System.Drawing.Font("Microsoft YaHei UI", 12.10084F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.signature.Location = new System.Drawing.Point(46, 407);
            this.signature.Name = "signature";
            this.signature.Size = new System.Drawing.Size(92, 27);
            this.signature.TabIndex = 5;
            this.signature.Text = "个性签名";
            // 
            // actbox
            // 
            this.actbox.Location = new System.Drawing.Point(337, 97);
            this.actbox.Name = "actbox";
            this.actbox.Size = new System.Drawing.Size(143, 27);
            this.actbox.TabIndex = 6;
            this.actbox.TextChanged += new System.EventHandler(this.actbox_ReadOnlyChanged);
            // 
            // namebox
            // 
            this.namebox.Location = new System.Drawing.Point(337, 38);
            this.namebox.Name = "namebox";
            this.namebox.Size = new System.Drawing.Size(141, 27);
            this.namebox.TabIndex = 7;
            // 
            // conbox
            // 
            this.conbox.Location = new System.Drawing.Point(172, 302);
            this.conbox.Name = "conbox";
            this.conbox.Size = new System.Drawing.Size(141, 27);
            this.conbox.TabIndex = 10;
            // 
            // sigbox
            // 
            this.sigbox.Location = new System.Drawing.Point(172, 409);
            this.sigbox.Multiline = true;
            this.sigbox.Name = "sigbox";
            this.sigbox.Size = new System.Drawing.Size(308, 221);
            this.sigbox.TabIndex = 11;
            // 
            // editbtn
            // 
            this.editbtn.Location = new System.Drawing.Point(47, 478);
            this.editbtn.Name = "editbtn";
            this.editbtn.Size = new System.Drawing.Size(93, 29);
            this.editbtn.TabIndex = 12;
            this.editbtn.Text = "编辑";
            this.editbtn.UseVisualStyleBackColor = true;
            this.editbtn.Click += new System.EventHandler(this.editbtn_Click);
            // 
            // reservebtn
            // 
            this.reservebtn.Location = new System.Drawing.Point(47, 530);
            this.reservebtn.Name = "reservebtn";
            this.reservebtn.Size = new System.Drawing.Size(93, 29);
            this.reservebtn.TabIndex = 13;
            this.reservebtn.Text = "保存";
            this.reservebtn.UseVisualStyleBackColor = true;
            this.reservebtn.Click += new System.EventHandler(this.reservebtn_Click);
            // 
            // man
            // 
            this.man.AutoSize = true;
            this.man.Font = new System.Drawing.Font("Microsoft YaHei UI", 12.10084F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.man.Location = new System.Drawing.Point(339, 147);
            this.man.Name = "man";
            this.man.Size = new System.Drawing.Size(50, 31);
            this.man.TabIndex = 14;
            this.man.TabStop = true;
            this.man.Text = "男";
            this.man.UseVisualStyleBackColor = true;
            this.man.CheckedChanged += new System.EventHandler(this.man_CheckedChanged);
            // 
            // woman
            // 
            this.woman.AutoSize = true;
            this.woman.Font = new System.Drawing.Font("Microsoft YaHei UI", 12.10084F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.woman.Location = new System.Drawing.Point(430, 147);
            this.woman.Name = "woman";
            this.woman.Size = new System.Drawing.Size(50, 31);
            this.woman.TabIndex = 15;
            this.woman.TabStop = true;
            this.woman.Text = "女";
            this.woman.UseVisualStyleBackColor = true;
            this.woman.CheckedChanged += new System.EventHandler(this.woman_CheckedChanged);
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker.Location = new System.Drawing.Point(172, 250);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(141, 27);
            this.dateTimePicker.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12.10084F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(47, 349);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 27);
            this.label1.TabIndex = 17;
            this.label1.Text = "邮      箱";
            // 
            // mailbox
            // 
            this.mailbox.Location = new System.Drawing.Point(172, 349);
            this.mailbox.Name = "mailbox";
            this.mailbox.Size = new System.Drawing.Size(306, 27);
            this.mailbox.TabIndex = 18;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(22, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(146, 167);
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // addbtn
            // 
            this.addbtn.Location = new System.Drawing.Point(48, 194);
            this.addbtn.Name = "addbtn";
            this.addbtn.Size = new System.Drawing.Size(93, 29);
            this.addbtn.TabIndex = 20;
            this.addbtn.Text = "添加图片";
            this.addbtn.UseVisualStyleBackColor = true;
            this.addbtn.Click += new System.EventHandler(this.addbtn_Click);
            // 
            // information
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 672);
            this.Controls.Add(this.addbtn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.mailbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.woman);
            this.Controls.Add(this.man);
            this.Controls.Add(this.reservebtn);
            this.Controls.Add(this.editbtn);
            this.Controls.Add(this.sigbox);
            this.Controls.Add(this.conbox);
            this.Controls.Add(this.namebox);
            this.Controls.Add(this.actbox);
            this.Controls.Add(this.signature);
            this.Controls.Add(this.constellation);
            this.Controls.Add(this.birth);
            this.Controls.Add(this.sex);
            this.Controls.Add(this.account);
            this.Controls.Add(this.name);
            this.Name = "information";
            this.Text = "个人资料";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label name;
        private Label account;
        private Label sex;
        private Label birth;
        private Label constellation;
        private Label signature;
        private TextBox actbox;
        private TextBox namebox;
        private TextBox conbox;
        private TextBox sigbox;
        private Button editbtn;
        private Button reservebtn;
        private RadioButton man;
        private RadioButton woman;
        private DateTimePicker dateTimePicker;
        private Label label1;
        private TextBox mailbox;
        private PictureBox pictureBox1;
        private Button addbtn;
    }
}