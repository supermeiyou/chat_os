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
    public partial class create_chat : Form
    {
        public User us;
        public IDatabase db;
        public List<UserModel> userL = new List<UserModel>();
        public event EventHandler CloseForm2;
        public create_chat(User user)
        {
            InitializeComponent();
            us = user;
            db = user.db;
            checkedListBox1.Font = new Font("Microsoft Sans Serif", 14);
            checkedListBox1.ItemHeight = 40;
            var op = new Roperation(db);
            var relate = op.GetRelate(us.Useraccount);
            var op1 = new UserOperation(db);
            foreach (var item in relate) //显示名字并存入list
            {
                if (item.useract == us.Useraccount)
                {
                    var im = op1.getIm(item.friendact);
                    if (im != null)
                        checkedListBox1.Items.Add(im.Name, false);
                    var m = op1.GetUser(item.friendact);
                    if (m != null)
                        userL.Add(m);
                }
                    
                else if (item.friendact == us.Useraccount)
                {
                    var im = op1.getIm(item.useract);
                    if (im != null)
                        checkedListBox1.Items.Add(im.Name, false);
                    var m = op1.GetUser(item.useract);
                    if (m != null)
                        userL.Add(m);
                }     
            }
        }
        private void button1_Click(object sender, EventArgs e) //寻找到checkedlistbox元素对应名字的账号并创建数据库关系
        {
            List<string> list = new List<string>();
            var o = new UserOperation(db);
            list.Add(us.Useraccount);
            for(int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                bool isChecked = checkedListBox1.GetItemChecked(i);
                if (isChecked)
                {
                    foreach(var s in userL)
                    {
                        if (o.getIm(s.useraccount).Name == checkedListBox1.Items[i].ToString()) 
                            list.Add(s.useraccount);
                    }
                }
            }
                chatoperation ch = new chatoperation(db);
            var flag = ch.create(textBox1.Text.Trim(), list);
            if (flag)
            {
                
                var result = MessageBox.Show("创建成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (result == DialogResult.OK)
                {
                    CloseForm2?.Invoke(this, EventArgs.Empty);
                    this.Close();
                }
            } 
        }
    }
}
