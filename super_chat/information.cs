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
    public partial class information : Form
    {
        public IDatabase db;
        public User us;
        public UserIm userIm;
        public OpenFileDialog file = new OpenFileDialog();
        public information(IDatabase db, User us)
        {
            InitializeComponent();
            actbox.Enabled = false;
            namebox.Enabled = false;
            dateTimePicker.Enabled = false;
            conbox.Enabled = false;
            sigbox.Enabled = false;
            mailbox.Enabled = false;
            addbtn.Enabled = false;
            this.db = db;
            if (us!=null)
            {
                this.us = us;
                mailbox.Text = us.Mail;
                var op = new UserOperation(db);
                var im = op.getIm(us.Useraccount);
                if (im != null)
                {
                    userIm = new UserIm(im);
                    actbox.Text = us.Useraccount;
                    namebox.Text = im.Name;
                    if (userIm.Sex!="")
                    {
                        if (userIm.Sex.Trim(' ').Equals("女"))
                            woman.Checked = true;
                        else if (userIm.Sex.Trim(' ').Equals("男"))
                            man.Checked = true;
                        man.Enabled = false;
                        woman.Enabled = false;
                    }
                    dateTimePicker.Value = userIm.Birthday;
                    conbox.Text = im.constellation;
                    sigbox.Text = im.Signature;
                    if (userIm.avatar!=null)
                    {
                        file.FileName = userIm.avatar;
                        if (file.FileName != "")
                        {
                            addbtn.Text = "更换图片";
                            this.pictureBox1.BackgroundImage = Image.FromFile(file.FileName);
                        }     
                    }    
                }
            }
        }

        private void actbox_ReadOnlyChanged(object sender, EventArgs e)
        {

        }

        private void editbtn_Click(object sender, EventArgs e)
        {
            namebox.Enabled = true;
            man.Enabled = true;
            woman.Enabled = true;
            dateTimePicker.Enabled = true;
            conbox.Enabled = true;
            sigbox.Enabled = true;
            mailbox.Enabled = true;
            addbtn.Enabled = true;
        }

        private void reservebtn_Click(object sender, EventArgs e)
        {
            namebox.Enabled = false;
            man.Enabled = false;
            woman.Enabled = false;
            dateTimePicker.Enabled = false;
            conbox.Enabled = false;
            sigbox.Enabled = false;
            mailbox.Enabled = false;
            var op = new UserOperation(db);
            bool flag = true;
            if (man.Checked == true)
                flag = true;
            if (woman.Checked == true)
                flag = false;
            var uim = new UserImModel(us.Useraccount, namebox.Text, (flag == true) ? "男" : "女", dateTimePicker.Value, conbox.Text, sigbox.Text,file.FileName,db);
            var r = op.UpdateMail(us.Useraccount,us.Password,mailbox.Text.ToString());
            if (op.UpdateIm(uim) && r)
            {
                MessageBox.Show("更新成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void man_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void woman_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            file.ShowDialog();
            string url = file.FileName;
            if (url != null)
            {
                this.pictureBox1.BackgroundImage = Image.FromFile(url);
            }
            addbtn.Text = "更换图片";
        }
    }
}
