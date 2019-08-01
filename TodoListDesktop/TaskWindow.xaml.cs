using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using TodoListLib;

namespace TodoListDesktop
{
    /// <summary>
    /// Логика взаимодействия для Task.xaml
    /// </summary>
    public partial class TaskWindow : Window
    {
        public Editor.TodoEditorClient Client { get; set; }

        public TaskWindow(Editor.TodoEditorClient client)
        {
            InitializeComponent();
            Client = client;
            Client.InnerChannel.Closed += InnerChannel_Closed;
            Client.InnerChannel.Faulted += InnerChannel_Closed;
        }

        private void InnerChannel_Closed(object sender, EventArgs e)
        {
            MessageBox.Show("Server disconnected");
            App.Current.Shutdown();
        }

        public TaskWindow(Editor.TodoEditorClient client, Task task)
        {
            InitializeComponent();
            Client = client;
            titleBox.Text = task.Title;
            descriptionBox.Text = task.Description;
            deadlinePicker.Text = task.Deadline.ToString();
            StringBuilder builder = new StringBuilder();
            foreach (string tag in task.Tags)
            {
                builder.Append($"{tag} ");
            }
            builder.Remove(builder.Length - 1, 1);
            tagsBox.Text = builder.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<string> tags = new List<string>();
            string[] inputString = tagsBox.Text.Split(new char[] { ' ' });
            foreach (string tag in inputString)
            {
                tags.Add(tag);
            }
            if (titleBox.Text == "" || deadlinePicker.Text == "" || DateTime.Parse(deadlinePicker.Text) < DateTime.Now)
            {
                MessageBox.Show("Please, fill the fields correctly");
                return;
            }
            Task task = new Task(titleBox.Text, descriptionBox.Text, DateTime.Parse(deadlinePicker.Text).AddDays(1), tags);
            try { Client.AddTask(JsonConverter.ToJson(task)); } catch { MessageBox.Show("Can't recieve data. Aborting process"); App.Current.Shutdown(); }
            Close();
        }
    }
}
