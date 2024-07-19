using System.Windows;
using BlogManager.Controllers;
using BlogManager.Models;

namespace BlogManager.Views
{
    public partial class PostEditWindow : Window
    {
        private readonly PostController _controller;
        private readonly Post _post;

        public PostEditWindow(PostController controller, Post post)
        {
            InitializeComponent();
            _controller = controller;
            _post = post;

            if (_post != null)
            {
                TitleTextBox.Text = _post.Title;
                ContentTextBox.Text = _post.Content;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (_post == null)
            {
                _controller.AddPost(TitleTextBox.Text, ContentTextBox.Text);
            }
            else
            {
                _controller.UpdatePost(_post.Id, TitleTextBox.Text, ContentTextBox.Text);
            }
            Close();
        }
    }
}