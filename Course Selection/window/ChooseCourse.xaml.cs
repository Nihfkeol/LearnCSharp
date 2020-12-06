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
using Course_Selection.utils;
using Course_Selection.pojo;


namespace Course_Selection.window
{

    /// <summary>
    /// ChooseCourse.xaml 的交互逻辑
    /// </summary>
    public partial class ChooseCourse : Window, Transfer
    {
        private string studentId;
        List<string> conList;
        List<C> listC2;

        public ChooseCourse()
        {
            InitializeComponent();
            conList = new List<string>();
            listC2 = new List<C>();
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
         * 展示数据（学生已选的课程）
         */
        private void ShowData()
        {

            using (var userSql = new CourseSql())
            {
                string sql = "select * from C where cno in (select cno from CS where scodeno = (select scodeno from S where sno = {0}))";
                //专业能学的所有课程
                List<C> listC = userSql.C.SqlQuery(sql, studentId).ToList();

                List<C_Copies> cCopyList = new List<C_Copies>();

                foreach (C c in listC)
                {
                    C_Copies copy = new C_Copies();
                    copy.CheckStatus = false;
                    copy.cno = c.cno;
                    copy.cname = c.cname;
                    copy.classh = c.classh;
                    cCopyList.Add(copy);
                }

                string sql2 = "select * from C where cno in (select cno from SC where sno = {0})";
                //学生以学的课程
                listC2 = userSql.C.SqlQuery(sql2, studentId).ToList();
                
                for (int i = 0; i < cCopyList.Count; i++)
                {
                    for (int j = 0; j < listC2.Count; j++)
                    {
                        if (cCopyList[i].cno == listC2[j].cno)
                        {
                            cCopyList[i].CheckStatus = true;
                            conList.Add(cCopyList[i].cno);
                            break;
                        }
                    }
                }

                listBox.ItemsSource = cCopyList;
            }
        }

        /**
         * 勾选框
         */
        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            string cno = Convert.ToString(cb.Tag.ToString());
            if (cb.IsChecked == true)
            {
                conList.Add(cno);
            }
            else
            {
                conList.Remove(cno);

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var userSql = new CourseSql())
            {
                //获取没有选择的课程列表
                List<string> noLearn = new List<string>();
                foreach (C c in listC2)
                {
                    bool flag = false;
                    foreach (string s in conList)
                    {
                        if (s == c.cno)
                        {
                            flag = true;
                            break;
                        }
                    }
                    if (!flag)
                    {
                        noLearn.Add(c.cno);
                    }
                }
                //删除没有选择的课程
                foreach (string s in noLearn)
                {
                    SC sc = new SC
                    {
                        sno = studentId,
                        cno = s
                    };
                    userSql.SC.Attach(sc);
                    userSql.SC.Remove(sc);
                    userSql.SaveChanges();
                }

                //新选择的课表
                List<string> addLearn = new List<string>();
                foreach (string s in conList)
                {
                    bool flag = false;
                    foreach (C c in listC2)
                    {
                        if (s == c.cno)
                        {
                            flag = true;
                            break;
                        }
                    }
                    if (!flag)
                    {
                        addLearn.Add(s);
                    }
                }
                //添加新选择的课程
                foreach (string s in addLearn)
                {
                    SC sc = new SC
                    {
                        sno = studentId,
                        cno = s
                    };
                    userSql.SC.Attach(sc);
                    userSql.SC.Add(sc);
                    userSql.SaveChanges();
                }
            }

            string msgText = "选择成功";
            string caption = "选课";
            MessageBoxButton btn = MessageBoxButton.OK;
            MessageBoxResult result = MessageBox.Show(msgText, caption, btn);
            switch (result)
            {
                case MessageBoxResult.OK:
                    Close();
                    break;
            }
        }
    }
}
