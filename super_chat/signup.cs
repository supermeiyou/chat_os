using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DbMiddleware;
using DbMiddlewarePostgresImpl;

namespace super_chat
{
    public partial class signup : Form
    {
        public IDatabase db ;
        public signup( IDatabase database )
        {
            InitializeComponent();
            this.db = database;
            this.setCode(4);
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void forget_Click(object sender, EventArgs e)
        {
            new forget(db).Show();
        }
        private void login_Click(object sender, EventArgs e)
        {
            new login(db).Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string account = idbox.Text.ToString();
            string pwd = pwdbox.Text.ToString();
            string verify = vfbox.Text;
            if (code.ToUpper().Equals(vfbox.Text.ToUpper()))
            {
                var op = new UserOperation(db);
                var us = op.GetUser(account);
                if (us == null)
                {
                    MessageBox.Show("用户名不存在！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    idbox.Clear();
                    pwdbox.Clear();
                    vfbox.Clear();
                    setCode(4);
                }
                else
                {
                    var user = new User(us);
                    if (user.Flag)
                    {
                        var f = op.GetUser(account, pwd);
                        if (f == null)
                        {
                            if (3 - user.Count > 1)
                            {
                                op.UpdateNo(account);
                                MessageBox.Show("密码错误！\n" + "您还可以在输入" + (3 - user.Count).ToString() + "次。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                idbox.Clear();
                                pwdbox.Clear();
                                setCode(4); vfbox.Clear();
                            }
                            else
                            {
                                if (op.UpdateNo(account) == 3)
                                {
                                    MessageBox.Show("账号已被冻结请三分钟后再试！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    idbox.Clear();
                                    pwdbox.Clear();
                                    setCode(4); vfbox.Clear();
                                }
                            }
                        }
                        else
                        {
                            if (op.UpdateYes(f.useraccount))
                            {
                                new aaa(db,user).Show();
                                idbox.Clear();
                                pwdbox.Clear();
                                setCode(4); vfbox.Clear();
                            }
                        }
                    }
                    else
                    {
                        TimeSpan ts = DateTime.Now - user.LastTime;
                        string s = ts.TotalMinutes.ToString();
                        string[] strArray = s.Split('.');
                        MessageBox.Show(strArray[0], "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        int t = Convert.ToInt32(strArray[0]);
                        if (t <= 3)
                        {
                            MessageBox.Show("账号已被冻结请三分钟后再试！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            idbox.Clear();
                            pwdbox.Clear();
                            setCode(4); vfbox.Clear();
                        }
                        else
                        {
                            new login(db).Show();
                            idbox.Clear();
                            pwdbox.Clear();
                            setCode(4); vfbox.Clear();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("验证码错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                idbox.Clear();
                pwdbox.Clear();
                setCode(4); vfbox.Clear();
            }
        }
        private void signup_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        string code="";
        Random r = new Random();
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            setCode(4);
        }
        private void setCode(int length)
        {
            code = "";
            for (int i = 0; i < length; i++)
            {
                int type = r.Next(0, 2);//存在两次
                if (type == 0)
                {
                    code += r.Next(0, 9);
                }
                else if (type == 1)
                {
                    code += (char)r.Next(97, 123);
                }
            }
            if (string.IsNullOrWhiteSpace(code))
            {
                return;
            }
            Bitmap img = new Bitmap(code.Length * 20 + 10, 30);
            Graphics graphics = Graphics.FromImage(img);
            graphics.Clear(Color.White);
            Pen pen = new Pen(Color.Black, 1);
            graphics.DrawRectangle(pen, 0, 0, img.Width - 1, img.Height - 1);
            for (int i = 0; i < code.Length; i++)
            {
                Pen p = new Pen(Color.FromArgb(r.Next(255), r.Next(255), r.Next(255)), r.Next(1, 2));//画线
                graphics.DrawLine(p, r.Next(0, img.Width), r.Next(0, img.Height), r.Next(img.Width), r.Next(0, img.Height));//线段的两个点
            }
            graphics.DrawString(code, new Font("宋体", 15, FontStyle.Italic | FontStyle.Bold), new SolidBrush(Color.FromArgb(r.Next(255), r.Next(255), r.Next(255))), new Point(5, 5));
            for (int i = 0; i < code.Length * 20; i++)
            {
                graphics.FillEllipse(new SolidBrush(Color.FromArgb(r.Next(255), r.Next(255), r.Next(255))), r.Next(0, img.Width), r.Next(0, img.Height), 2, 2);//绘制小圆点
            }
            pictureBox1.Image = img;
        }
    }
}
