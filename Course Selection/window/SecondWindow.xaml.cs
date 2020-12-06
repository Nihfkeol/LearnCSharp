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
namespace Course_Selection.window
{
    /// <summary>
    /// SecondWindow.xaml 的交互逻辑
    /// </summary>
    public partial class SecondWindow : Window, Transfer
    {
        private string studentId;
        public SecondWindow()
        {
            InitializeComponent();
        }

        public void setValue(object value)
        {
            studentId = (string)value;
            using (var userSql = new CourseSql())
            {
                S s = userSql.S.Find(studentId);
                textBlockStudentId.Text = s.sno;
                textBlockStudentName.Text = s.sname;
                textBlockStudentSex.Text = s.ssex;
                string scodeno = s.scodeno;
                SS sS = userSql.SS.Find(scodeno);
                textBlockStudentScodeno.Text = sS.ssname;
            }
        }

        /**
         * 展示查看已选课程窗口
         */
        private void Button_Click_SeeCourse(object sender, RoutedEventArgs e)
        {
            SeeCourse seeCourse = new SeeCourse();
            seeCourse.setValue(studentId);
            seeCourse.WindowStartupLocation = WindowStartupLocation.Manual;
            seeCourse.Left = Left + 20;
            seeCourse.Top = Top + 20;
            seeCourse.ShowDialog();
        }

        /**
         * 展示选择课程窗口
         */
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ChooseCourse chooseCourse = new ChooseCourse();
            chooseCourse.setValue(studentId);
            chooseCourse.WindowStartupLocation = WindowStartupLocation.Manual;
            chooseCourse.Left = Left + 20;
            chooseCourse.Top = Top + 20;
            chooseCourse.ShowDialog();
        }

        /**
         * 退出帐号
         */
        private void textBlock_Btn_Up(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void textBlock_Btn_MouseEnter(object sender, MouseEventArgs e)
        {
            textBlockQuit.Foreground = (Brush)new BrushConverter().ConvertFrom("#FF997757");
            textBlockQuit.Background = (Brush)new BrushConverter().ConvertFrom("#FFFEBA7B");
        }

        private void textBlock_Btn_MouseLeave(object sender, MouseEventArgs e)
        {
            textBlockQuit.Foreground = (Brush)new BrushConverter().ConvertFrom("#FF000000");
            textBlockQuit.Background = (Brush)new BrushConverter().ConvertFrom("#00FEBA7B");
        }
    }
}
