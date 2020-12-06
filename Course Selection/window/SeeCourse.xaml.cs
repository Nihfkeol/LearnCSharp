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
using Course_Selection.utils;
using Course_Selection.sqlUtils;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Collections;

namespace Course_Selection.window
{
    /// <summary>
    /// ChooseCourse.xaml 的交互逻辑
    /// </summary>
    public partial class SeeCourse : Window, Transfer
    {
        //学号
        private string studentId;

        public SeeCourse()
        {
            InitializeComponent();
        }

        /**
         * 从其他窗口传来的数据
         */
        public void setValue(object value)
        {
            studentId = (string)value;
            ShowData();
        }

        /**
         * 展示数据
         */
        private void ShowData()
        {
            ShowName();
            ShowCanChoose();
        }

        /**
         * 展示姓名
         * 获取专业
         */
        private void ShowName()
        {
            using (var userSql = new CourseSql())
            {
                S s = userSql.S.Find(studentId);
                textBlockStudentName.Text = s.sname;
            }
        }

        /**
         * 显示ListBox的数据
         */
        private void ShowCanChoose()
        {
            using (var userSql = new CourseSql())
            {
                string sql = "select * from C where cno in (select cno from SC where sno = {0})";
                List<C> listC = userSql.C.SqlQuery(sql,studentId).ToList();
                listViewInfo.ItemsSource = listC;
            }
        }


        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            string cno = btn.Tag.ToString();
            using (var usersql = new CourseSql())
            {
                SC sc = new SC();
                sc.sno = studentId;
                sc.cno = cno;
                usersql.SC.Attach(sc);
                usersql.SC.Remove(sc);
                usersql.SaveChanges();
                ShowCanChoose();
            }
        }
    }
}
