using System;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using TodoListLib;

namespace TodoListDesktop
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public TodoList MainList { get; set; }

        public Editor.TodoEditorClient Client { get; set; }

        private string TableName { get; set; }

        public MainWindow(Editor.TodoEditorClient client, string tableName)
        {
            InitializeComponent();
            Client = client;
            Client.InnerChannel.Closed += InnerChannel_Closed;
            Client.InnerChannel.Faulted += InnerChannel_Closed;
            Client.InnerChannel.Closing += InnerChannel_Closed;
            TableName = tableName;
            UpdateList();
        }

        private void InnerChannel_Closed(object sender, EventArgs e)
        {
            MessageBox.Show("Server disconnected");
            App.Current.Shutdown();
        }

        private void UploadListButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "CSV (разделитель - запятая) (*.csv)|*.csv";
            fileDialog.InitialDirectory = @"C:\Users\artam\Desktop\lists\";
            if (fileDialog.ShowDialog() == true)
            {
                try
                {
                    Client.Load(fileDialog.FileName);
                    Client.SaveMain(TableName);
                }
                catch
                {
                    MessageBox.Show("Can't recieve data. Aborting process");
                    App.Current.Shutdown();
                }
                UpdateList();
            }
        }

        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            TaskWindow taskWindow = new TaskWindow(Client);
            taskWindow.Show();
            taskWindow.Closed += TaskWindow_Closed;
        }

        private void TaskWindow_Closed(object sender, EventArgs e)
        {
            try
            {
                Client.SaveMain(TableName);
            }
            catch
            {
                MessageBox.Show("Can't recieve data. Aborting process");
                App.Current.Shutdown();
            }
            UpdateList();
        }

        private void UpdateList()
        {
            try { TaskHolder.ItemsSource = null; } catch { /*do nothing*/ };
            try { MainList = JsonConverter.GetObject<TodoList>(Client.GetList()); } catch { MessageBox.Show("Can't recieve data. Aborting process"); App.Current.Shutdown(); }
            TaskHolder.ItemsSource = MainList.Tasks;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Task _toDelete = new Task(((Task)((MenuItem)sender).DataContext).Title, ((Task)((MenuItem)sender).DataContext).Description, ((Task)((MenuItem)sender).DataContext).Deadline, ((Task)((MenuItem)sender).DataContext).Tags);
            MainList.Tasks.Remove(_toDelete);
            try
            {
                Client.DeleteTasks(JsonConverter.ToJson(MainList));
                Client.SaveMain(TableName);
            }
            catch
            {
                MessageBox.Show("Can't recieve data. Aborting process");
                App.Current.Shutdown();
            }
            UpdateList();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Task _toEdit = new Task(((Task)((MenuItem)sender).DataContext).Title, ((Task)((MenuItem)sender).DataContext).Description, ((Task)((MenuItem)sender).DataContext).Deadline, ((Task)((MenuItem)sender).DataContext).Tags);
            TaskWindow taskWindow = new TaskWindow(Client, _toEdit);
            taskWindow.Show();
            MainList.Tasks.Remove(_toEdit);
            try
            {
                Client.DeleteTasks(JsonConverter.ToJson(MainList));
            }
            catch
            {
                MessageBox.Show("Can't recieve data. Aborting process");
                App.Current.Shutdown();
            }
            taskWindow.Closed += TaskWindow_Closed;
        }

        private void DownloadListButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "CSV (разделитель - запятая) (*.csv)|*.csv";
            fileDialog.InitialDirectory = @"C:\Users\artam\Desktop\lists\";
            if (fileDialog.ShowDialog() == true)
            {
                try { Client.Save(fileDialog.FileName); } catch { MessageBox.Show("Can't recieve data. Aborting process"); App.Current.Shutdown(); }
            }
        }


    }
}
