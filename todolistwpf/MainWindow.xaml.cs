using System.Collections.ObjectModel;
using System.Windows;

namespace todolistwpf
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<ToDoItem> ToDoItems { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            ToDoItems = new ObservableCollection<ToDoItem>();
            ToDoListView.ItemsSource = ToDoItems;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            string title = TitleTextBox.Text;
            string description = DescriptionTextBox.Text;

            if (!string.IsNullOrEmpty(title))
            {
                ToDoItems.Add(new ToDoItem { Title = title, Description = description });
                TitleTextBox.Clear();
                DescriptionTextBox.Clear();
            }
        }

        private void NewBtn_Click(object sender, RoutedEventArgs e)
        {
            TitleTextBox.Clear();
            DescriptionTextBox.Clear();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ToDoListView.SelectedItem != null)
            {
                ToDoItem selectedToDo = (ToDoItem)ToDoListView.SelectedItem;
                TitleTextBox.Text = selectedToDo.Title;
                DescriptionTextBox.Text = selectedToDo.Description;
                ToDoItems.Remove(selectedToDo);
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ToDoListView.SelectedItem != null)
            {
                ToDoItem selectedToDo = (ToDoItem)ToDoListView.SelectedItem;
                ToDoItems.Remove(selectedToDo);
            }
        }
    }

    public class ToDoItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
