using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/**
 * 进销存管理系统
 */
namespace 进销存管理系统
{
    public partial class FormLogin : Form
    {
        public static string strName;
        public FormLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            if (username == "")
            {
                MessageBox.Show("用户名称不能为空", "错误提示");
                return;
            }
            else if (password == "")
            {
                MessageBox.Show("用户密码不能为空", "错误提示");
                return;
            }
            else
            {
                if(username == "mr" && password == "mrsoft")
                {
                    FormMain frm = new FormMain();
                    strName = username;
                    frm.Show();
                    Visible = false;
                }
                else
                {
                    MessageBox.Show("用户名或密码不正确！", "错误提示");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
