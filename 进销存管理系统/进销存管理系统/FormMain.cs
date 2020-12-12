using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 进销存管理系统
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "登录用户：" + FormLogin.strName;
            toolStripStatusLabel2.Text = "||登录时间：" + DateTime.Now.ToLongTimeString();
        }

        private void 进过货单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBuyStock frbs = new FormBuyStock();
            frbs.MdiParent = this;
            frbs.MaximizeBox = false;
            frbs.Dock = DockStyle.Fill;
            frbs.Show();
        }
    }
}
