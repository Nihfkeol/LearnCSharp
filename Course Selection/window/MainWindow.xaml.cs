using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Windows;
using Course_Selection.sqlUtils;

/**
 * 简单的选课系统
 */
namespace Course_Selection.window
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            using (var dbcontext = new CourseSql())
            {
                var objectContext = ((IObjectContextAdapter)dbcontext).ObjectContext;
                var mappingCollection = (StorageMappingItemCollection)objectContext.MetadataWorkspace.GetItemCollection(DataSpace.CSSpace);
                mappingCollection.GenerateViews(new List<EdmSchemaError>());
            }
            InitializeComponent();
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            string username = textBoxUsername.Text;
            string password = passwordBoxPassword.Password;
            using (var userSql = new CourseSql())
            {
                SLogin user = userSql.SLogin.Find(username);
                if(user != null)
                {
                    if (password == user.spaw)
                    {
                        SecondWindow s = new SecondWindow();
                        s.setValue(username);
                        s.WindowStartupLocation = WindowStartupLocation.Manual;
                        s.Left = Left + 20;
                        s.Top = Top + 20;
                        s.Show();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("帐号密码错误，请重试");
                    }
                }
                else
                {
                    MessageBox.Show("没有该账号", "ERROR");

                }
            }
        }

        /**
         * 展示注册页面
         */
        private void textBlock_Btn_Up(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            RegisterWindow rWindow = new RegisterWindow();
            rWindow.WindowStartupLocation = WindowStartupLocation.Manual;
            rWindow.Left = Left + 20;
            rWindow.Top = Top + 20;
            rWindow.ShowDialog();
        }
    }



}
