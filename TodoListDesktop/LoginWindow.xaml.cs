using System;
using System.Windows;

namespace TodoListDesktop
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Editor.TodoEditorClient client = null;
            if (tableName.Text == "")
            {
                MessageBox.Show("Please, input tablename");
                return;
            }
            try
            {
                client = new Editor.TodoEditorClient("NetTcpBinding_ITodoEditor");
                client.InnerChannel.Closed += InnerChannel_Closed;
                client.InnerChannel.Faulted += InnerChannel_Closed;
                client.InitializeList(tableName.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Can't connect");
                return;
            }
            MainWindow main = new MainWindow(client, tableName.Text);
            main.Show();
            Close();
        }

        private void InnerChannel_Closed(object sender, EventArgs e)
        {
            MessageBox.Show("Server disconnected");
            App.Current.Shutdown();
        }
    }
}
