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
    public partial class addfriend : Form
    {
        public IDatabase db;
        public User friend;
        public User user;
        public addfriend(IDatabase db, User friend, User user)
        {
            InitializeComponent();
            this.db = db;
            this.friend = friend;
            this.user = user;

            var op = new UserOperation(db);
            var im = op.getIm(friend.Useraccount);
            actbox.Text = friend.Useraccount;
            if (im != null)
            {
                namebox.Text = im.Name;
                sexbox.Text = im.Sex;
                sigbox.Text = im.Signature;
            }
            else
            {
                namebox.Text = "";
                sexbox.Text = "";
                sigbox.Text = "";
            }
            actbox.Enabled = false;
            namebox.Enabled = false;
            sexbox.Enabled = false;
            sigbox.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var op =  new Roperation(db);
            var relate = new RelateModel(user.Useraccount, friend.Useraccount,db);
            var flag = op.CreateRelate(relate);
            if (flag)
            {
                MessageBox.Show("添加成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
            else
            {
                MessageBox.Show("添加成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
