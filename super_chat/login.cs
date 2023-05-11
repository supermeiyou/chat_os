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
    public partial class login : Form
    {
        public IDatabase db;
        public login(IDatabase database )
        {
            InitializeComponent();
            this.db = database;
        }
        private void confirm_Click(object sender, EventArgs e)
        {
            string act = actbox.Text.ToString();
            string pwd = pwdbox.Text.ToString();
            string rpwd = rpwdbox.Text.ToString();
            string m = mailbox.Text.ToString();

            UserOperation op = new UserOperation(db);
            var us = op.GetUser(act);
            if (us == null)
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
                            pwdbox.Clear();
                            rpwdbox.Clear();
                            mailbox.Clear();
                        }
                        else
                        {
                            var model = new UserModel(db,act,pwd,m,true,0,false,DateTime.Now);
                            var flag = op.CreateUser(model);
                            if (flag)
                            {
                                MessageBox.Show("注册成功，请返回登入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                actbox.Clear();
                                pwdbox.Clear();
                                rpwdbox.Clear();
                                mailbox.Clear();
                            }
                            else
                            {
                                MessageBox.Show("注册失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                actbox.Clear();
                                pwdbox.Clear();
                                rpwdbox.Clear();
                                mailbox.Clear();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("密码长度应在8-16位之间！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        actbox.Clear();
                        pwdbox.Clear();
                        rpwdbox.Clear();
                        mailbox.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("两次密码不一致！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    actbox.Clear();
                    pwdbox.Clear();
                    rpwdbox.Clear();
                    mailbox.Clear();
                }  
            }
            else
            {
                MessageBox.Show("该手机号已被注册！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                actbox.Clear();
                pwdbox.Clear();
                rpwdbox.Clear();
                mailbox.Clear();
            }
        }
    }
}
