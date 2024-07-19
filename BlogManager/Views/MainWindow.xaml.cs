using System.Windows;
using BlogManager.Controllers;
using BlogManager.Models;

namespace BlogManager.Views
{
    public partial class MainWindow : Window
    {
        private readonly PostController _controller;

        public MainWindow()
        {
            InitializeComponent();
            _controller = new PostController();
            RefreshPosts();
        }

        private void RefreshPosts()
        {
            PostsListBox.ItemsSource = _controller.GetAllPosts();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var addWindow = new PostEditWindow(_controller, null);
            addWindow.ShowDialog();
            RefreshPosts();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (PostsListBox.SelectedItem is Post selectedPost)
            {
                var editWindow = new PostEditWindow(_controller, selectedPost);
                editWindow.ShowDialog();
                RefreshPosts();
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (PostsListBox.SelectedItem is Post selectedPost)
            {
                _controller.DeletePost(selectedPost.Id);
                RefreshPosts();
            }
        }
    }
}