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
    public partial class FormBuyStock : Form
    {
        public FormBuyStock()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListViewItem li = new ListViewItem();
            li.SubItems.Clear();
            li.SubItems[0].Text = txtID.Text;
            li.SubItems.Add(txtName.Text);
            li.SubItems.Add(cBox.Text);
            li.SubItems.Add(txtType.Text);
            li.SubItems.Add(txtISBN.Text);
            li.SubItems.Add(txtAddress.Text);
            li.SubItems.Add(txtNum.Text);
            li.SubItems.Add(txtPrice.Text);
            listView1.Items.Add(li);
        }
    }
}
