using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ToolTracker.Models;
using ToolTracker.Services;
using ToolTracker.ViewModels;
using System.Threading;

namespace ToolTracker
{
    /// <summary>
    /// Interaction logic for TestLoaderWindow.xaml
    /// </summary>
    public partial class TestLoaderWindow : Window
    {
        private Task _task;
        private Thread _thread;

        private BackgroundWorker worker;

        public TestLoaderWindow()
        {
            InitializeComponent();
        }

        private void TestLoaderWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            ToolTrackerService.Tools = new ObservableCollection<ToolViewModel>();
            ToolTrackerService.Shops = new ObservableCollection<Shop>();

            ToolTrackerService.LoadTools();

          
        }

        private void BtnTest1_OnClick(object sender, RoutedEventArgs e)
        {
            //BusyBar.IsBusy = true;
            //_task = Task.Factory.StartNew(StartLoaderAnimation);


            _thread = new Thread(StartLoaderAnimation);
            _thread.Start();

            listBoxUpdateTools.ItemsSource = ToolTrackerService.Tools;
           
        }

        private void Test()
        {
            MessageBox.Show("Arrgghh");
        }

        private void BtnTest2_OnClick(object sender, RoutedEventArgs e)
        {
            //_task = Task.Factory.StartNew(StartLoaderAnimation);
           
            
        }

        private void BtnTest3_OnClick(object sender, RoutedEventArgs e)
        {
            StopLoaderAnimation();
        }


        private void BtnDeleteTool_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnSaveUpdateTool_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ComboBoxShopsForTools_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ScrollViewerTools_OnLoaded(object sender, RoutedEventArgs e)
        {
            //throw new NotImplementedException();
        }


        private void StartLoaderAnimation()
        {
            //
            //TODO run async on separate thread
            //



            Dispatcher.BeginInvoke(new Action(() =>
            {
                //((Storyboard)FindResource("WaitStoryboard")).Begin();
                Action action = () => BusyBar.IsBusy = true;
                Dispatcher.BeginInvoke(action);
              
                //BusyBar.IsBusy = true;

            }));

        }

        private void StopLoaderAnimation()
        {
            this.Dispatcher.BeginInvoke(new Action(() =>
            {
                ((Storyboard) FindResource("WaitStoryboard")).Stop();
            
            }));
        }

        private void ListBoxUpdateTools_OnIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void ListBoxUpdateTools_OnLoaded(object sender, RoutedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void ListBoxUpdateTools_OnInitialized(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void ListBoxUpdateTools_OnLayoutUpdated(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void ListBoxUpdateTools_OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            //_task?.Dispose();
            //BusyBar.IsBusy = false;
        }
    }
}
