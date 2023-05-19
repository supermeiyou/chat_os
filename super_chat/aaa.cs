using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using DbMiddleware;
using System.Timers;
using DbMiddlewarePostgresImpl;
using System.Diagnostics;

namespace super_chat
{
    public partial class aaa : Form
    {
        public IDatabase db;
        public User us;
        public List<RelateModel> relates;
        private int c=1;
        private int type = 1;
        private System.Timers.Timer timer;
        int cnt = 0;
        private List<message> readed;
        public aaa(IDatabase database, User us)
        {
            InitializeComponent();
            Chat_Load(us);
            SetDefaultText();
            textBox1.GotFocus += new EventHandler(textBox1_Enter);
            textBox1.LostFocus += new EventHandler(textBox1_Leave);
            this.db = database;
            this.us = us;
            this.readed = new List<message>();
            friend_Click(this, new EventArgs());
            Panel1.WrapContents = false;
            friendlist.WrapContents = false;
            Thread thread = new Thread(listen);
            thread.Start();

            timer = new System.Timers.Timer();
            timer.Interval = 100;
            timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            //timer.Start();
        }
        private void Btn_Click(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        private void SetDefaultText()
        {
            textBox1.Font = new Font(textBox1.Font, textBox1.Font.Style | FontStyle.Italic);
            textBox1.Text = "搜索好友/群聊";
            textBox1.ForeColor = Color.Gray;
        }
        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "搜索好友/群聊")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                SetDefaultText();
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            new information(db, us).Show();
        }
        private void friend_Click(object sender, EventArgs e)
        {
            Panel1.Controls.Clear();
            type = 1;
            c = 0;
            string url = "D:/桌面/chat_os/images/my.png";
            string url1 = "D:/桌面/chat_os/images/hot.png";
            friend.BackgroundImage = Image.FromFile(url);
            group.BackgroundImage = Image.FromFile(url1);
            friendlist.Controls.Clear();
            var op = new Roperation(db);
            relates = op.GetRelate(us.Useraccount);
            var op1 = new UserOperation(db);
            var a = op1.getIm(us.Useraccount);
            if (a != null)
                avatar.BackgroundImage = Image.FromFile(a.Avatar);
            else
            {
                avatar.BackgroundImage = null;
                avatar.Text = "无";
            }
            foreach (RelateModel relate in relates)
            {
                if (relate.useract == us.Useraccount)
                {
                    var im = op1.getIm(relate.friendact);
                    if (im != null)
                    {
                        Button btn = new Button();
                        btn.Name = im.Name;
                        btn.Click += btn_Click;
                        void btn_Click(object sender, EventArgs e)
                        {
                            label1.Text = btn.Text;
                            Panel1.Controls.Clear();
                            LoadM(relate.useract, relate.friendact);
                        }
                        btn.Width = 155;
                        btn.Height = 70;
                        btn.Text= im.Name;
                        if (im.Avatar != null && im.Avatar != "")
                        {
                            Image i = Image.FromFile(im.Avatar);
                            Image image = this.resizeImage(i, new Size(50, 50));
                            btn.Image = image;
                        }
                        btn.FlatStyle = FlatStyle.Flat;
                        btn.FlatAppearance.BorderSize = 0;
                        btn.ImageAlign = ContentAlignment.MiddleLeft;
                        btn.TextAlign = ContentAlignment.MiddleRight;
                        friendlist.Controls.Add(btn);
                    }
                }
                if (relate.friendact == us.Useraccount)
                {
                    var im = op1.getIm(relate.useract);
                    if (im != null)
                    {
                        Button btn = new Button();
                        btn.Name = im.Name;
                        btn.Click += btn_Click;
                        void btn_Click(object sender, EventArgs e)
                        {
                            label1.Text = btn.Text;
                            LoadM(relate.friendact, relate.useract);
                        }
                        btn.Width = 155;
                        btn.Height = 70;
                        btn.Text = im.Name;
                        if (im.Avatar != null && im.Avatar != "")
                        {
                            Image i = Image.FromFile(im.Avatar);
                            Image image = this.resizeImage(i, new Size(50, 50));
                            btn.Image = image;
                        }
                        btn.FlatStyle = FlatStyle.Flat;
                        btn.FlatAppearance.BorderSize = 0;
                        btn.ImageAlign = ContentAlignment.MiddleLeft;
                        btn.TextAlign = ContentAlignment.MiddleRight;
                        friendlist.Controls.Add(btn);
                    }
                }
            }
        }
        private void group_Click(object sender, EventArgs e)
        {
            Panel1.Controls.Clear();
            type = 0;
            c = 1;
            string url = "D:/桌面/chat_os/images/my1.png";
            string url1 = "D:/桌面/chat_os/images/hot1.png";
            friend.BackgroundImage = Image.FromFile(url);
            group.BackgroundImage = Image.FromFile(url1);
            friendlist.Controls.Clear();

            Button create = new Button();
            create.TextAlign = ContentAlignment.MiddleCenter;
            create.Text = "创建群聊";
            create.FlatStyle = FlatStyle.Flat;
            create.Size =  new Size(156,40);
            friendlist.Controls.Add(create);
            create.Click += btn_Click;
            void btn_Click(object sender, EventArgs e)
            {
                var s = new create_chat(us);
                s.Show();
                s.CloseForm2 += (s, e) =>
                {
                    this.group_Click(this, new EventArgs());
                };
            }

            var ch = new chatoperation(db);
            var l = ch.select(us.Useraccount);
            foreach(var i in l)
            {
                var sql = "select * from public.group";
                var result = db.QueryForTable(sql, null);
                List<chatgroupM> ret = new List<chatgroupM>();
                foreach (var row in result)
                {
                    var model = new chatgroupM(
                        (string)row["group_name"],
                        (string)row["user_id"],
                        (string)row["friend_id"]);
                    ret.Add(model);
                }
                List<string> list = new List<string>();
                foreach (var item in ret)
                {
                    list.Add(item.user1);
                    list.Add(item.user2);
                }
                list = list.Distinct().ToList();
                if (list.Contains(us.Useraccount))
                {
                    Button btn = new Button();
                    btn.Size = new Size(155, 70);
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Text = i.ToString();
                    btn.Name = btn.Text;
                    friendlist.Controls.Add(btn);
                    btn.Click += btn_Click1;
                    void btn_Click1(object sender, EventArgs e)
                    {
                        label1.Text = btn.Text;
                        Panel1.Controls.Clear();
                        LoadM(us.Useraccount, btn.Name);
                    }
                }
                
            }
        }
        private void avatar_Click(object sender, EventArgs e)
        {
            new information(this.db, this.us).Show();
        }
        private void search_Click(object sender, EventArgs e)
        {
            if (us.Useraccount == textBox1.Text)
            {
                MessageBox.Show("不能搜索自己！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox1.Clear();
            }
            else
            {
                bool idfchar = false;
                for(int i = 0; i < textBox1.Text.Length; i++)
                {
                    if ((int)textBox1.Text[i]>127)
                    {
                        idfchar = true;
                        break;
                    }
                }
                if (idfchar)
                {
                    chatoperation cop = new chatoperation(db);
                    if (cop.selectname(textBox1.Text))
                    {
                        new addchat(textBox1.Text,db,us).Show();
                    }
                    else
                    {
                        MessageBox.Show("未找到该群聊！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        textBox1.Clear();
                    }
                }
                else
                {
                    int flag = 1;
                    foreach (var s in relates)
                    {
                        if (s.useract == textBox1.Text || s.friendact == textBox1.Text)
                        {
                            flag = 0;
                            break;
                        }
                    }
                    if (flag == 1)
                    {
                        var op = new UserOperation(db);
                        var f = op.GetUser(textBox1.Text);
                        if (f != null)
                        {
                            User fri = new User(f);
                            new addfriend(db, fri, us).Show();
                            textBox1.Clear();
                        }
                        else
                        {
                            MessageBox.Show("未找到该用户！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            textBox1.Clear();
                        }
                    }
                    else
                    {
                        MessageBox.Show("已添加该用户!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        textBox1.Clear();
                    }
                }
            }
        }
        private void sendbtn_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length <= 200)
            {
                var str = "";
                if (type == 1)
                {
                    if (textBox2.Text != "")
                        foreach (Control c in friendlist.Controls)
                        {
                            if (c is Button)
                                if (c.Name.Equals(label1.Text))
                                {
                                    var op0 = new UserOperation(db);
                                    var r = op0.getIm(label1.Text, 1);
                                    if (r != null)
                                    {
                                        var u = op0.GetUser(r.act);
                                        if (u != null)
                                            str = u.useraccount;
                                    }
                                }
                        }
                } 
                else if (type == 0)
                {
                    if (textBox2.Text != "")
                        str = label1.Text;
                }
                    var op = new UserOperation(db);
                    var im = op.getIm(us.Useraccount);
                    if (im != null)
                    {
                        message m = new message(type, DateTime.Now, im.Avatar, us.Useraccount, str, textBox2.Text, false, db , "1");
                        m.SendMessage(Bubble.L);
                        FlowLayoutPanel panel = new FlowLayoutPanel();
                        panel.Size = new Size(550, 45);
                        panel.FlowDirection = FlowDirection.RightToLeft;
                        panel.WrapContents = false;
                        PictureBox picture = new PictureBox();
                        picture.Size = new Size(40, 40);
                        picture.BackgroundImageLayout = ImageLayout.Stretch;
                        Image image = resizeImage(Image.FromFile(im.Avatar), new Size(40, 40));
                        picture.Image = image;
                        panel.Controls.Add(picture);
                        Label time = new Label();
                        time.Text = DateTime.Now.ToLongTimeString();
                        panel.Controls.Add(time);

                        FlowLayoutPanel panel1 = new FlowLayoutPanel();
                        panel1.FlowDirection = FlowDirection.RightToLeft;
                        panel1.Size = new Size(550, 45);
                        Label text = new Label();
                        text.Dock = DockStyle.Left;
                        text.AutoSize = true;
                        text.Font = new Font("宋体", 12);
                        Graphics graphics = label1.CreateGraphics();
                        SizeF size = graphics.MeasureString(text.Text, text.Font);
                        text.Size = Size.Round(size);
                        text.BorderStyle = BorderStyle.FixedSingle;
                        text.BackColor = Color.LawnGreen;
                        text.Text = m.Content;
                        panel1.Controls.Add(text);

                        Panel1.Controls.Add(panel);
                        Panel1.Controls.Add(panel1);
                        textBox2.Clear();
                    }
            }
            else
            {
                MessageBox.Show("不能超过100字！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void Panel1_SizeChanged(object sender, EventArgs e)
        {
            Panel1.VerticalScroll.Value = Panel1.VerticalScroll.Maximum;
        }
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            Thread clickThread = new Thread(new ThreadStart(ClickButton));
            clickThread.Start();
        }
        private void ClickButton()
        {
            if (label1.Text != "")
            {
                foreach (Control control in friendlist.Controls)
                {
                    if (control is Button)
                    {
                        Button button1 = control as Button;
                        if (button1 !=null)
                        {
                            if (button1.Name == label1.Text)
                            {
                                if (button1.InvokeRequired)
                                {
                                    // 在 UI 线程上执行操作
                                    button1.Invoke(new Action(() =>
                                    {
                                        button1.PerformClick();
                                    }));
                                }
                                else
                                {
                                    button1.PerformClick();
                                }
                            }
                        }
                    }
                }
            }
            
        }
        public void listen()
        {
            while (true)
            {
                List<message> receive = new List<message>();
                if (type==1)
                {
                    receive = new message(db).ReceiveMessage(Bubble.L, us.Useraccount);
                    receive = sort_m(receive);
                }
                else if (type==0)
                {
                    receive = new message(db).ReceiveMessage(Bubble.L, label1.Text);
                    receive = sort_m(receive);
                }
                if (receive.Count > 0)
                {
                    if ( type == 1 && label1.Text!="")
                    {
                        foreach (var m in receive)
                        {   
                            FlowLayoutPanel panel = new FlowLayoutPanel();   
                            panel.FlowDirection = FlowDirection.TopDown;    
                            panel.WrapContents = false;
                            PictureBox picture = new PictureBox();
                            picture.BackgroundImageLayout = ImageLayout.Stretch;
                            var op = new UserOperation(db);
                            var im = op.getIm(m.Uid);    
                            if (im != null)
                            {   
                                Image image = resizeImage(Image.FromFile(im.Avatar), new Size(40, 40));   
                                picture.Image = image;
                                m.Aalid = true;
                                if (m.category == "1") //文字消息
                                {
                                    new message(db).SaveM(m);
                                    Label text = new Label();
                                    text.AutoSize = true;
                                    text.Font = new Font("宋体", 12);
                                    text.BorderStyle = BorderStyle.FixedSingle;
                                    text.Text = m.Content;
                                    panel.Size = new Size(panel.Width + 200, panel.Height);
                                    if (this.IsHandleCreated)
                                    {
                                        this.Invoke(new Action(() =>
                                        {
                                            panel.Controls.Add(picture);
                                            panel.Controls.Add(text);
                                            Panel1.Controls.Add(panel);
                                        }));
                                    }
                                }
                                else if (m.category!="1") //非文字消息
                                {
                                    string fpath = reviveFile(m);
                                    FlowLayoutPanel panel1 = new FlowLayoutPanel();
                                    PictureBox picture1 = new PictureBox();
                                    if (IsRealImage(fpath))         //是图片
                                    {
                                        panel1.Size = new Size(550, 80);
                                        picture1.Size = new Size(80, 80);
                                        picture1.BackgroundImageLayout = ImageLayout.Stretch;
                                        Image image1 = resizeImage(Image.FromFile(fpath), new Size(80, 80));
                                        picture1.Image = image1;
                                        void PictureBox_Click(object sender, EventArgs e)
                                        {
                                            ProcessStartInfo processStartInfo = new ProcessStartInfo(fpath);
                                            Process process = new Process();
                                            process.StartInfo = processStartInfo;
                                            process.StartInfo.UseShellExecute = true;
                                            process.Start();
                                        }
                                        picture1.Click += new System.EventHandler(PictureBox_Click);
                                        new message(db).SaveM(m);
                                    }
                                    else //其他
                                    {
                                        panel1.Size = new Size(550, 80);
                                        picture1.Size = new Size(80, 80);
                                        picture1.BackgroundImageLayout = ImageLayout.Stretch;
                                        Image image1 = resizeImage(Image.FromFile("D:/桌面/chat_os/images/sendfile.png"), new Size(80, 80));
                                        picture1.Image = image1;
                                        void PictureBox_Click(object sender, EventArgs e)
                                        {
                                            ProcessStartInfo processStartInfo = new ProcessStartInfo(fpath);
                                            Process process = new Process();
                                            process.StartInfo = processStartInfo;
                                            process.StartInfo.UseShellExecute = true;
                                            process.Start();
                                        }
                                        picture1.Click += new System.EventHandler(PictureBox_Click);
                                    }
                                    if (this.IsHandleCreated)
                                    {
                                        this.Invoke(new Action(() =>
                                        {
                                            panel.Controls.Add(picture);
                                            panel.Controls.Add(picture1);
                                            Panel1.Controls.Add(panel);
                                        }));
                                    }
                                }
                            }
                        }
                    }
                    if ( type == 0 && label1.Text!="")//接受群消息
                    {
                        foreach (var m in receive)
                        {
                            if (!readed.Contains(m))//如果没有则输出并添加
                            {
                                readed.Add(m);
                                var op = new UserOperation(db);
                                foreach (var i in receive)
                                {
                                    if (i.Uid != us.Useraccount && i.type == 0 && i.Id == label1.Text)
                                    {
                                        var im = op.getIm(i.Uid);
                                        if (im != null)
                                        {
                                            FlowLayoutPanel panel = new FlowLayoutPanel();
                                            panel.Size = new Size(550, 45);
                                            panel.FlowDirection = FlowDirection.LeftToRight;
                                            panel.WrapContents = false;

                                            PictureBox picture = new PictureBox();
                                            picture.Size = new Size(40, 40);
                                            picture.BackgroundImageLayout = ImageLayout.Stretch;
                                            Image image = resizeImage(Image.FromFile(m.Avatar), new Size(40, 40));
                                            picture.Image = image;
                                            //panel.Controls.Add(picture);

                                            Label time = new Label();
                                            time.Text = m.dateTime.ToLongTimeString();

                                            if (i.category == "1")//是文字
                                            {
                                                FlowLayoutPanel panel1 = new FlowLayoutPanel();
                                                panel1.FlowDirection = FlowDirection.LeftToRight;
                                                panel1.Size = new Size(550, 45);
                                                Label text = new Label();
                                                text.Dock = DockStyle.Left;
                                                text.AutoSize = true;
                                                text.Font = new Font("宋体", 12);
                                                Graphics graphics = label1.CreateGraphics();
                                                SizeF size = graphics.MeasureString(text.Text, text.Font);
                                                text.Size = Size.Round(size);
                                                text.BorderStyle = BorderStyle.FixedSingle;
                                                text.BackColor = Color.LawnGreen;
                                                text.Text = i.Content;
                                                if (this.IsHandleCreated)
                                                {
                                                    this.Invoke(new Action(() =>
                                                    {
                                                        panel.Controls.Add(picture);
                                                        panel.Controls.Add(time);
                                                        Panel1.Controls.Add(panel);
                                                        panel1.Controls.Add(text);
                                                        Panel1.Controls.Add(panel1);
                                                    }));
                                                }
                                            }
                                            else//不是文字
                                            {
                                                string fpath = reviveFile(i);
                                                FlowLayoutPanel panel1 = new FlowLayoutPanel();
                                                panel1.FlowDirection = FlowDirection.LeftToRight;
                                                PictureBox picture1 = new PictureBox();
                                                if (IsRealImage(fpath))         //是图片
                                                {
                                                    panel1.Size = new Size(550, 80);
                                                    picture1.Size = new Size(80, 80);
                                                    picture1.BackgroundImageLayout = ImageLayout.Stretch;
                                                    Image image1 = resizeImage(Image.FromFile(fpath), new Size(80, 80));
                                                    picture1.Image = image1;
                                                    void PictureBox_Click(object sender, EventArgs e)
                                                    {
                                                        ProcessStartInfo processStartInfo = new ProcessStartInfo(fpath);
                                                        Process process = new Process();
                                                        process.StartInfo = processStartInfo;
                                                        process.StartInfo.UseShellExecute = true;
                                                        process.Start();
                                                    }
                                                    picture1.Click += new System.EventHandler(PictureBox_Click);
                                                }
                                                else //其他
                                                {
                                                    panel1.Size = new Size(550, 80);
                                                    picture1.Size = new Size(80, 80);
                                                    picture1.BackgroundImageLayout = ImageLayout.Stretch;
                                                    Image image1 = resizeImage(Image.FromFile("D:/桌面/chat_os/images/sendfile.png"), new Size(80, 80));
                                                    picture1.Image = image1;
                                                    void PictureBox_Click(object sender, EventArgs e)
                                                    {
                                                        ProcessStartInfo processStartInfo = new ProcessStartInfo(fpath);
                                                        Process process = new Process();
                                                        process.StartInfo = processStartInfo;
                                                        process.StartInfo.UseShellExecute = true;
                                                        process.Start();
                                                    }
                                                    picture1.Click += new System.EventHandler(PictureBox_Click);
                                                }
                                                if (this.IsHandleCreated)
                                                {
                                                    this.Invoke(new Action(() =>
                                                    {
                                                        panel.Controls.Add(picture);
                                                        panel.Controls.Add(time);

                                                        Panel1.Controls.Add(panel);
                                                        panel1.Controls.Add(picture1);
                                                        Panel1.Controls.Add(panel1);
                                                    }));
                                                }
                                            }  
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                Thread.Sleep(100);
            }
        }
        public Image resizeImage(Image imgToResize, Size size)
        {
            int sourceWidth = imgToResize.Width;

            int sourceHeight = imgToResize.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)size.Width / (float)sourceWidth);

            nPercentH = ((float)size.Height / (float)sourceHeight);

            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;

            int destWidth = (int)(sourceWidth * nPercent);

            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((System.Drawing.Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();
            return (Image)b;
        }
        public void LoadM(string user,string name)
        {
            Panel1.Controls.Clear();
            var m = new message(db).LoadM(user,name,type);
            if (m != null)
            {
                m = sort_m(m);//排序
                if (m != null)
                {
                    if (type == 1)  //显示好友消息
                    {
                        Panel1.Controls.Clear();
                        foreach (var i in m)
                        {
                            if (i.Uid == user && i.Id == name)//发送方是自己则窗体为绿色
                            {
                                var op = new UserOperation(db);
                                var im = op.getIm(user);
                                if (im != null)
                                {
                                    FlowLayoutPanel panel = new FlowLayoutPanel();
                                    panel.Size = new Size(550, 45);
                                    panel.FlowDirection = FlowDirection.RightToLeft;
                                    panel.WrapContents = false;
                                    PictureBox picture = new PictureBox();
                                    picture.Size = new Size(40, 40);
                                    picture.BackgroundImageLayout = ImageLayout.Stretch;
                                    Image image = resizeImage(Image.FromFile(im.Avatar), new Size(40, 40));
                                    picture.Image = image;
                                    panel.Controls.Add(picture);
                                    Label time = new Label();
                                    time.Text = i.dateTime.ToLongTimeString();
                                    panel.Controls.Add(time);
                                    Panel1.Controls.Add(panel);

                                    if (i.category == "1")//是文字
                                    {
                                        FlowLayoutPanel panel1 = new FlowLayoutPanel();
                                        panel1.FlowDirection = FlowDirection.RightToLeft;
                                        panel1.Size = new Size(550, 45);
                                        Label text = new Label();
                                        text.Dock = DockStyle.Left;
                                        text.AutoSize = true;
                                        text.Font = new Font("宋体", 12);
                                        Graphics graphics = label1.CreateGraphics();
                                        SizeF size = graphics.MeasureString(text.Text, text.Font);
                                        text.Size = Size.Round(size);
                                        text.BorderStyle = BorderStyle.FixedSingle;
                                        text.BackColor = Color.LawnGreen;
                                        text.Text = i.Content;
                                        panel1.Controls.Add(text);
                                        Panel1.Controls.Add(panel1);
                                    }
                                    else//不是文字
                                    {
                                        string fpath = reviveFile(i);
                                        FlowLayoutPanel panel1 = new FlowLayoutPanel();
                                        panel1.FlowDirection = FlowDirection.RightToLeft;
                                        PictureBox picture1 = new PictureBox();
                                        if (IsRealImage(fpath))         //是图片
                                        {
                                            panel1.Size = new Size(550, 80);
                                            picture1.Size = new Size(80, 80);
                                            picture1.BackgroundImageLayout = ImageLayout.Stretch;
                                            Image image1 = resizeImage(Image.FromFile(fpath), new Size(80, 80));
                                            picture1.Image = image1;
                                            void PictureBox_Click(object sender, EventArgs e)
                                            {
                                                ProcessStartInfo processStartInfo = new ProcessStartInfo(fpath);
                                                Process process = new Process();
                                                process.StartInfo = processStartInfo;
                                                process.StartInfo.UseShellExecute = true;
                                                process.Start();
                                            }
                                            picture1.Click += new System.EventHandler(PictureBox_Click);
                                        }
                                        else //其他
                                        {
                                            panel1.Size = new Size(550, 80);
                                            picture1.Size = new Size(80, 80);
                                            picture1.BackgroundImageLayout = ImageLayout.Stretch;
                                            Image image1 = resizeImage(Image.FromFile("D:/桌面/chat_os/images/sendfile.png"), new Size(80, 80));
                                            picture1.Image = image1;
                                            void PictureBox_Click(object sender, EventArgs e)
                                            {
                                                ProcessStartInfo processStartInfo = new ProcessStartInfo(fpath);
                                                Process process = new Process();
                                                process.StartInfo = processStartInfo;
                                                process.StartInfo.UseShellExecute = true;
                                                process.Start();
                                            }
                                            picture1.Click += new System.EventHandler(PictureBox_Click);
                                        }
                                        panel1.Controls.Add(picture1);
                                        Panel1.Controls.Add(panel1);
                                    }
                                }
                            }
                            if (i.Uid == name && i.Id == user) //发送方是好友则窗体为白色
                            {
                                var op = new UserOperation(db);
                                var im = op.getIm(name);
                                if (im != null)
                                {
                                    FlowLayoutPanel panel = new FlowLayoutPanel();
                                    panel.Size = new Size(550, 45);
                                    panel.FlowDirection = FlowDirection.LeftToRight;
                                    panel.WrapContents = false;
                                    PictureBox picture = new PictureBox();
                                    picture.Size = new Size(40, 40);
                                    picture.BackgroundImageLayout = ImageLayout.Stretch;
                                    Image image = resizeImage(Image.FromFile(im.Avatar), new Size(40, 40));
                                    picture.Image = image;
                                    panel.Controls.Add(picture);
                                    Label time = new Label();
                                    time.Text = i.dateTime.ToLongTimeString();
                                    panel.Controls.Add(time);
                                    Panel1.Controls.Add(panel);

                                    if (i.category == "1")//是文字
                                    {
                                        FlowLayoutPanel panel1 = new FlowLayoutPanel();
                                        panel1.FlowDirection = FlowDirection.LeftToRight;
                                        panel1.Size = new Size(550, 45);
                                        Label text = new Label();
                                        text.Dock = DockStyle.Left;
                                        text.AutoSize = true;
                                        text.Font = new Font("宋体", 12);
                                        Graphics graphics = label1.CreateGraphics();
                                        SizeF size = graphics.MeasureString(text.Text, text.Font);
                                        text.Size = Size.Round(size);
                                        text.BorderStyle = BorderStyle.FixedSingle;
                                        text.BackColor = Color.White;
                                        text.Text = i.Content;
                                        panel1.Controls.Add(text);
                                        Panel1.Controls.Add(panel1);
                                    }
                                    else//不是文字
                                    {
                                        string fpath = reviveFile(i);
                                        FlowLayoutPanel panel1 = new FlowLayoutPanel();
                                        panel1.FlowDirection = FlowDirection.LeftToRight;
                                        PictureBox picture1 = new PictureBox();
                                        if (IsRealImage(fpath))         //是图片
                                        {
                                            panel1.Size = new Size(550, 80);
                                            picture1.Size = new Size(80, 80);
                                            picture1.BackgroundImageLayout = ImageLayout.Stretch;
                                            Image image1 = resizeImage(Image.FromFile(fpath), new Size(80, 80));
                                            picture1.Image = image1;
                                            void PictureBox_Click(object sender, EventArgs e)
                                            {
                                                ProcessStartInfo processStartInfo = new ProcessStartInfo(fpath);
                                                Process process = new Process();
                                                process.StartInfo = processStartInfo;
                                                process.StartInfo.UseShellExecute = true;
                                                process.Start();
                                            }
                                            picture1.Click += new System.EventHandler(PictureBox_Click);
                                        }
                                        else //其他
                                        {
                                            panel1.Size = new Size(550, 80);
                                            picture1.Size = new Size(80, 80);
                                            picture1.BackgroundImageLayout = ImageLayout.Stretch;
                                            Image image1 = resizeImage(Image.FromFile("D:/桌面/chat_os/images/sendfile.png"), new Size(80, 80));
                                            picture1.Image = image1;
                                            void PictureBox_Click(object sender, EventArgs e)
                                            {
                                                ProcessStartInfo processStartInfo = new ProcessStartInfo(fpath);
                                                Process process = new Process();
                                                process.StartInfo = processStartInfo;
                                                process.StartInfo.UseShellExecute = true;
                                                process.Start();
                                            }
                                            picture1.Click += new System.EventHandler(PictureBox_Click);
                                        }
                                        panel1.Controls.Add(picture1);
                                        Panel1.Controls.Add(panel1);
                                    }
                                }
                            }
                        }
                    }
                    else if (type == 0)  //显示群消息
                    {
                        Panel1.Controls.Clear();
                        foreach (var i in m)
                        {
                            if (i.Uid == user && name == i.Id)//发送方是自己则窗体为绿色
                            {
                                var op = new UserOperation(db);
                                var im = op.getIm(user);
                                if (im != null)
                                {
                                    FlowLayoutPanel panel = new FlowLayoutPanel();
                                    panel.Size = new Size(550, 45);
                                    panel.FlowDirection = FlowDirection.RightToLeft;
                                    panel.WrapContents = false;
                                    PictureBox picture = new PictureBox();
                                    picture.Size = new Size(40, 40);
                                    picture.BackgroundImageLayout = ImageLayout.Stretch;
                                    Image image = resizeImage(Image.FromFile(im.Avatar), new Size(40, 40));
                                    picture.Image = image;
                                    panel.Controls.Add(picture);
                                    Label time = new Label();
                                    time.Text = i.dateTime.ToLongTimeString();
                                    panel.Controls.Add(time);
                                    Panel1.Controls.Add(panel);
                                    if (i.category == "1")//是文字
                                    {
                                        FlowLayoutPanel panel1 = new FlowLayoutPanel();
                                        panel1.FlowDirection = FlowDirection.RightToLeft;
                                        panel1.Size = new Size(550, 45);
                                        Label text = new Label();
                                        text.Dock = DockStyle.Left;
                                        text.AutoSize = true;
                                        text.Font = new Font("宋体", 12);
                                        Graphics graphics = label1.CreateGraphics();
                                        SizeF size = graphics.MeasureString(text.Text, text.Font);
                                        text.Size = Size.Round(size);
                                        text.BorderStyle = BorderStyle.FixedSingle;
                                        text.BackColor = Color.LawnGreen;
                                        text.Text = i.Content;
                                        panel1.Controls.Add(text);
                                        Panel1.Controls.Add(panel1);
                                    }
                                    else//不是文字
                                    {
                                        string fpath = reviveFile(i);
                                        FlowLayoutPanel panel1 = new FlowLayoutPanel();
                                        panel1.FlowDirection = FlowDirection.RightToLeft;
                                        PictureBox picture1 = new PictureBox();
                                        if (IsRealImage(fpath))         //是图片
                                        {
                                            panel1.Size = new Size(550, 80);
                                            picture1.Size = new Size(80, 80);
                                            picture1.BackgroundImageLayout = ImageLayout.Stretch;
                                            Image image1 = resizeImage(Image.FromFile(fpath), new Size(80, 80));
                                            picture1.Image = image1;
                                            void PictureBox_Click(object sender, EventArgs e)
                                            {
                                                ProcessStartInfo processStartInfo = new ProcessStartInfo(fpath);
                                                Process process = new Process();
                                                process.StartInfo = processStartInfo;
                                                process.StartInfo.UseShellExecute = true;
                                                process.Start();
                                            }
                                            picture1.Click += new System.EventHandler(PictureBox_Click);
                                        }
                                        else //其他
                                        {
                                            panel1.Size = new Size(550, 80);
                                            picture1.Size = new Size(80, 80);
                                            picture1.BackgroundImageLayout = ImageLayout.Stretch;
                                            Image image1 = resizeImage(Image.FromFile("D:/桌面/chat_os/images/sendfile.png"), new Size(80, 80));
                                            picture1.Image = image1;
                                            void PictureBox_Click(object sender, EventArgs e)
                                            {
                                                ProcessStartInfo processStartInfo = new ProcessStartInfo(fpath);
                                                Process process = new Process();
                                                process.StartInfo = processStartInfo;
                                                process.StartInfo.UseShellExecute = true;
                                                process.Start();
                                            }
                                            picture1.Click += new System.EventHandler(PictureBox_Click);
                                        }
                                        panel1.Controls.Add(picture1);
                                        Panel1.Controls.Add(panel1);
                                    }
                                }
                            }
                            else if (name == i.Id)
                            {
                                var op = new UserOperation(db);
                                var u = op.getIm(i.Uid);//找到其他群成员
                                if (u != null)
                                {
                                    FlowLayoutPanel panel = new FlowLayoutPanel();
                                    panel.Size = new Size(550, 45);
                                    panel.FlowDirection = FlowDirection.LeftToRight;
                                    panel.WrapContents = false;
                                    PictureBox picture = new PictureBox();
                                    picture.Size = new Size(40, 40);
                                    picture.BackgroundImageLayout = ImageLayout.Stretch;
                                    Image image = resizeImage(Image.FromFile(u.Avatar), new Size(40, 40));
                                    picture.Image = image;
                                    panel.Controls.Add(picture);
                                    Label time = new Label();
                                    time.Text = i.dateTime.ToLongTimeString();
                                    panel.Controls.Add(time);
                                    Panel1.Controls.Add(panel);

                                    if (i.category == "1")//是文字
                                    {
                                        FlowLayoutPanel panel1 = new FlowLayoutPanel();
                                        panel1.FlowDirection = FlowDirection.LeftToRight;
                                        panel1.Size = new Size(550, 45);
                                        Label text = new Label();
                                        text.Dock = DockStyle.Left;
                                        text.AutoSize = true;
                                        text.Font = new Font("宋体", 12);
                                        Graphics graphics = label1.CreateGraphics();
                                        SizeF size = graphics.MeasureString(text.Text, text.Font);
                                        text.Size = Size.Round(size);
                                        text.BorderStyle = BorderStyle.FixedSingle;
                                        text.BackColor = Color.LawnGreen;
                                        text.Text = i.Content;
                                        panel1.Controls.Add(text);
                                        Panel1.Controls.Add(panel1);
                                    }
                                    else//不是文字
                                    {
                                        string fpath = reviveFile(i);
                                        FlowLayoutPanel panel1 = new FlowLayoutPanel();
                                        panel1.FlowDirection = FlowDirection.LeftToRight;
                                        PictureBox picture1 = new PictureBox();
                                        if (IsRealImage(fpath))         //是图片
                                        {
                                            panel1.Size = new Size(550, 80);
                                            picture1.Size = new Size(80, 80);
                                            picture1.BackgroundImageLayout = ImageLayout.Stretch;
                                            Image image1 = resizeImage(Image.FromFile(fpath), new Size(80, 80));
                                            picture1.Image = image1;
                                            void PictureBox_Click(object sender, EventArgs e)
                                            {
                                                ProcessStartInfo processStartInfo = new ProcessStartInfo(fpath);
                                                Process process = new Process();
                                                process.StartInfo = processStartInfo;
                                                process.StartInfo.UseShellExecute = true;
                                                process.Start();
                                            }
                                            picture1.Click += new System.EventHandler(PictureBox_Click);
                                        }
                                        else //其他
                                        {
                                            panel1.Size = new Size(550, 80);
                                            picture1.Size = new Size(80, 80);
                                            picture1.BackgroundImageLayout = ImageLayout.Stretch;
                                            Image image1 = resizeImage(Image.FromFile("D:/桌面/chat_os/images/sendfile.png"), new Size(80, 80));
                                            picture1.Image = image1;
                                            void PictureBox_Click(object sender, EventArgs e)
                                            {
                                                ProcessStartInfo processStartInfo = new ProcessStartInfo(fpath);
                                                Process process = new Process();
                                                process.StartInfo = processStartInfo;
                                                process.StartInfo.UseShellExecute = true;
                                                process.Start();
                                            }
                                            picture1.Click += new System.EventHandler(PictureBox_Click);
                                        }
                                        panel1.Controls.Add(picture1);
                                        Panel1.Controls.Add(panel1);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            
        }
        public void Chat_Load(User us) //加载表情包一栏的容器
        {
            Button simle = new Button();
            simle.Size = new Size(30, 30);
            Image i1 = Image.FromFile("D:/桌面/chat_os/images/simle.png");
            Image image1 = this.resizeImage(i1, new Size(30, 30));
            simle.Image = image1;
            simle.FlatStyle = FlatStyle.Flat;
            simle.FlatAppearance.BorderSize = 0;
            f1.Controls.Add(simle);

            Button file = new Button();
            file.Size = new Size(30, 30);
            Image i2 = Image.FromFile("D:/桌面/chat_os/images/file.png");
            Image image2 = this.resizeImage(i2, new Size(30, 30));
            file.Image = image2;
            file.FlatStyle = FlatStyle.Flat;
            file.FlatAppearance.BorderSize = 0;
            file.Click += btn_Click;
            void btn_Click(object sender, EventArgs e)
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Multiselect = true;//该值确定是否可以选择多个文件
                dialog.Title = "请选择文件夹";
                dialog.Filter = "文件(*.jpg;*.jpeg;*.gif;*.png;*.doc;*.pdf;*.docx;*.txt;*.xls)|*.jpg;*.jpeg;*.gif;*.png;*.doc;*.pdf;*.docx;*.txt;*.xls";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    var op = new UserOperation(db);
                    var im = op.getIm(us.Useraccount);
                    if (im != null)
                    {
                        FlowLayoutPanel panel = new FlowLayoutPanel();
                        panel.Size = new Size(550, 45);
                        panel.FlowDirection = FlowDirection.RightToLeft;
                        panel.WrapContents = false;
                        PictureBox picture = new PictureBox();
                        picture.Size = new Size(40, 40);
                        picture.BackgroundImageLayout = ImageLayout.Stretch;
                        Image image = resizeImage(Image.FromFile(im.Avatar), new Size(40, 40));
                        picture.Image = image;
                        panel.Controls.Add(picture);
                        Label time = new Label();
                        time.Text = DateTime.Now.ToLongTimeString();
                        panel.Controls.Add(time);
                        Panel1.Controls.Add(panel);

                        string file = dialog.FileName;//文件绝对路径
                        int dotIndex = file.LastIndexOf(".");
                        if (dotIndex != -1 && dotIndex < file.Length - 1)
                        {
                            string ty = file.Substring(dotIndex + 1); //文件类型
                                                                      //转化文件为数据流
                            trans t = new trans();
                            string insert = t.tran_insert(file);//16十六进制
                                                                //生成消息存入数据库
                            var op0 = new UserOperation(db);
                            if (type == 1) //私聊情况
                            {
                                var res = op0.getIm(label1.Text, 1);
                                if (res != null)
                                {
                                    message m = new message(type, DateTime.Now, im.Avatar, us.Useraccount, res.act, insert, false, db, ty);
                                    m.SendMessage(Bubble.L);
                                    readed.Add(m);
                                }
                            }
                            else if (type == 0)
                            {
                                message m = new message(type, DateTime.Now, im.Avatar, us.Useraccount, label1.Text, insert, false, db, ty);
                                m.SendMessage(Bubble.L);
                                readed.Add(m);
                            }
                        }

                        if (IsRealImage(file)) //产生发送图标
                        {
                            FlowLayoutPanel panel1 = new FlowLayoutPanel();
                            panel1.FlowDirection = FlowDirection.RightToLeft;
                            panel1.Size = new Size(550, 80);
                            PictureBox picture1 = new PictureBox();
                            picture1.Size = new Size(80, 80);
                            picture1.BackgroundImageLayout = ImageLayout.Stretch;
                            Image image1 = resizeImage(Image.FromFile(file), new Size(80, 80));
                            picture1.Image = image1;
                            void PictureBox_Click(object sender, EventArgs e)
                            {
                                ProcessStartInfo processStartInfo = new ProcessStartInfo(file);
                                Process process = new Process();
                                process.StartInfo = processStartInfo;
                                process.StartInfo.UseShellExecute = true;
                                process.Start();
                            }
                            picture1.Click += new System.EventHandler(PictureBox_Click);
                            panel1.Controls.Add(picture1);

                            Panel1.Controls.Add(panel1);
                        }
                        else
                        {
                            FlowLayoutPanel panel1 = new FlowLayoutPanel();
                            panel1.FlowDirection = FlowDirection.RightToLeft;
                            panel1.Size = new Size(550, 80);
                            PictureBox picture1 = new PictureBox();
                            picture1.Size = new Size(80, 80);
                            picture1.BackgroundImageLayout = ImageLayout.Stretch;
                            Image image1 = resizeImage(Image.FromFile("D:/桌面/chat_os/images/sendfile.png"), new Size(80, 80));
                            picture1.Image = image1;
                            panel1.Controls.Add(picture1);
                            void PictureBox_Click(object sender, EventArgs e)
                            {
                                ProcessStartInfo processStartInfo = new ProcessStartInfo(file);
                                Process process = new Process();
                                process.StartInfo = processStartInfo;
                                process.StartInfo.UseShellExecute = true;
                                process.Start();
                            }
                            picture1.Click += new System.EventHandler(PictureBox_Click);
                            Panel1.Controls.Add(panel1);
                        }
                    }
                }
            }
            f1.Controls.Add(file);
            
            Button voice = new Button();
            voice.Size = new Size(30, 30);
            Image i3 = Image.FromFile("D:/桌面/chat_os/images/microphone.png");
            Image image3 = this.resizeImage(i3, new Size(30, 30));
            voice.Image = image3;
            voice.FlatStyle = FlatStyle.Flat;
            voice.FlatAppearance.BorderSize = 0;
            f1.Controls.Add(voice);
        }
        private void Panel1_ControlAdded(object sender, ControlEventArgs e)
        {
            Panel1.VerticalScroll.Value = Panel1.VerticalScroll.Maximum;
        }
        private string reviveFile(message m)
        {
            trans t = new trans();
            string rFilePath = t.restore(m.Content, m.category);
            return rFilePath;
        }
        public static bool IsRealImage(string path)
        {
            try
            {
                Image img = Image.FromFile(path);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        private List<message> sort_m (List<message> m)
        {
            for(int i = 0; i < m.Count-1; i++)
            {
                for(int j = 0; j < m.Count-i-1;j++)
                { 
                    if (DateTime.Compare(m[j].dateTime, m[j+1].dateTime) > 0) //i晚于j
                    {
                        message m1 = m[j+1];
                        m[j + 1] = m[j];
                        m[j] = m1;

                    }
                }
            }
            return m;
        }//按时间排序
    }
}
