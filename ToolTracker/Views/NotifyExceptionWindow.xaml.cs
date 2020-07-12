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

namespace ToolTracker.Views
{
    /// <summary>
    /// Interaction logic for NotifyExceptionWindow.xaml
    /// </summary>
    public partial class NotifyExceptionWindow : Window
    {
        Exception exception = null;
        string message = null;

        public NotifyExceptionWindow(Exception exception, string message)
        {
            InitializeComponent();
            this.exception = exception;
            this.message = message;
        }
        private void NotifyExceptionWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            textBlockErrMsg.Text = this.message;
            textBoxTechDetails.Text = this.exception.Message +
                                      Environment.NewLine + Environment.NewLine +
                                      this.exception.StackTrace;
            SetExpanderCollapsedHeight();
        }

        private void SetExpanderCollapsedHeight()
        {
            this.Height = 200;
        }
       

        private void ExpanderDetails_OnExpanded(object sender, RoutedEventArgs e)
        {
            this.Height = 300;
        }

        private void ExpanderDetails_OnCollapsed(object sender, RoutedEventArgs e)
        {
            SetExpanderCollapsedHeight();
        }

        private void ButtonCopyToClipboard_OnClick(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(textBoxTechDetails.Text);
        }

        private void ButtonClose_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
       
    }
}
