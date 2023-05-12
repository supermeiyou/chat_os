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
    public partial class addchat : Form
    {
        public IDatabase db;
        private User us;
        List<string> users;
        public addchat(string name , IDatabase db,User us)
        {
            InitializeComponent();
            label2.Text = name;
            this.db = db;
            this.us = us;
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
            users = list.Distinct().ToList(); //群成员名字
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            foreach (var item in users)
            {
                Label l = new Label();
                l.Text = item;
                l.Size = new Size(200, 50);
                l.Font = new Font("宋体", 12);
                flowLayoutPanel1.Controls.Add(l);
            }
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            var chop = new chatoperation(db);
            
            if (users.Contains(us.Useraccount))
            {
                var re = MessageBox.Show("已在群聊", "成功", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                bool f = chop.create(label2.Text, users,us.Useraccount);
                if (f)
                {
                    var re = MessageBox.Show("创建成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
    }
}
