using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Course_Selection.sqlUtils;

namespace Course_Selection.window
{
    /// <summary>
    /// RegisterWindow.xaml 的交互逻辑
    /// </summary>
    public partial class RegisterWindow : Window
    {

        private string sex = null;
        public RegisterWindow()
        {
            InitializeComponent();
            radioButton1.Checked += new RoutedEventHandler(radio_Checked);
            radioButton2.Checked += new RoutedEventHandler(radio_Checked);
            SetComboBoxValue();
        }

        /**
         * 设置ComboBox中的数据（显示专业）
         */
        private void SetComboBoxValue()
        {
            using (var usersql = new CourseSql())
            {

                List<SS> ssList = usersql.SS.SqlQuery("select * from SS").ToList();
                foreach (SS s in ssList)
                {
                    Console.WriteLine(s.ssname);
                }
                comboBoxSS.ItemsSource = ssList;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            S s = new S();
            SLogin sLogin = new SLogin();
            //学号
            string studentId = textBoxStudentId.Text;
            //姓名
            string name = textBoxName.Text;
            //专业代码
            string scodeno = null;
            //设置班级
            s._class = textBoxClass.Text;
            //密码
            string paw = paw1.Password;
            //重复密码
            string repaw = paw2.Password;

            if ("".Equals(studentId))
            {
                MessageBox.Show("学号不能为空");
            }
            else
            {
                s.sno = studentId;
                sLogin.sno = studentId;
                //判断姓名是否为空
                if ("".Equals(name))
                {
                    MessageBox.Show("姓名不能为空");
                }
                else
                {
                    s.sname = name;
                    //判断是否选择性别
                    if (sex == null)
                    {
                        MessageBox.Show("请选择性别");
                    }
                    else
                    {
                        s.ssex = sex;
                        //判断是否选择专业
                        if (comboBoxSS.SelectedIndex != -1)
                        {
                            scodeno = comboBoxSS.SelectedValue.ToString();
                        }
                        if (scodeno == null)
                        {
                            MessageBox.Show("请选择专业");
                        }
                        else
                        {
                            s.scodeno = scodeno;
                            //判断是否输入密码
                            if ("".Equals(paw))
                            {
                                MessageBox.Show("请输入密码");
                            }
                            else
                            {
                                //判断是否输入密码
                                if ("".Equals(repaw))
                                {
                                    MessageBox.Show("请确认密码");
                                }
                                else
                                {
                                    //判断两次密码输入是否一致
                                    if (!repaw.Equals(paw))
                                    {
                                        MessageBox.Show("两次输入密码不一致");
                                    }
                                    else
                                    {
                                        sLogin.spaw = repaw;
                                        using (var usersql = new CourseSql())
                                        {
                                            try
                                            {
                                                usersql.S.Attach(s);
                                                usersql.S.Add(s);
                                                usersql.SaveChanges();

                                                usersql.SLogin.Attach(sLogin);
                                                usersql.SLogin.Add(sLogin);
                                                usersql.SaveChanges();
                                                MessageBoxResult result = MessageBox.Show(
                                                    "是否返回登陆界面",
                                                    "注册成功",
                                                    MessageBoxButton.YesNo);
                                                switch (result)
                                                {
                                                    case MessageBoxResult.Yes:
                                                        Close();
                                                        break;
                                                }
                                            }
                                            catch
                                            {
                                                MessageBox.Show("学号已存在");
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }







        }

        /**
         * radioButton选中性别
         */
        private void radio_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton btn = sender as RadioButton;
            sex = btn.Tag.ToString();
        }
    }
}
