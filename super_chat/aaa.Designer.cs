namespace super_chat
{
    partial class aaa
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(aaa));
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.npgsqlCommandBuilder1 = new Npgsql.NpgsqlCommandBuilder();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.search = new System.Windows.Forms.Button();
            this.friendlist = new System.Windows.Forms.FlowLayoutPanel();
            this.friend = new System.Windows.Forms.Button();
            this.group = new System.Windows.Forms.Button();
            this.avatar = new System.Windows.Forms.Button();
            this.Panel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.sendbtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.f1 = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // imageList2
            // 
            this.imageList2.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "90322f431f2eb617e4261d1bb3f6245.png");
            this.imageList2.Images.SetKeyName(1, "960849241e1b4aa98cde01a3185edaa.png");
            this.imageList2.Images.SetKeyName(2, "d4adf6befc7b47a9da9df07fa93dd6b.png");
            // 
            // npgsqlCommandBuilder1
            // 
            this.npgsqlCommandBuilder1.QuotePrefix = "\"";
            this.npgsqlCommandBuilder1.QuoteSuffix = "\"";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(81, 10);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(164, 30);
            this.textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(261, 400);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(580, 136);
            this.textBox2.TabIndex = 4;
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(122, 48);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(93, 29);
            this.search.TabIndex = 7;
            this.search.Text = "搜索";
            this.search.UseVisualStyleBackColor = true;
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // friendlist
            // 
            this.friendlist.AutoScroll = true;
            this.friendlist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.friendlist.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.friendlist.Location = new System.Drawing.Point(81, 96);
            this.friendlist.Name = "friendlist";
            this.friendlist.Size = new System.Drawing.Size(165, 440);
            this.friendlist.TabIndex = 10;
            // 
            // friend
            // 
            this.friend.BackgroundImage = global::super_chat.Properties.Resources.my;
            this.friend.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.friend.FlatAppearance.BorderSize = 0;
            this.friend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.friend.Location = new System.Drawing.Point(12, 123);
            this.friend.Name = "friend";
            this.friend.Size = new System.Drawing.Size(50, 50);
            this.friend.TabIndex = 11;
            this.friend.UseVisualStyleBackColor = true;
            this.friend.Click += new System.EventHandler(this.friend_Click);
            // 
            // group
            // 
            this.group.BackgroundImage = global::super_chat.Properties.Resources.hot;
            this.group.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.group.FlatAppearance.BorderSize = 0;
            this.group.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.group.Location = new System.Drawing.Point(12, 247);
            this.group.Name = "group";
            this.group.Size = new System.Drawing.Size(50, 50);
            this.group.TabIndex = 12;
            this.group.UseVisualStyleBackColor = true;
            this.group.Click += new System.EventHandler(this.group_Click);
            // 
            // avatar
            // 
            this.avatar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.avatar.FlatAppearance.BorderSize = 0;
            this.avatar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.avatar.Location = new System.Drawing.Point(12, 10);
            this.avatar.Name = "avatar";
            this.avatar.Size = new System.Drawing.Size(60, 60);
            this.avatar.TabIndex = 13;
            this.avatar.UseVisualStyleBackColor = true;
            this.avatar.Click += new System.EventHandler(this.avatar_Click);
            // 
            // Panel1
            // 
            this.Panel1.AutoScroll = true;
            this.Panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.Panel1.Location = new System.Drawing.Point(261, 38);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(580, 331);
            this.Panel1.TabIndex = 14;
            this.Panel1.SizeChanged += new System.EventHandler(this.Panel1_SizeChanged);
            this.Panel1.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.Panel1_ControlAdded);
            // 
            // sendbtn
            // 
            this.sendbtn.Location = new System.Drawing.Point(747, 504);
            this.sendbtn.Name = "sendbtn";
            this.sendbtn.Size = new System.Drawing.Size(93, 29);
            this.sendbtn.TabIndex = 3;
            this.sendbtn.Text = "发送（&S）";
            this.sendbtn.UseVisualStyleBackColor = true;
            this.sendbtn.Click += new System.EventHandler(this.sendbtn_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12.10084F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(360, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(394, 31);
            this.label1.TabIndex = 15;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // f1
            // 
            this.f1.Location = new System.Drawing.Point(261, 367);
            this.f1.Name = "f1";
            this.f1.Size = new System.Drawing.Size(580, 35);
            this.f1.TabIndex = 16;
            this.f1.WrapContents = false;
            // 
            // aaa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 545);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sendbtn);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.avatar);
            this.Controls.Add(this.group);
            this.Controls.Add(this.friend);
            this.Controls.Add(this.friendlist);
            this.Controls.Add(this.search);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.f1);
            this.Name = "aaa";
            this.Text = "Super_Chat";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ImageList imageList2;
        private Npgsql.NpgsqlCommandBuilder npgsqlCommandBuilder1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button search;
        private FlowLayoutPanel friendlist;
        private Button friend;
        private Button group;
        private Button avatar;
        private FlowLayoutPanel Panel1;
        private Button sendbtn;
        private Label label1;
        private FlowLayoutPanel f1;
    }
}