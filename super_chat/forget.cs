using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using DbMiddleware;
using DbMiddlewarePostgresImpl;
namespace super_chat
{
    public partial class forget : Form
    {
        IDatabase db;
        public forget(IDatabase db)
        {
            InitializeComponent();
            this.db = db;
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            string act = actbox.Text.ToString();
            string m = mailbox.Text.ToString();
            string pwd = newpwd.Text.ToString();
            string rpwd = rnewpwd.Text.ToString();

            UserOperation op = new UserOperation(db);
            var us = op.GetUser(act);
            if (us != null)
            {
                if (pwd.Equals(rpwd))
                {
                    if (pwd.Length >= 8 && pwd.Length <= 16)
                    {
                        Regex rgx = new Regex("^(?=.*[a-zA-Z])(?=.*[0-9])[A-Za-z0-9]{8,16}$");
                        if (!rgx.IsMatch(pwd))
                        {
                            MessageBox.Show("密码格式不符合规范！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            actbox.Clear();
                            newpwd.Clear();
                            rnewpwd.Clear();
                            mailbox.Clear();
                        }
                        else
                        {
                            var flag = op.UpdatePwd(us.useraccount,us.mail,pwd);
                            if (flag)
                            {
                                MessageBox.Show("重置成功，请返回登入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                actbox.Clear();
                                newpwd.Clear();
                                rnewpwd.Clear();
                                mailbox.Clear();
                            }
                            else
                            {
                                MessageBox.Show("重置失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                actbox.Clear();
                                newpwd.Clear();
                                rnewpwd.Clear();
                                mailbox.Clear();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("密码长度应在8-16位之间！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        actbox.Clear();
                        newpwd.Clear();
                        rnewpwd.Clear();
                        mailbox.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("两次密码不一致！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    actbox.Clear();
                    newpwd.Clear();
                    rnewpwd.Clear();
                    mailbox.Clear();
                }
            }
            else
            {
                MessageBox.Show("用户名不存在！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                actbox.Clear();newpwd.Clear();
                rnewpwd.Clear();mailbox.Clear();
            }
        } 
    }
}
